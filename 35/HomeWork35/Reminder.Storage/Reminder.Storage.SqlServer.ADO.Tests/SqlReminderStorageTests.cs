using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;

namespace Reminder.Storage.Sql.Tests
{
    [TestClass]
    public class SqlReminderStorageTests
    {
        private const string _connectionString =
			@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ReminderTests;Integrated Security=true;";

        [TestInitialize]
        public void TestInitialize()
        {
            var dbInit = new SqlReminderStorageInit(_connectionString);
            dbInit.InitializeDatabase();
        }

        [TestMethod]
        public void Method_Add_Returns_Not_Empty_Guid()
        {
            var storage = new SqlReminderStorage(_connectionString);

            Guid actual = storage.Add(new Core.ReminderItemRestricted
            {
                ContactId = "TestContactId",
                Date = DateTimeOffset.Now.AddHours(1),
                Message = "Test Message",
                Status = Core.ReminderItemStatus.Awaiting
            });

            Assert.AreNotEqual(Guid.Empty, actual);
        }

        [TestMethod]
        public void Get_By_Id_Method_Returns_Just_Added_Item()
        {
            var storage = new SqlReminderStorage(_connectionString);

            DateTimeOffset expectedDate = DateTimeOffset.Now;
            string expectedContactId = "TEST_COMMAND_ID";
            string expectedMessage = "TEST_MESSAGE_TEXT";
            ReminderItemStatus expectedStatus = ReminderItemStatus.Awaiting;

            Guid id = storage.Add(new ReminderItemRestricted
            {
                ContactId = expectedContactId,
                Date = expectedDate,
                Message = expectedMessage,
                Status = expectedStatus
            });

            Assert.AreNotSame(Guid.Empty, id);

            var actualItem = storage.Get(id);

            Assert.IsNotNull(actualItem);
            Assert.AreEqual(id, actualItem.Id);
            Assert.AreEqual(expectedContactId, actualItem.ContactId);
            Assert.AreEqual(expectedDate, actualItem.Date);
            Assert.AreEqual(expectedMessage, actualItem.Message);
            Assert.AreEqual(expectedStatus, actualItem.Status);
        }

        [TestMethod]
        public void Get_By_Id_Returns_Null_If_Not_Found()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Get(Guid.Empty);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Get_By_Status_Method_Returns_2_Reminders_And_Returns_The_Same()
        {
            var storage = new SqlReminderStorage(_connectionString);

            var actual = storage.Get(ReminderItemStatus.Ready);

            Assert.IsTrue(actual.Count == 2);

            var reminder = new ReminderItem
            {
                Id = Guid.Parse("00000000-0000-0000-0000-222222222222"),
                ContactId = "ContactId_2",
                Date = DateTimeOffset.Parse("2020-02-02 00:00:00 +00:00"),
                Message = "Message_2",
                Status = (ReminderItemStatus)1
            };

            Assert.IsNotNull(actual.Where(x => x.Id == reminder.Id));
        }

        [TestMethod]
        public void Update_Method_By_Id_Finally_Update_Status()
        {
            var storage = new SqlReminderStorage(_connectionString);

            Guid id = Guid.Parse("00000000-0000-0000-0000-333333333333");

            var reminderStatus = storage.Get(id).Status;

            var expectedStatus = ReminderItemStatus.Failed;

            Assert.AreNotSame(expectedStatus, reminderStatus);

            storage.UpdateStatus(id, expectedStatus);

            var actualReminderStatus = storage.Get(id).Status;

            Assert.AreEqual(expectedStatus, actualReminderStatus);
        }

		[TestMethod]
		public void Property_Count_Returns_8_For_Initial_Data_Set()
		{
			var storage = new SqlReminderStorage(_connectionString);

			int actual = storage.Count;

			Assert.AreEqual(3, actual);
		}

		[TestMethod]
		public void Method_Delete()
		{
			var storage = new SqlReminderStorage(_connectionString);

			storage.Remove(Guid.Parse("00000000-0000-0000-0000-333333333333"));

			int actual = storage.Count;

			Assert.AreEqual(2, actual);
		}

		[TestMethod]
		public void UpdateStatus_Method_With_Ids_Collection_Updates_Corresponded_Items()
		{
			var storage = new SqlReminderStorage(_connectionString);

			var ids = new List<Guid>
			{
				new Guid("00000000-0000-0000-0000-111111111111"),
				new Guid("00000000-0000-0000-0000-222222222222"),
				new Guid("00000000-0000-0000-0000-333333333333")
			};

			storage.UpdateStatus(ids, ReminderItemStatus.Failed);

			var actual = storage.Get(ReminderItemStatus.Failed);

			Assert.IsTrue(actual.Select(x => x.Id).Contains(ids[0]));
			Assert.IsTrue(actual.Select(x => x.Id).Contains(ids[1]));
			Assert.IsTrue(actual.Select(x => x.Id).Contains(ids[2]));
		}
	}
}
