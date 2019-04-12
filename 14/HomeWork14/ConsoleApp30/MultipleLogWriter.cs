using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class MultipleLogWriter : LogWriterBase
    {
        public List<ILogWriter> List { get; set; } = new List<ILogWriter>();

        private static MultipleLogWriter initialize;

        private MultipleLogWriter()
        {
        }

        public static MultipleLogWriter GetInitialize()
        {
            if (initialize == null)
            {
                initialize = new MultipleLogWriter();
            }

            return initialize;
        }

        protected override void WriteLogRecord(LogRecordType messageType, string message)
        {
            foreach (var writer in List)
            {
                switch (messageType)
                {
                    case LogRecordType.LogInfo:
                        writer.LogInfo(message);
                        break;
                    case LogRecordType.LogWarning:
                        writer.LogWarning(message);
                        break;
                    case LogRecordType.LogError:
                        writer.LogError(message);
                        break;
                }
            }
        }
    }
}
