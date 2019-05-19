using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Controllers
{
    [Route("api/reminders")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private IReminderStorage _reminderStorage;

        public RemindersController(IReminderStorage reminderStorage)
        {
            _reminderStorage = reminderStorage;
        }

        [HttpGet("{id}", Name = "GetReminder")]
        public IActionResult Get(Guid id)
        {
            var reminderItem = _reminderStorage.Get(id);

            if (reminderItem == null)
            {
                return NotFound();
            }

            return Ok(new ReminderItemGetModel(reminderItem));
        }

        [HttpGet]
        public IActionResult GetReminders([FromQuery(Name = "[filter]status")]ReminderItemStatus status)
        {
            var reminderItemGetModels = _reminderStorage
                .Get(status)
                .Select(x => new ReminderItemGetModel(x))
                .ToList();

            return Ok(reminderItemGetModels);
        }

        [HttpPost]
        public IActionResult CreateReminder([FromBody] ReminderItemCreateModel reminder)
        {
            if (reminder == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var reminderItem = reminder.ToReminderItem();
            _reminderStorage.Add(reminderItem);

            return CreatedAtRoute("GetReminder", new { id = reminderItem.Id }, new ReminderItemGetModel(reminderItem));
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateReminder(Guid id, [FromBody] ReminderItemPatchModel patchModel)
        {
            var reminder = _reminderStorage.Get(id);

            if (reminder == null)
            {
                return NotFound();
            }
            var patch = new JsonPatchDocument();

            if (patchModel.Status != reminder.Status)
            {
                patch.Replace(nameof(patchModel.Status), patchModel.Status);
            }

            patch.ApplyTo(reminder);

            return Ok(reminder);
        }

        [HttpPatch]
        public IActionResult UpdateListReminder([FromBody] ReminderItemListPatchModel listPatchModel)
        {
            var reminders = listPatchModel
                .IdList
                .Select(x => _reminderStorage.Get(x))
                .ToList();

            if (reminders == null)
            {
                return NotFound();
            }

            var patch = new JsonPatchDocument();

            var patchModel = new ReminderItemPatchModel(listPatchModel.Status);

            reminders = reminders
                 .Where(x => patchModel.Status != x.Status)
                 .Select(x =>
                 {
                     patch.Replace(nameof(patchModel.Status), patchModel.Status);
                     patch.ApplyTo(x);
                     return x;
                 })
                 .ToList();

            return Ok(reminders);
        }
    }
}
