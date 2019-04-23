using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using System.Linq;

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
            if (reminderItem.ItemStatus == ReminderItemStatus.Awaiting)
            {
                if (!_storage.ContainsValue(reminderItem))
                    _storage.Add(reminderItem.Id, reminderItem);
                else
                    throw new Exception("already exists");
            }
            else
                throw new Exception ("out of date");
        }

		public ReminderItem Get(Guid id)
		{
			if (_storage.ContainsKey(id))
				return _storage[id];
			else return null;
		}

		public List<ReminderItem> GetList(IEnumerable<ReminderItemStatus> status, int count=-1, int startPosition=0)
		{
            var list = new List<ReminderItem>();
            int countchecker = 0;

            if (startPosition >= 0 && startPosition < _storage.Count && count >= 0 && count < _storage.Count || count==-1)
            {
                if (count == -1)
                {
                    count = _storage.Count;
                }

                for (   ; startPosition < count; startPosition++)
                {
                    if (status.Contains(_storage.ElementAt(startPosition).Value.ItemStatus))
                    {
                        list.Add(_storage.ElementAt(startPosition).Value);
                            countchecker++;

                            if (countchecker == count)
                                break;
                    }
                }
            }

            return list;
		}

		public void Update(ReminderItem reminderItem)
		{
            if (reminderItem.ItemStatus == ReminderItemStatus.Awaiting)
            {
                if (_storage.ContainsValue(reminderItem))
                    _storage[reminderItem.Id] = reminderItem;
                else
                    throw new Exception("doesnt exist");
            }
            else
                throw new Exception("out of date");
        }
	}
}
