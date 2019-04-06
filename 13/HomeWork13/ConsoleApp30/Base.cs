using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class Base : ILogWriter
    {
        public void LogInfo(string message)
        {
            VirtualFourMethod("LogInfo", message);
        }
        public void LogWarning(string message)
        {
            VirtualFourMethod("LogWarning", message);
        }
        public void LogError(string message)
        {
            VirtualFourMethod("LogError", message);
        }

        public virtual void VirtualFourMethod (string messageType, string message)
        {
            Console.WriteLine($"{DateTimeOffset.Now}    {messageType}   {message}");
        }
    }
}
