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
			var reminderItem = new ReminderItem
			{
				ContactId = "TestContactId",
				Date = DateTimeOffset.Now,
				Message = "Test message"
			};

			client.Add(reminderItem);

		}
	}
}
