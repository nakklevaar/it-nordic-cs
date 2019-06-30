using System;
using System.Collections.Generic;

namespace Reminder.Storage.SqlServer.EF.Data
{
    public partial class ReminderItem
    {
        public Guid Id { get; set; }
        public string ContactId { get; set; }
        public DateTimeOffset TargetDate { get; set; }
        public string Message { get; set; }
        public byte StatusId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public ReminderItemStatus Status { get; set; }
    }
}
