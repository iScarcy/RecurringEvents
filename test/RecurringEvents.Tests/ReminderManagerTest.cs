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
        public void SendReminder_get_and_send_reminder()
        {
           _mockBrokerMessageService = new Mock<IRecurringEventsBrokerMessage>();

            _mockRecurringEventsAPI
                .Setup(r => r.FinishExecution(It.IsAny<int>()))
                .Returns(Task.FromResult(0));
                         

            _reminderManager = new ReminderManager(_mockRecurringEventsAPI.Object, _mockBrokerMessageService.Object);

            IEnumerable<Event> events = new List<Event>()
            {
                new Event(Reminder.Enums.EventType.BirthDay,new DateTime(1983,08,22), "Giuseppe Scarcella")
            };

            var reminder = new RecurringEvents.Reminder.Models.Reminder() { Id = 123, Events = events };

            _reminderManager.SendReminder(reminder);

            Assert.Pass();
        }

        [Test]
        public void SendReminder_test_send_broker_message()
        {
            initBrokerMessageService();

            IEnumerable<Event> events = new List<Event>()
            {
                new Event(Reminder.Enums.EventType.BirthDay,new DateTime(1983,08,22), "Giuseppe Scarcella")
            };



            _mockRecurringEventsAPI
                .Setup(x => x.GetLastExecution())
                .Returns(Task.FromResult(DateTime.Now));

            _mockRecurringEventsAPI
                .Setup(x => x.StartExecution(It.IsAny<DateRange>()))
                .Returns(Task.FromResult(1));

            _mockRecurringEventsAPI
              .Setup(x => x.GetEvents(It.IsAny<DateRange>()))
              .Returns(Task.FromResult(events));


            _mockRecurringEventsAPI
                .Setup(r => r.FinishExecution(It.IsAny<int>()))
                .Returns(Task.FromResult(0));

            _reminderManager = new ReminderManager(_mockRecurringEventsAPI.Object, _brokerMessageService);



            var reminder = _reminderManager.GetReminder();
                    

            _reminderManager.SendReminder(reminder.Result);

            Assert.Pass();
        }
    }
}