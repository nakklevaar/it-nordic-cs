using Reminder.Sender.Core;
using System;
using Telegram.Bot;

namespace Reminder.Sender.Telegram
{
	public class TelegramReminderSender: IReminderSender
	{
		private TelegramBotClient botClient;

		public TelegramReminderSender(string accessToken)
		{
			botClient = new TelegramBotClient(accessToken);
		}

		public void Send(string contactId, string message)
		{
			var chatId = new global::Telegram.Bot.Types.ChatId(long.Parse(contactId));
			botClient.SendTextMessageAsync(chatId, message);
		}
	}
}
