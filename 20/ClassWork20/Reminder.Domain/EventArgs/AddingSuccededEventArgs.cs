using Reminder.Domain.Model;

namespace Reminder.Domain.EventArgs
{
	public class AdddingSuccededEventArgs: System.EventArgs
	{
		public AddReminderModel Reminder { get; set; }

		public AdddingSuccededEventArgs(AddReminderModel reminder)
		{
			Reminder = reminder;
		}
	}
}
