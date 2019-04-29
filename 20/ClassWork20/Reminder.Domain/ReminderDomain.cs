﻿using System;
using System.Linq;
using System.Threading;
using Reminder.Domain.EventArgs;
using Reminder.Domain.Model;
using Reminder.Parsing;
using Reminder.Receiver.Core;
using Reminder.Sender.Core;
using Reminder.Storage.Core;

namespace Reminder.Domain
{
	public class ReminderDomain : IDisposable
	{
		private readonly TimeSpan _awaitingRemindersCheckingPeriod;
		private readonly TimeSpan _readyRemindersSendingPeriod;

		private readonly IReminderStorage _storage;
		private readonly IReminderReceiver _receiver;
		private readonly IReminderSender _sender;

		private Timer _awaitingRemindersCheckTimer;
		private Timer _readyRemindersSendTimer;

		public event EventHandler<AdddingSuccededEventArgs> AddingSucceded;
		public event EventHandler<SendingSuccededEventArgs> SendingSucceded;
		public event EventHandler<SendingFailedEventArgs> SendingFailed;

		public ReminderDomain(IReminderStorage storage, IReminderReceiver receiver, IReminderSender sender)
		{
			_storage = storage;
			_receiver = receiver;
			_sender = sender;

			_receiver.MessageReceived += Receiver_MessageReceived;

			_awaitingRemindersCheckingPeriod = TimeSpan.FromSeconds(1);
			_readyRemindersSendingPeriod = TimeSpan.FromSeconds(1);
		}

		public ReminderDomain(
			IReminderStorage storage,
			IReminderReceiver receiver, IReminderSender sender,
			TimeSpan awaitingRemindersCheckingPeriod,
			TimeSpan readyRemindersSendingPeriod) : this(storage,receiver,sender)
		{
			_awaitingRemindersCheckingPeriod = awaitingRemindersCheckingPeriod;
			_readyRemindersSendingPeriod = readyRemindersSendingPeriod;
		}

		public void Run()
		{
			_awaitingRemindersCheckTimer = new Timer(
				CheckAwaitingReminders,
				null,
				TimeSpan.Zero,
				_awaitingRemindersCheckingPeriod);

			_readyRemindersSendTimer = new Timer(
				SendReadyReminders,
				null,
				TimeSpan.Zero,
				_readyRemindersSendingPeriod);

			_receiver.Run();
		}

		public void Dispose()
		{
			_awaitingRemindersCheckTimer?.Dispose();
			_readyRemindersSendTimer?.Dispose();
		}

		private void Receiver_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			ParsedMessage parsedMessage = MessageParser.Parse(e.Message);
			if (parsedMessage != null)
			{
				var reminder = new ReminderItem
				{
					ContactId = e.ContactId,
					Message = parsedMessage.Message,
					Date = parsedMessage.Date,
					Status = ReminderItemStatus.Awaiting
				};

				_storage.Add(reminder);

				AddingSucceded?.Invoke(this,new AdddingSuccededEventArgs(new AddReminderModel
				{
					ContactId = reminder.ContactId,
					Message = reminder.Message,
					Date = reminder.Date
				}));
			}
		}

		#region Timer Callback Methods

		private void CheckAwaitingReminders(object dummy)
		{
			var ids = _storage
				.Get(ReminderItemStatus.Awaiting)
				.Where(r => r.IsTimeToSend)
				.Select(r => r.Id);

			_storage.UpdateStatus(
				ids,
				ReminderItemStatus.Ready);
		}

		private void SendReadyReminders(object dummy)
		{
			var sendReminderModels = _storage
				.Get(ReminderItemStatus.Ready)
				.Select(r =>
					new SendReminderModel
					{
						Id = r.Id,
						Message = r.Message,
						ContactId = r.ContactId
					})
				.ToList();

			foreach (SendReminderModel sendReminder in sendReminderModels)
			{
				try
				{
					_sender.Send(sendReminder.ContactId, sendReminder.Message);

					_storage.UpdateStatus(
						sendReminder.Id,
						ReminderItemStatus.Sent);

					SendingSucceded?.Invoke(
						this,
						new SendingSuccededEventArgs(
							sendReminder));
				}
				catch (Exception exception)
				{
					_storage.UpdateStatus(
						sendReminder.Id,
						ReminderItemStatus.Failed);

					SendingFailed?.Invoke(
						this,
						new SendingFailedEventArgs(
							sendReminder,
							exception));
				}
			}
		}

		#endregion
	}
}
