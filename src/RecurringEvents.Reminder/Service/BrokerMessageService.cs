using RabbitMQ.Client;
using RecurringEvents.Reminder.Configurations;
using RecurringEvents.Reminder.Interface;
using RecurringEvents.Reminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Reminder.Service
{
    public class BrokerMessageService : IRecurringEventsBrokerMessage
    {
        private readonly RabbitSettings _rabbitSettings;
        public BrokerMessageService(RabbitSettings settings) 
        { 
            _rabbitSettings = settings;
        }
        public void SendMessage(BrokerMessage message)
        {
            var factory = new ConnectionFactory() { HostName = _rabbitSettings.HostName, Port = _rabbitSettings.Port, UserName = _rabbitSettings.UserName, Password = _rabbitSettings.Password, VirtualHost = "/" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _rabbitSettings.EventQueue,
                                      durable: true,
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);


                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: _rabbitSettings.EventQueue,
                                     basicProperties: null,
                                     body: body);

            }
        }
    }
}
