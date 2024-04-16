 
using System.Net.Http.Headers;

using Microsoft.Extensions.Configuration; 

using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RecurringEvents.Remember;
using Serilog; 

await SendRememberMain();

static async Task SendRememberMain()
{

 // load the configuration file.
var configBuilder = new ConfigurationBuilder().
   AddJsonFile("appsettings.json").Build();

var configAppSection = configBuilder.GetSection("AppSettings");
var uriRecurringEvent = configAppSection["UriRecurringEvent"].ToString(); 
var apiSystemWasStarted  = configAppSection["ApiSystemWasStarted"] ?? null; 

var configRabbitSection = configBuilder.GetSection("RabbitSettings");
var hostNameRabbit = configRabbitSection["HostName"].ToString();
var portRabbit = int.Parse(configRabbitSection["Port"]); 
var userNameRabbit =  configRabbitSection["UserName"].ToString(); 
var passwordRabbit =  configRabbitSection["Password"].ToString();
var queueEvent = configRabbitSection["EventQueue"].ToString();

var configSecuritySection = configBuilder.GetSection("SecuritySettings");
 
var userNameToken =  configSecuritySection["UserName"].ToString(); 
var passwordToken =  configSecuritySection["Password"].ToString();
var apiCreateToken = configSecuritySection["ApiCreateToken"].ToString();

 var directory = new DirectoryInfo("log");
 
 var dataLastLog = (from f in directory.GetFiles()
             orderby f.LastWriteTime descending
             select f.LastWriteTime).FirstOrDefault();


    Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(@"log/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

  string Tokens = CreateToken(uriRecurringEvent, userNameToken, passwordToken, apiCreateToken);
 
  
  List<Event> events = new List<Event>();
  var dataRange = new DataRange()
  {
    from = dataLastLog ,
    to   = DateTime.Now
  };

  Log.Information("From: {from}, To: {to}",dataRange.from.ToString("dd/MM/yyyy"), dataRange.to.ToString("dd/MM/yyyy"));

   using var client = new HttpClient();
   client.BaseAddress = new Uri(uriRecurringEvent);

    HttpContent body = new StringContent(JsonSerializer.Serialize(dataRange), Encoding.UTF8, "application/json");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Tokens);
    var response = await client.PostAsync(apiSystemWasStarted, body);
     

  if (response.StatusCode == System.Net.HttpStatusCode.OK)
  {
      var apiString = response.Content.ReadAsStringAsync().Result;
        
      events = System.Text.Json.JsonSerializer.Deserialize<List<Event>>(apiString);
     
     if(events.Count()>0)
     {
      foreach(Event eve in events)
      {
        
        Log.Information(" {Data}, {Event}:{Description}", eve.date.ToString("dd/MM/yyyy"), eve.type, eve.description);
        string message = string.Empty;
        switch (eve.type.ToLower())
        {
          case "compleanno": message = string.Format("Il {0}/{1}, {2} ha compiuto {3} anni", +eve.date.Day, eve.date.Month, eve.description, (DateTime.Now.Year - eve.date.Year)) ;
                             break;
          case "onomastico": message = string.Format("Il {0}/{1}, {2} ha fatto l'onomastico", +eve.date.Day, eve.date.Month, eve.description) ;
                             break;
          default: message = eve.type + " " + eve.description + "," +eve.date.ToString("dd/MM/yyyy");
                  break;
        }
        Log.Information(" {Data}, {Event}:{Description}", eve.date.ToString("dd/MM/yyyy"), eve.type, message);
        SendRemember(hostNameRabbit, portRabbit, userNameRabbit, passwordRabbit, queueEvent,  message);

        
      }
     }else{
        Log.Information("Nessun evento nelle date, From: {from}, To: {to}",dataRange.from.ToString("dd/MM/yyyy"), dataRange.to.ToString("dd/MM/yyyy"));
     }

  } else{
    Log.Warning("Error, {StatuCode}", response.StatusCode);
  }  
   
Log.CloseAndFlush();      
}

  static void SendRemember(string hostName, int port, string userName, string password, string queueEvent, string message)
    {
        var factory = new ConnectionFactory() { HostName = hostName, Port = port, UserName = userName, Password = password , VirtualHost = "/" };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
           channel.QueueDeclare(queue: queueEvent,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
             
           
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: queueEvent,
                                 basicProperties: null,
                                 body: body);
         
        }


    }


static string CreateToken(string UriRecurringEvent, string userName, string password, string apiCreateToken)
 {
    using var client = new HttpClient();
    client.BaseAddress = new Uri(UriRecurringEvent);

     var postData = new PostData
    {
      username = userName,
      password = password
    };        


    HttpContent body = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json");
    var response = client.PostAsync(apiCreateToken, body).Result;
    var json = System.Text.Json.JsonSerializer.Serialize(postData);
    
    if (response.IsSuccessStatusCode) {
    var responseContent = response.Content.ReadAsStringAsync().Result;
    
    var options = new JsonSerializerOptions {
        PropertyNameCaseInsensitive = true
    };
    
    var postResponse = System.Text.Json.JsonSerializer.Deserialize<PostResponse>(responseContent, options);
      return postResponse.value;
    
    } else {
        return null;
    }
 }