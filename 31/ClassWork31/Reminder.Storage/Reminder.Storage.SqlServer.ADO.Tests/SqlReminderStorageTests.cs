using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    [TestClass]
    public class SqlReminderStorageTests
    {
        private const string _connectionString =
         @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ReminderTests;Integrated Security=True";

        [TestInitialize]
        public void TestIitialize()
        {
            new SqlReminderStorageInit(_connectionString).InitializeDataBase();
        }

        [TestMethod]
        public void Method_Add_Returns_Not_Empty_Guid()
        {
            var Storage = new SqlReminderStorage(_connectionString);

            Guid actual = Storage.Add(new Core.ReminderItemRestricted
            {
                ContactId = "TestContactId",
                Date = DateTimeOffset.Now.AddHours(1),
                Message = "test message",
                Status = Core.ReminderItemStatus.Awaiting
            });

            Assert.AreNotEqual(Guid.Empty, actual); 
        }
    }
}
