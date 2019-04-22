using System;

namespace Reminder.Storage.Core
{
	public class ReminderItem
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		string Message { get; set; }

		string ContactId { get; set; }

		public ReminderItem(Guid id, DateTimeOffset alarmDate, string message, string contactId)
		{
			Id = id;
			Date = alarmDate;
			Message = message;
			ContactId = ContactId;
		}

		public TimeSpan TimeToSend => Date - DateTimeOffset.UtcNow;
	}
}