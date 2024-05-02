using Moq;
using RecurringEvents.Reminder.Interface;
using RecurringEvents.Reminder.Service;

namespace RecurringEvents.Tests
{
    public class ReminderManagerTest
    {
        private Mock<IRecurringEventsAPI> _mockRecurringEventsAPI;
        private Mock<IRecurringEventsBrokerMessage> _mockBrokerMessage;
        private ReminderManager reminderManager;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}