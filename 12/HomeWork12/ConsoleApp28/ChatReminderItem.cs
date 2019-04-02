using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
    class ChatReminderItem : ReminderItem
    {
        string ChatName { get; set; }
        string AccountName { get; set; }

        public ChatReminderItem(DateTimeOffset alarmDate, string alarmMessage, string chatName, string accountName) : base(alarmDate, alarmMessage) 
        {
            ChatName = chatName;
            AccountName = accountName;
        }

        public override void WriteProperties()
        {
            Console.WriteLine(GetType().Name);
            Console.WriteLine($"{nameof(AlarmDate)} : {AlarmDate.ToString("MM/dd/yyyy HH:mm:ss")}");
            Console.WriteLine($"{nameof(AlarmMessage)} : {AlarmMessage}");
            Console.WriteLine($"{nameof(TimeToAlarm)} : {TimeToAlarm.ToString("c")}");
            Console.WriteLine($"{nameof(IsOutdated)} : {IsOutdated}");
            Console.WriteLine($"{nameof(ChatName)} : {ChatName}");
            Console.WriteLine($"{nameof(AccountName)} : {AccountName}");
            Console.WriteLine();
        }
    }
}
