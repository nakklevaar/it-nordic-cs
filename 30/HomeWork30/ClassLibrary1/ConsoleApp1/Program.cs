using Reminder.Storage.Core;
using Reminder.Storage.Sql;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionStringTemplate =
                "Data Source={0};" +
                "Initial Catalog={1};" +
                "Integrated Security=true";

            string conenctionString = string.Format(connectionStringTemplate, @"localhost\SQLEXPRESS", "Storage");

            var repository = new SqlStorage(conenctionString);

            #region testing

            var reminder1 = new ReminderItemRestricted
            {
                ContactId = "Tom",
                Date = DateTimeOffset.Now,
                Message = "hi tommy",
                Status = (ReminderItemStatus)1
            };

            var newid = repository.Add(reminder1);
            Console.WriteLine(newid);

            ReminderItem reminder = repository.Get(newid);
            Console.WriteLine(reminder.ContactId);

            var list = repository.Get(ReminderItemStatus.Ready);

            int m = 0;
            foreach (var rem in list)
            {
                ++m;
            }
            Console.WriteLine(m);

            repository.UpdateStatus(newid, ReminderItemStatus.Failed);

            reminder = repository.Get(newid);
            Console.WriteLine(reminder.Status);

            List<Guid> ids = new List<Guid>
            {
                Guid.Parse("D19F4EF4-3C36-453C-8384-76B27ACF8C92"),
                Guid.Parse("67E41C35-B81E-4CC4-9BE3-77B34AE4865F"),
                Guid.Parse("27283CA6-295E-42F3-B6D6-7C2003B6CA9A"),
                Guid.Parse("A31EA458-43B0-47E6-850D-7C36ADC40EB1"),
                Guid.Parse("D8D495B9-D907-4456-8E47-8FB270F48060"),
            };

            repository.UpdateStatus(ids, ReminderItemStatus.Awaiting);

            #endregion
        }
    }
}
