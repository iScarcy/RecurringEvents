
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using RecurringEvents.Application;

using RecurringEvents.Infrastructure;
using RecurringEvents.Infrastructure.DomainEvents;
using RecurringEvents.Web;
using RecurringEvents.Web.Swagger;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionStrings = builder.Configuration["ConnectionStrings:DefaultConnection"];


string Service_URL =  builder.Configuration["AppSettings:Service_URL"] ;

 
// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PersonWasCreatedHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(NameDayWasCreatedHanler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SistemWasStartedCreatedHanler).Assembly));
//builder.Services.AddMediatR(typeof(PersonWasCreatedHandler));
builder.Services.AddControllers(options =>
{ 
    options.Conventions.Add(new ProducesResponseTypeConvention());
});

builder.Services.AddApplication();

builder.Services.AddInfrastructure(dbConnectionStrings);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

 app.UseSwagger();
 app.UseSwaggerUI();


 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

 

app.Run(Service_URL);
