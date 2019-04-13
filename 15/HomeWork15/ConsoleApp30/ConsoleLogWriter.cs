using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class ConsoleLogWriter : LogWriterBase
    {
        protected override void WriteLogRecord(LogRecordType messageType, string message)
        {
            Console.WriteLine($"{DateTimeOffset.Now}    {messageType}   {message}");
        }
    }
}
