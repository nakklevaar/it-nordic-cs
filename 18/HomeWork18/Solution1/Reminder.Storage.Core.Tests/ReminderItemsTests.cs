using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Reminder.Storage.Core.Tests
{
	[TestClass]
	public class ReminderItemsTests
	{
		[TestMethod]
		public void Constructor_Validly_Set_Id_Property()
		{
			//Preparing
			Guid expected = new Guid("8B4CE401-DA30-442C-838D-AF7775F51793");

			//Running
			var reminderItem = new ReminderItem(expected, default(DateTimeOffset), null, null);

			//Checking 
			Assert.AreEqual(expected, reminderItem.Id);
		}

		[TestMethod]
		public void Day_Validly_Set_Id_Property()
		{
			//Preparing
			var expected = DateTimeOffset.Now;

			//Running
			var reminderItem = new ReminderItem(Guid.Empty, expected, null, null);

			//Checking 
			Assert.AreEqual(expected, reminderItem.Date);
		}

		[TestMethod]
		public void TimeToSend_Is_In_500_ms_Range()
		{
			var time500ms = TimeSpan.FromMilliseconds(500);

			//Running
			var reminderItem = new ReminderItem(Guid.Empty, DateTimeOffset.UtcNow+time500ms, null, null);

			var actual = reminderItem.TimeToSend;

			//Checking 
			Assert.IsTrue(actual < time500ms);
			Assert.IsTrue(actual > TimeSpan.Zero);
		}
	}
}
