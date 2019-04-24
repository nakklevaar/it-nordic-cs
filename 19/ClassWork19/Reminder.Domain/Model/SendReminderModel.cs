using System;

namespace Reminder.Domain.Model
{
	/// <summary>
	/// The single reminder item.
	/// </summary>
	public class SendReminderModel
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets contact id in the target sending system.
		/// </summary>
		public string ContactId { get; set; }

		/// <summary>
		/// The message of the reminder item for sending to the recepient.
		/// </summary>
		public string Message { get; set; }

	}
}

