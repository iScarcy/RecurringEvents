using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RecurringEvents.Worker.Configurations;
using System.Net.Http.Headers;
using System.Text;

  var builder = new ConfigurationBuilder();

    builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    IConfiguration config = builder.Build();
   

    var optsRabbitSettings = new RabbitSettings();
    var configRabbitSettings = config.GetSection("RabbitSettings");
    configRabbitSettings.Bind(optsRabbitSettings);
 
    Console.WriteLine($"Connecting to RabbitMQ at {optsRabbitSettings.HostName}:{optsRabbitSettings.Port} with user {optsRabbitSettings.UserName}");    
    var factory = new ConnectionFactory() { HostName = optsRabbitSettings.HostName, Port = optsRabbitSettings.Port, UserName = optsRabbitSettings.UserName, Password = optsRabbitSettings.Password, VirtualHost = "/" };
          
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();
    
await channel.QueueDeclareAsync(queue: optsRabbitSettings.EventQueue, durable: true, exclusive: false,
    autoDelete: false, arguments: new Dictionary<string, object?> { { "x-queue-type", "quorum" } });

await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += async (model, ea) =>
{
    byte[] body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");

    int dots = message.Split('.').Length - 1;
    await Task.Delay(dots * 1000);

    Console.WriteLine(" [x] Done");

    // here channel could also be accessed as ((AsyncEventingBasicConsumer)sender).Channel
    await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
};

await channel.BasicConsumeAsync(optsRabbitSettings.EventQueue, autoAck: false, consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();