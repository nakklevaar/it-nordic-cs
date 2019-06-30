using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Reminder.Storage.SqlServer.EF
{
    public class SqlReminderStorageEF : IReminderStorage
    {
        private readonly string _connectionString;

        public SqlReminderStorageEF(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Count
        {
            get
            {
                using (var context = GetSingleContextConnection())
                {
                    return context.ReminderItem.Count();
                }
            }
        }

        public Guid Add(ReminderItemRestricted reminder)
        {
            var reminderItem = new Data.ReminderItem
            {
                Id = Guid.NewGuid(),
                ContactId = reminder.ContactId,
                TargetDate = reminder.Date,
                Message = reminder.Message,
                StatusId = (byte)reminder.Status,
                CreatedDate = DateTimeOffset.Now,
                UpdatedDate = DateTimeOffset.Now
            };

            using (var context = GetSingleContextConnection())
            {
                context.ReminderItem.Add(reminderItem);
                context.SaveChanges();
            }

            return reminderItem.Id;
        }

        public ReminderItem Get(Guid id)
        {
            using (var context = GetSingleContextConnection())
            {
                var reminderContext = context.ReminderItem.FirstOrDefault(r => r.Id == id);

                if (reminderContext != null)
                {
                    var reminder = new ReminderItem
                    {
                        Id = reminderContext.Id,
                        ContactId = reminderContext.ContactId,
                        Date = reminderContext.TargetDate,
                        Message = reminderContext.Message,
                        Status = (ReminderItemStatus)reminderContext.StatusId
                    };

                    return reminder;
                }
                return null;
            }
        }

        public List<ReminderItem> Get(int count = 0, int startPostion = 0)
        {
            var result = new List<ReminderItem>();

            result.AddRange(Get(ReminderItemStatus.Awaiting));
            result.AddRange(Get(ReminderItemStatus.Ready));                     //not implemented
            result.AddRange(Get(ReminderItemStatus.Sent));
            result.AddRange(Get(ReminderItemStatus.Failed));

            return result;
        }

        public List<ReminderItem> Get(ReminderItemStatus status, int count, int startPostion)
        {
            return Get(status);                 //not implemented
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            var reminders = new List<ReminderItem>();

            using (var context = GetSingleContextConnection())
            {
                reminders = context.ReminderItem
                    .Where(r => r.StatusId == (byte)status)
                    .Select(r => new ReminderItem
                    {
                        Id = r.Id,
                        ContactId = r.ContactId,
                        Date = r.TargetDate,
                        Message = r.Message,
                        Status = (ReminderItemStatus)r.StatusId
                    })
                    .ToList();
            }
            return reminders;
        }

        public bool Remove(Guid id)
        {
            using (var context = GetSingleContextConnection())
            {
                var reminder = context.ReminderItem.FirstOrDefault(r => r.Id == id);

                if (reminder != null)
                {
                    context.ReminderItem.Remove(reminder);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
        {
            using (var context = GetSingleContextConnection())
            {
                var reminders = context.ReminderItem.Where(r => ids.ToList().Contains(r.Id)).ToList();
                
                foreach (var reminder in reminders)
                {
                    reminder.StatusId = (byte)status;
                }
                context.SaveChanges();
            }
        }

        public void UpdateStatus(Guid id, ReminderItemStatus status)
        {
            using (var context = GetSingleContextConnection())
            {
                var reminder = context.ReminderItem.FirstOrDefault(r => r.Id == id);

                if (reminder != null)
                {
                    reminder.StatusId = (byte)status;
                    context.SaveChanges();
                }
            }
        }

        private ReminderItemStorageContext GetSingleContextConnection()
        {
            var context = new ReminderItemStorageContext(_connectionString);
            return context;
        }
    }
}
