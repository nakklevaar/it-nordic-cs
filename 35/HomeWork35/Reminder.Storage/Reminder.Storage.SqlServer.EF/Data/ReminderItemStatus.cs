using System;
using System.Collections.Generic;

namespace Reminder.Storage.SqlServer.EF.Data
{
    public partial class ReminderItemStatus
    {
        public ReminderItemStatus()
        {
            ReminderItem = new HashSet<ReminderItem>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ReminderItem> ReminderItem { get; set; }
    }
}
