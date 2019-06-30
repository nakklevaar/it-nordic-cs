using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.Storage.SqlServer.EF.Tests
{
    [TestClass]
    public class ReminderStorageSqlServerEFTests
    {
        private const string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ReminderStorageTests;Integrated Security=true;";

        [TestInitialize]
        public void TestInitialize()
        {
            var context = new ReminderItemStorageContext(_connectionString);

            if ((context.Database.GetService<Microsoft.EntityFrameworkCore.Storage.IDatabaseCreator>() as
                Microsoft.EntityFrameworkCore.Storage.RelationalDatabaseCreator).Exists())
            {
                context.Database.EnsureDeleted();
            }
            context.Database.EnsureCreated();

            #region AddingTestsReminders
            context.ReminderItem.AddRange(
                new Data.ReminderItem
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ContactId = "Contact_1",
                    TargetDate = DateTimeOffset.Parse("2001-01-01 01:01:01"),
                    Message = "Message_1",
                    StatusId = (byte)ReminderItemStatus.Awaiting,
                    CreatedDate = DateTimeOffset.Parse("2111-01-01 00:00:00"),
                    UpdatedDate = DateTimeOffset.Parse("2111-01-01 00:00:00")
                },
                new Data.ReminderItem
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    ContactId = "Contact_2",
                    TargetDate = DateTimeOffset.Parse("2002-02-02 02:02:02"),
                    Message = "Message_2",
                    StatusId = (byte)ReminderItemStatus.Ready,
                    CreatedDate = DateTimeOffset.Parse("2222-02-02 00:00:00"),
                    UpdatedDate = DateTimeOffset.Parse("2222-02-02 00:00:00")
                },
                new Data.ReminderItem
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    ContactId = "Contact_3",
                    TargetDate = DateTimeOffset.Parse("2003-03-03 03:03:03"),
                    Message = "Message_3",
                    StatusId = (byte)ReminderItemStatus.Sent,
                    CreatedDate = DateTimeOffset.Parse("2333-03-03 00:00:00"),
                    UpdatedDate = DateTimeOffset.Parse("2333-03-03 00:00:00")
                },
                new Data.ReminderItem
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    ContactId = "Contact_4",
                    TargetDate = DateTimeOffset.Parse("2004-04-04 04:04:04"),
                    Message = "Message_4",
                    StatusId = (byte)ReminderItemStatus.Failed,
                    CreatedDate = DateTimeOffset.Parse("2444-04-04 00:00:00"),
                    UpdatedDate = DateTimeOffset.Parse("2444-04-04 00:00:00")
                },
                new Data.ReminderItem
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    ContactId = "Contact_6",
                    TargetDate = DateTimeOffset.Parse("2006-06-06 06:06:06"),
                    Message = "Message_6",
                    StatusId = (byte)ReminderItemStatus.Failed,
                    CreatedDate = DateTimeOffset.Parse("2666-06-06 00:00:00"),
                    UpdatedDate = DateTimeOffset.Parse("2666-06-06 00:00:00")
                });

            context.SaveChanges();
            #endregion
        }

        [TestMethod]
        public void Method_Add_Returns_Not_Empty_Guid()
        {
            var storage = new SqlReminderStorageEF(_connectionString);

            var reminderRestricted = new ReminderItemRestricted
            {
                ContactId = "Contact_5",
                Date = DateTimeOffset.Parse("2005-05-05 05:05:05"),
                Message = "Message_5",
                Status = ReminderItemStatus.Sent
            };

            var actualId = storage.Add(reminderRestricted);

            Assert.IsNotNull(actualId);
        }

        [TestMethod]
        public void Method_Get_Returns_Reminder_By_Id()
        {
            var storage = new SqlReminderStorageEF(_connectionString);

            var reminderItem = storage.Get(Guid.Parse("44444444-4444-4444-4444-444444444444"));

            Assert.AreEqual(Guid.Parse("44444444-4444-4444-4444-444444444444"), reminderItem.Id);
            Assert.AreEqual("Contact_4", reminderItem.ContactId);
            Assert.AreEqual(DateTimeOffset.Parse("2004-04-04 04:04:04"), reminderItem.Date);
            Assert.AreEqual("Message_4", reminderItem.Message);
            Assert.AreEqual(ReminderItemStatus.Failed, reminderItem.Status);
        }

        [TestMethod]
        public void Method_Get_By_Id_Returns_Null_If_Not_Found()
        {
            var storage = new SqlReminderStorageEF(_connectionString);

            var actual = storage.Get(Guid.Empty);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Property_Count_Returns_4()
        {
            var storage = new SqlReminderStorageEF(_connectionString);

            var actual = storage.Count;

            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void Method_Remove_By_Id_Doing_His_Job()
        {
            var storage = new SqlReminderStorageEF(_connectionString);

            var expected = storage.Count;

            storage.Remove(Guid.Parse("11111111-1111-1111-1111-111111111111"));

            var actual = storage.Count;

            Assert.IsTrue(expected - 1 == actual);
        }

        [TestMethod]
        public void Get_By_Status_Method_Returns_2()
        {
            var storage = new SqlReminderStorageEF(_connectionString);

            var actual = storage.Get(ReminderItemStatus.Failed);

            Assert.IsTrue(actual.Count == 2);
        }

        [TestMethod]
        public void Method_UpdateStatus_By_Id_Finally_Update_Status()
        {
            var storage = new SqlReminderStorageEF(_connectionString);

            storage.UpdateStatus(Guid.Parse("66666666-6666-6666-6666-666666666666"), ReminderItemStatus.Awaiting);

            var reminder = storage.Get(Guid.Parse("66666666-6666-6666-6666-666666666666"));

            Assert.AreEqual(ReminderItemStatus.Awaiting, reminder.Status);
        }

        [TestMethod]
        public void UpdateStatus_Method_With_Ids_Collection_Updates_Corresponded_Items()
        {
            var storage = new SqlReminderStorageEF(_connectionString);

            var ids = new List<Guid>
            {
                new Guid("11111111-1111-1111-1111-111111111111"),
                new Guid("22222222-2222-2222-2222-222222222222"),
                new Guid("33333333-3333-3333-3333-333333333333")
            };

            storage.UpdateStatus(ids, ReminderItemStatus.Failed);

            var actual = storage.Get(ReminderItemStatus.Failed);

            Assert.IsTrue(actual.Select(x => x.Id).Contains(ids[0]));
            Assert.IsTrue(actual.Select(x => x.Id).Contains(ids[1]));
            Assert.IsTrue(actual.Select(x => x.Id).Contains(ids[2]));
        }
    }
}
