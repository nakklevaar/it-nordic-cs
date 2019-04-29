using Reminder.Domain;
using Reminder.Domain.EventArgs;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.InMemory;
using System;

namespace Reminder.App
{
	class Program
	{
		static void Main(string[] args)
		{
			const string token = "889472492: AAEbc0JJ3euv6nCSdLrjTZn4E4Z6tXN0JXQ";

			var receiver = new TelegramReminderReceiver(token);
			var sender = new TelegramReminderSender(token);
			var storage = new InMemoryReminderStorage();

			var domain = new ReminderDomain(storage, receiver, sender);

			domain.AddingSucceded += Domain_AddingSucceded;
			domain.SendingSucceded += Domain_SendingSucceded;
			domain.SendingFailed += Domain_SendingFailed;

			domain.Run();

			Console.ReadKey();
		}

		private static void Domain_SendingFailed(object sender, SendingFailedEventArgs e)
		{
			Console.WriteLine("Reminder sending failed");
		}

		private static void Domain_SendingSucceded(object sender, SendingSuccededEventArgs e)
		{
			Console.WriteLine("Reminder sended");
		}

		private static void Domain_AddingSucceded(object sender, Domain.EventArgs.AdddingSuccededEventArgs e)
		{
			Console.WriteLine("Reminder added");
		}
	}
}
