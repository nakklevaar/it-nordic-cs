using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using System.Linq;

namespace Reminder.Storage.InMemory.Tests
{
    [TestClass]
    public class ReminderStorageTests
    {
        [TestMethod]
        public void Add__And_Get_Works_Validly()
        {
            var storage = new ReminderStorage();
            var id = new Guid ("531F3399-3DB0-41EA-9D7D-BA1E9651C62A");
            var expected = new ReminderItem(id, DateTimeOffset.Now, null, null);

            storage.Add(expected);
            var actual = storage.Get(id);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetList_Works_Validly()
        {
            var storage = new ReminderStorage();
            var id = new Guid("531F3399-3DB0-41EA-9D7D-BA1E9651C62A");
            var remItem = new ReminderItem(id, DateTimeOffset.MaxValue, null, null)
            {
                ItemStatus = ReminderItemStatus.Awaiting
                
            };

            storage.Add(remItem);

            var expected = new List<ReminderItem> { remItem };

            ReminderItemStatus[] arr = { ReminderItemStatus.Awaiting, ReminderItemStatus.Failed };
            var actual = storage.GetList(arr);


            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Update_Works_Validly()
        {
            var storage = new ReminderStorage();
            var id = new Guid("531F3399-3DB0-41EA-9D7D-BA1E9651C62A");
            var expected = new ReminderItem(id, DateTimeOffset.MaxValue, null, null);

            storage.Add(expected);

            expected.Message = "not null";

            var actual = expected;
            
            storage.Update(actual);

            Assert.AreEqual(expected, actual);

        }
    }
}
