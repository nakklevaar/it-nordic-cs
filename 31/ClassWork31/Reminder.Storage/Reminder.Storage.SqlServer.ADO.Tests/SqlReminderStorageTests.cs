using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    class SqlReminderStorageTests
    {
        private const string _connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ReminderTests, Integrated Security";

        [TestInitialize]
        public void TestIitialize()
        {
            new SqlReminderStorageInit(_connectionString).InitializeDatabase();
        }

        [TestMethod]
        public void Method_Add_Returns_Not_Empty_Guid()
        {
            var Storage = new SqlReminderStorage(_connectionString);

            Guid actual = Storage.Add(new Core.ReminderItemRestricted)
        }
    }
}
