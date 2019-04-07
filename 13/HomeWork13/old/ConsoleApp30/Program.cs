using System;
using System.Collections.Generic;

namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogWriter p1 = new FileLogWriter();
            ILogWriter p2 = new ConsoleLogWriter();

            List<ILogWriter> list = new List<ILogWriter>
            { p1, p2 };

            var p3 = new MultipleLogWriter(list);
            p3.LogError("poshaluysta");
        }
    }
}
