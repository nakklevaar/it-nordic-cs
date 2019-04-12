using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp30
{
    class FileLogWriter : LogWriterBase, IDisposable
    {
        StreamWriter _logFileWriter;

        private readonly string _fileName = "test.txt";

        private static FileLogWriter initialize;

        private FileLogWriter()
        {
            
        }

        public static FileLogWriter GetInitialize()
        {
            if (initialize == null)
            {
                initialize = new FileLogWriter();
            }

            return initialize;
        }

        protected override void WriteLogRecord(LogRecordType messageType, string message)
        {
            OpenStream();
            _logFileWriter.WriteLine($"{DateTimeOffset.Now}    {messageType}   {message}");
            _logFileWriter.Flush();
        }

        private void OpenStream()
        {
            _logFileWriter = new StreamWriter(
                File.Open(
                    _fileName,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.Read));

            _logFileWriter.BaseStream.Seek(0, SeekOrigin.End);
        }

        public void Dispose()
        {
            if (_logFileWriter != null)
                _logFileWriter.Dispose();
        }
    }
}
