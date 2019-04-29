using System;

namespace Reminder.Receiver.Core
{
	public interface IReminderReceiver
	{
		void Run();

		event EventHandler<MessageReceivedEventArgs> MessageReceived;
	}
}
