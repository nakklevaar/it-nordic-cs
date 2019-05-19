using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemListPatchModel
    {
        public List<Guid> IdList { get; set; }

        public ReminderItemListPatchModel()
        {
        }

        public ReminderItemListPatchModel(IEnumerable<Guid> ids, ReminderItemStatus status)
        {
            IdList = ids.ToList();
            Status = status;
        }

        [Range(0, 3)]
        public ReminderItemStatus Status { get; set; }
    }
}
