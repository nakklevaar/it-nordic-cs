using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemPatchModel
    {
        public ReminderItemPatchModel(ReminderItemStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// Gets or sets the identifier of the recipient.
        /// </summary>
        [Range(0, 3)]
        public ReminderItemStatus Status { get; set; }
    }
}
