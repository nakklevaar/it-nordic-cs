using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Reminder.Storage.Core;
using Reminder.Storage.SqlServer.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.Storage.SqlServer.EF
{
    public class EntityFrameworkReminderStorage : IReminderStorage
    {
        public static readonly LoggerFactory MyConsoleLoggerFactory =
            new LoggerFactory(new[]
            {
#pragma warning disable CS0618 // Type or member is obsolete

                new ConsoleLoggerProvider(
                    (category, level)=>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information,
                    true)

#pragma warning restore CS0618 // Type or member is obsolete
            });

        private readonly DbContextOptionsBuilder<ReminderStorageContext> _builder;

        public EntityFrameworkReminderStorage(string connectionString, bool enableLogging = false)
        {
            _builder = new DbContextOptionsBuilder<ReminderStorageContext>()
                .UseSqlServer(connectionString);

            if (enableLogging)
            {
                _builder.UseLoggerFactory(MyConsoleLoggerFactory).EnableSensitiveDataLogging(true);
            }
        }

        public int Count
        {
            get
            {
                using (var context = new ReminderStorageContext(_builder.Options))
                {
                    return context.ReminderItems.Count();
                }
            }
        }

        public Guid Add(ReminderItemRestricted reminder)
        {
            var reminderDto = new ReminderItemDto
            {
                ContactId = reminder.ContactId,
                TargetDate = reminder.Date,
                Message = reminder.Message,
                Status = reminder.Status
            };

            using (var context = new ReminderStorageContext(_builder.Options))
            {
                context.ReminderItems.Add(reminderDto);
                context.SaveChanges();
                return reminderDto.Id;
            }
        }

        public ReminderItem Get(Guid id)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                return context.ReminderItems.FirstOrDefault(ri => ri.Id == id)?.ToReminderItem();
            }
        }

        public List<ReminderItem> Get(int count = 0, int startPostion = 0)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                if (count == 0 && startPostion == 0)
                {
                    return context.ReminderItems
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }

                if (count == 0)
                {
                    return context.ReminderItems
                        .OrderBy(r => r.Id)
                        .Skip(startPostion)
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }

                return context.ReminderItems
                    .OrderBy(r => r.Id)
                    .Skip(startPostion)
                    .Take(count)
                    .Select(r => r.ToReminderItem())
                    .ToList();

            }
        }

        public List<ReminderItem> Get(ReminderItemStatus status, int count, int startPostion)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                if (count == 0 && startPostion == 0)
                {
                    return context.ReminderItems
                        .Where(r => r.Status == status)
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }

                if (count == 0)
                {
                    return context.ReminderItems
                        .Where(r => r.Status == status)
                        .OrderBy(r=>r.Id)
                        .Skip(startPostion)
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }

                return context.ReminderItems
                    .Where(r => r.Status == status)
                    .OrderBy(r => r.Id)
                    .Skip(startPostion)
                    .Take(count)
                    .Select(r => r.ToReminderItem())
                    .ToList();

            }
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            var reminders = new List<ReminderItem>();

            using (var context = new ReminderStorageContext(_builder.Options))
            {
                reminders = context.ReminderItems
                    .Where(r => r.Status == status)
                    .Select(r => r.ToReminderItem())
                    .ToList();
            }
            return reminders;
        }

        public bool Remove(Guid id)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var reminder = context.ReminderItems.FirstOrDefault(r => r.Id == id);

                if (reminder != null)
                {
                    context.ReminderItems.Remove(reminder);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var reminders = context.ReminderItems.Where(r => ids.Contains(r.Id)).ToList().Select(r => { r.Status = status; return r; }).ToList();

                //foreach (var reminder in reminders)
                //{
                //    reminder.Status = status;
                //}
                context.SaveChanges();
            }
        }

        public void UpdateStatus(Guid id, ReminderItemStatus status)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var reminder = context.ReminderItems.FirstOrDefault(r => r.Id == id);

                if (reminder != null)
                {
                    reminder.Status = status;
                    context.SaveChanges();
                }
            }
        }
    }
}
