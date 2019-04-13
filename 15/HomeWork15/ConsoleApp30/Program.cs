using System;
using System.Collections.Generic;

namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {


            LogWriterFactory f1 = LogWriterFactory.GetInitialize();
            var example1 = f1.GetLogWriter<ILogWriter>(LogWriters.ConsoleLogWriter);
            var example2 = f1.GetLogWriter<ILogWriter>(LogWriters.FileLogWriter, "test.txt");

            List<ILogWriter> list = new List<ILogWriter>() { example1, example2 };
            var example3 = f1.GetLogWriter<ILogWriter>(LogWriters.MultipleLogWriter, list: list);

            example1.LogInfo("working example1");
            example2.LogWarning("working example2");
            example3.LogError("working example3");

            FileLogWriter._logFileWriter.Close();

            //////////////////////////////
            Console.WriteLine("//////////////////////////////");
            //////////////////////////////
            
            f1.MyBestDecision("test.txt", list);
            var ex4 = f1.ConsoleLog;
            var ex5 = f1.FileLog;
            var ex6 = f1.MultipleLog;

            ex4.LogInfo("working example4");
            ex5.LogWarning("working example5");
            ex6.LogError("working example6");

        }
    }
}