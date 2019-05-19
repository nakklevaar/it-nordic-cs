using System;
using Reminder.Storage.WebApi.Client;
using Reminder.Storage.Core;
using System.Collections.Generic;

namespace Reminder.App1
{
	class Program
	{
		static void Main ()
		{
			var client = new ReminderStorageWebApiClient("https://localhost:44348");
			var reminderItem = new ReminderItem
			{
				ContactId = "TestContactId",
				Date = DateTimeOffset.Now,
				Message = "Test message",
               Status = ReminderItemStatus.Ready
			};

            var reminderItem1 = new ReminderItem
            {
                ContactId = "TestContactId1",
                Date = DateTimeOffset.Now,
                Message = "Test message1",
                Status = ReminderItemStatus.Ready
            };

            var reminderItem2 = new ReminderItem
            {
                ContactId = "TestContactId2",
                Date = DateTimeOffset.Now,
                Message = "Test message2",
                Status = ReminderItemStatus.Sent
            };

            //client.Add(reminderItem);
           // client.Add(reminderItem1);
           // client.Add(reminderItem2);
            Console.WriteLine("Hello");

            var List = new List<Guid>() { Guid.Parse("00000000-0000-0000-0000-000000000000"), Guid.Parse("10000000-0000-0000-0000-000000000001"), Guid.Parse("20000000-0000-0000-0000-000000000002") };

            client.UpdateStatus(List, ReminderItemStatus.Failed);
        }
	}
}
