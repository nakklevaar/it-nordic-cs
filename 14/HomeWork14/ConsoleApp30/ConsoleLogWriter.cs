using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class ConsoleLogWriter : LogWriterBase
    {
        private static ConsoleLogWriter initialize;

        private ConsoleLogWriter()
        {

        }

        public static ConsoleLogWriter GetInitialize()
        {
            if (initialize == null)
            {
                initialize = new ConsoleLogWriter();
            }

            return initialize;
        }

        protected override void WriteLogRecord(LogRecordType messageType, string message)
        {
            Console.WriteLine($"{DateTimeOffset.Now}    {messageType}   {message}");
        }
    }
}
