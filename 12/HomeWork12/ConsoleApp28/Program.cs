using System;
using System.Collections.Generic;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            var ri = new ReminderItem(DateTimeOffset.Parse("03-05-2019"), "Забрать посылку");
            var pri = new PhoneReminderItem(DateTimeOffset.Now, "Поздороваться", "89876543210");
            var cri = new ChatReminderItem(DateTimeOffset.Parse("30-08-2007"), "аларм мессадж", "сельпо", "denis93");

            var List = new List<ReminderItem>
            {
                ri,
                pri,
                cri
            };

            foreach (var item in List)
            {   
                if (item is PhoneReminderItem)
                {
                    (item as PhoneReminderItem).WriteProperties();
                    continue;
                }

                if (item is ChatReminderItem)
                {
                    (item as ChatReminderItem).WriteProperties();
                    continue;
                }

                if (item is ReminderItem)
                {
                    (item as ReminderItem).WriteProperties();
                    continue;
                }
            }

            Console.ReadKey();
        }
    }
}
