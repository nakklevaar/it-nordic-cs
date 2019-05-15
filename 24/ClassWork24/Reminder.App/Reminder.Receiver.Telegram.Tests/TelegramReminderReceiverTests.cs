using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Receiver.Telegram;

namespace Reminder.Receiver.Telegram.Tests
{
	[TestClass]
	public class TelegramReminderReceiverTests
	{
		private const string _token = "633428988:AAHLW_LaS7A47PDO2I8sbLkIIM9L0joPOSQ";

		[TestMethod]
		public void GetHelloFromBot_Returns_Not_Empty_String()
		{
			TelegramReminderReceiver reminderReceiver = new TelegramReminderReceiver(_token);

			string description = reminderReceiver.GetHelloFromBot();

			Assert.IsNotNull(description);
		}
	}
}
