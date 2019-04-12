using System;
using System.Collections.Generic;

namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogWriter p1 = FileLogWriter.GetInitialize();
            ILogWriter p2 = ConsoleLogWriter.GetInitialize();


            var p3 = MultipleLogWriter.GetInitialize();
            p3.List.Add(p2);
            p3.List.Add(p1);
            p3.LogError("poshaluysta");
        }
    }
}
