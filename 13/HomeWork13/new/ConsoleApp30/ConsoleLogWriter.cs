using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class ConsoleLogWriter : LogWriterBase
    {
        protected override void WriteLogRecord(string messageType, string message)
        {
            Console.WriteLine($"{DateTimeOffset.Now}    {messageType}   {message}");
        }
    }
}
