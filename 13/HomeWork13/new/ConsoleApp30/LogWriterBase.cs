using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    abstract class LogWriterBase : ILogWriter
    {
        public void LogInfo(string message)
        {
            WriteLogRecord("LogInfo", message);
        }
        public void LogWarning(string message)
        {
            WriteLogRecord("LogWarning", message);
        }
        public void LogError(string message)
        {
            WriteLogRecord("LogError", message);
        }

        protected abstract void WriteLogRecord(string messageType, string message);
    }
}
