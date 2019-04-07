using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp30
{
    class FileLogWriter : Base, IDisposable
    {
        StreamWriter _logFileWriter;

        string LogFileName { get; set; }

        public FileLogWriter(string fileName = "text.txt")
        {
            LogFileName = fileName;

            _logFileWriter = new StreamWriter(
                File.Open(
                    LogFileName,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.Read));

            _logFileWriter.BaseStream.Seek(0, SeekOrigin.End);
        }

        public override void VirtualFourMethod(string messageType, string message)
        {
            _logFileWriter.WriteLine($"{DateTimeOffset.Now}    {messageType}   {message}");
            _logFileWriter.Flush();
            Dispose();
        }

        public void Dispose()
        {
            if (_logFileWriter != null)
                _logFileWriter.Dispose();
        }
    }
}
