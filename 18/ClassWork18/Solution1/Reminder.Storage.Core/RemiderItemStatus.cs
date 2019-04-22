using System;

namespace Reminder.Storage.Core
{
	public enum RemiderItemStatus
	{
		Awaiting,
		ReadyToSend,
		SuccessfullySend,
		Failed,
	}
}