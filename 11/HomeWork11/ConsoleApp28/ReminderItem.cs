using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
    class ReminderItem
    {
        DateTimeOffset AlarmDate { get; set; }
        string AlarmMessage
        {
            get
            {
                return $"Будильник установлен на {AlarmDate.ToString("MM/dd/yyyy HH:mm:ss")}";
            }
        }

        TimeSpan TimeToAlarm
        {
            get
            {
                return AlarmDate.Subtract(DateTimeOffset.Now);
            }
        }

        bool IsOutdated
        {
            get
            {
                if (AlarmDate <= DateTimeOffset.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public void WriteProperties()
        {
            Console.WriteLine($"{nameof(AlarmDate)} : {AlarmDate.ToString("MM/dd/yyyy HH:mm:ss")}");
            Console.WriteLine($"{nameof(AlarmMessage)} : {AlarmMessage}");
            Console.WriteLine($"{nameof(TimeToAlarm)} : {TimeToAlarm.ToString("c")}");
            Console.WriteLine($"{nameof(IsOutdated)} : {IsOutdated}");
        }

        public ReminderItem(DateTimeOffset AlarmDate)
        {
            this.AlarmDate = AlarmDate;
            Console.WriteLine(AlarmMessage);
        }
    }
}
