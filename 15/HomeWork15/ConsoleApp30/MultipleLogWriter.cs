using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class MultipleLogWriter : LogWriterBase
    {
        private List<ILogWriter> _list;
        public MultipleLogWriter(List<ILogWriter> list)
        {
            _list = list;
        }

        protected override void WriteLogRecord(LogRecordType messageType, string message)
        {
            foreach (var writer in _list)
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
