using System;

namespace Reminder.Storage.Core
{
	public class ReminderItem
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

        public ReminderItemStatus ItemStatus { get; set; }

        public ReminderItem(Guid id, DateTimeOffset alarmDate, string message, string contactId)
		{
			Id = id;
			Date = alarmDate;
			Message = message;
			ContactId = ContactId;
		}

		//public TimeSpan TimeToSend => Date - DateTimeOffset.UtcNow;
	}
}