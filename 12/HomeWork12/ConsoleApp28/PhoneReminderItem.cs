using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
    class PhoneReminderItem : ReminderItem
    {
        string PhoneNumber { get; set; }

        public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage, string phoneNumber) : base (alarmDate,alarmMessage)
        {
            PhoneNumber = phoneNumber;
        }

        public override void WriteProperties()
        {
            Console.WriteLine(GetType().Name);
            Console.WriteLine($"{nameof(AlarmDate)} : {AlarmDate.ToString("MM/dd/yyyy HH:mm:ss")}");
            Console.WriteLine($"{nameof(AlarmMessage)} : {AlarmMessage}");
            Console.WriteLine($"{nameof(TimeToAlarm)} : {TimeToAlarm.ToString("c")}");
            Console.WriteLine($"{nameof(IsOutdated)} : {IsOutdated}");
            Console.WriteLine($"{nameof(PhoneNumber)} : {PhoneNumber}");
            Console.WriteLine();
        }
    }
}
