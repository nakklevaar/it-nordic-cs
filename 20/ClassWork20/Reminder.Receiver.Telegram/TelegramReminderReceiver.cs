using Reminder.Receiver.Core;
using System;
using Telegram.Bot;

namespace Reminder.Receiver.Telegram
{
	public class TelegramReminderReceiver : IReminderReceiver
	{
		private TelegramBotClient botClient;

		public event EventHandler<MessageReceivedEventArgs> MessageReceived;

		public TelegramReminderReceiver(string token)
		{
			botClient = new TelegramBotClient(token);
		}

		public string GetHelloFromBot()
		{
			global::Telegram.Bot.Types.User user = botClient.GetMeAsync().Result;

			return $"Hello from user {user.Id}. My name is {user.FirstName} {user.LastName}";
		}

		public void Run()
		{
			botClient.OnMessage += BotClient_OnMessage;
			botClient.StartReceiving();
		}

		private void BotClient_OnMessage(object sender, global::Telegram.Bot.Args.MessageEventArgs e)
		{
			if(e.Message.Type == global::Telegram.Bot.Types.Enums.MessageType.Text)
			{
				OnMessageReceived(this, new MessageReceivedEventArgs(e.Message.Chat.Id.ToString(), e.Message.Text));
			}
		}

		protected virtual void OnMessageReceived(object sender, MessageReceivedEventArgs e)
		{
			MessageReceived?.Invoke(sender, e);
		}
	}
}
