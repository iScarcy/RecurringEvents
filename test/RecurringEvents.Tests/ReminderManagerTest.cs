using Microsoft.Extensions.Configuration;
using Moq;
using RecurringEvents.Reminder.Configurations;
using RecurringEvents.Reminder.Interface;
using RecurringEvents.Reminder.Models;
using RecurringEvents.Reminder.Service;
using Serilog;

namespace RecurringEvents.Tests
{
    public class ReminderManagerTest
    {
        private Mock<IRecurringEventsAPI> _mockRecurringEventsAPI;
        private Mock<IRecurringEventsBrokerMessage> _mockBrokerMessageService;

        private IRecurringEventsBrokerMessage _brokerMessageService;

        private ReminderManager _reminderManager;
        [SetUp]
        public void Setup()
        {
            _mockRecurringEventsAPI = new Mock<IRecurringEventsAPI>();
        }

        private void initBrokerMessageService()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            var optsRabbitSettings = new RabbitSettings();
            var configRabbitSettings = config.GetSection("RabbitSettings");
            configRabbitSettings.Bind(optsRabbitSettings);
            _brokerMessageService = new BrokerMessageService(optsRabbitSettings);

        }

        [Test]
        public void SendReminder_test_send_broker_message()
        {
            initBrokerMessageService();

            _reminderManager = new ReminderManager(_mockRecurringEventsAPI.Object, _brokerMessageService);

            List <Event> events = new List<Event>()
            {
                new Event(Reminder.Enums.EventType.NameDay,new DateTime(22,08,1983), "Giuseppe Scarcella")
            };

            var reminder = new RecurringEvents.Reminder.Models.Reminder() { Id = 123, Events = events};

            _reminderManager.SendReminder(reminder);

            Assert.Pass();
        }
    }
}