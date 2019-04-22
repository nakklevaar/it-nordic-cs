using System;
using System.Collections.Generic;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
	public class ReminderStorage : IReminderStorage
	{
		private Dictionary<Guid, ReminderItem> _storage;

		public ReminderStorage()
		{
			_storage = new Dictionary<Guid, ReminderItem>();
		}

		public void Add(ReminderItem reminderItem)
		{
			_storage.Add(reminderItem.Id, reminderItem);
		}

		public ReminderItem Get(Guid id)
		{
			if (_storage.ContainsKey(id))
				return _storage[id];
			else return null;
		}

		public List<ReminderItem> GetList(RemiderItemStatus status, int count, int startPosition)
		{
			throw new NotImplementedException();
		}

		public void Update(ReminderItem reminderItem)
		{
			//TODO : add custom exception throwing if not found;
			_storage[reminderItem.Id] = reminderItem;
		}
	}
}
