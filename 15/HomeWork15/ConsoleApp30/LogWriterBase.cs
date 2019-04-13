using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    abstract class LogWriterBase : ILogWriter
    {
        public void LogInfo(string message)
        {
            WriteLogRecord(LogRecordType.LogInfo, message);
        }
        public void LogWarning(string message)
        {
            WriteLogRecord(LogRecordType.LogWarning, message);
        }
        public void LogError(string message)
        {
            WriteLogRecord(LogRecordType.LogError, message);
        }

        protected abstract void WriteLogRecord(LogRecordType messageType, string message);
    }
}
