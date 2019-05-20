using Reminder.Storage.Core;
using System;

namespace Reminder.Storage.WebApi.Core
{
	public class ReminderItemGetModel
	{
		/// <summary>
		/// Gets the identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the date and time the reminder item scheduled for sending.
		/// </summary>
		public DateTimeOffset Date { get; set; }

		/// <summary>
		/// Gets or sets contact identifier in the target sending system.
		/// </summary>
		public string ContactId { get; set; }

		/// <summary>
		/// Gets or sets the message of the reminder item for sending to the recipient.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the identifier of the recipient.
		/// </summary>
		public ReminderItemStatusUpdateModel Status { get; set; }

		public ReminderItemGetModel()
		{
		}

		public ReminderItemGetModel(ReminderItemResricted reminderItem)
		{
			Id = reminderItem.Id;
			Date = reminderItem.Date;
			ContactId = reminderItem.ContactId;
			Message = reminderItem.Message;
			Status = reminderItem.Status;
		}

		public ReminderItemGetModel(Guid id, ReminderItemRestricted reminderItem)
		{
			Id = id;
			Date = reminderItem.Date;
			ContactId = reminderItem.ContactId;
			Message = reminderItem.Message;
			Status = reminderItem.Status;
		}

		public ReminderItemResricted ToReminderItem()
		{
			return new ReminderItemResricted()
			{
				Id = Id,
				Date = Date,
				ContactId = ContactId,
				Message = Message,
				Status = Status
			};
		}
	}
}
