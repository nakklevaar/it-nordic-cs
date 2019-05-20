using System;
using Reminder.Storage.WebApi.Client;
using Reminder.Storage.Core;

namespace Reminder.App1
{
	class Program
	{
		static void Main ()
		{
			var client = new ReminderStorageWebApiClient("https://localhost:5001");
			var reminderItem = new ReminderItemRestricted
			{
				ContactId = "TestContactId",
				Date = DateTimeOffset.Now,
				Message = "Test message"
			};

			var id = client.Add(reminderItem);

			Console.WriteLine("Adding Done");

			var reminderItemFromStorage = client.Get(id);

			Console.WriteLine($"{reminderItemFromStorage.Id}\n" +
				$"{reminderItemFromStorage.ContactId}\n" +
				$"{reminderItemFromStorage.Date}\n" +
				$"{reminderItemFromStorage.Message}\n");

		}
	}
}
