using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
    class ReminderItem
    {
        DateTimeOffset AlarmDate { get; set; }
        string AlarmMessage { get; set; }

        TimeSpan TimeToAlarm { get { return AlarmDate.Subtract(DateTimeOffset.Now); } }

        bool IsOutdated { get { return AlarmDate <= DateTimeOffset.Now; } }

        public void WriteProperties()
        {
            Console.WriteLine($"{nameof(AlarmDate)} : {AlarmDate.ToString("MM/dd/yyyy HH:mm:ss")}");
            Console.WriteLine($"{nameof(AlarmMessage)} : {AlarmMessage}");
            Console.WriteLine($"{nameof(TimeToAlarm)} : {TimeToAlarm.ToString("c")}");
            Console.WriteLine($"{nameof(IsOutdated)} : {IsOutdated}");
        }

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }
    }
}
