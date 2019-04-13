using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class LogWriterFactory
    {
        private static LogWriterFactory initialize;

        private LogWriterFactory()
        {

        }

        public static LogWriterFactory GetInitialize()
        {
            if (initialize == null)
            {
                initialize = new LogWriterFactory();
            }
            return initialize;
        }

        public ILogWriter GetLogWriter<T>(LogWriters logWriterType, string filename = null, List<ILogWriter> list = null) where T : ILogWriter
        {
            switch (logWriterType)
            {
                case LogWriters.ConsoleLogWriter:
                    return new ConsoleLogWriter();

                case LogWriters.FileLogWriter:
                    return new FileLogWriter(filename);

                case LogWriters.MultipleLogWriter:
                    return new MultipleLogWriter(list);
            }

            throw new Exception();
        }

        //////////////////////////////////////////////////////////////////////////////////////


        private string _filename;
        private List<ILogWriter> _writers;

        public void MyBestDecision(string filename, List<ILogWriter> writers)
        {
            _filename = filename;
            _writers = writers;
        }

        private Func<LogWriters, string, List<ILogWriter>, ILogWriter> NewWriter { get { return GetLogWriter<ILogWriter>; } }

        public ILogWriter ConsoleLog { get { return NewWriter(LogWriters.ConsoleLogWriter, null, null); } }

        public ILogWriter FileLog { get { return NewWriter(LogWriters.FileLogWriter, _filename, null); } }

        public ILogWriter MultipleLog { get { return NewWriter(LogWriters.MultipleLogWriter, null, _writers); } }
    }
}
