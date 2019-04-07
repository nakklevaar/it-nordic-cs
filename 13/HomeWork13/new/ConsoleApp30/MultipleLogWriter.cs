using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class MultipleLogWriter : LogWriterBase
    {
        List<ILogWriter> List1;
        public MultipleLogWriter(List<ILogWriter> list)
        {
            List1 = list;
        }

        protected override void WriteLogRecord(string messageType, string message)
        {
            foreach (var writer in List1)
            {
                switch (messageType)
                {
                    case "LogInfo":
                        writer.LogInfo(message);
                        break;
                    case "LogWarning":
                        writer.LogWarning(message);
                        break;
                    case "LogError":
                        writer.LogError(message);
                        break;
                }
            }
        }
    }
}
