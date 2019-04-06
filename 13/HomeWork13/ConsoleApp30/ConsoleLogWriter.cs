using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class ConsoleLogWriter : Base
    {
        public override void VirtualFourMethod(string messageType, string message)
        {
            Console.WriteLine($"{DateTimeOffset.Now}    {messageType}   {message}");
        }
    }
}
