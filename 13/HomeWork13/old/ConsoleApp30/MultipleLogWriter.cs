using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class MultipleLogWriter : Base
    {
        List<ILogWriter> List1;
        public MultipleLogWriter(List<ILogWriter> list)
        {
            List1 = list;
        }

        public override void VirtualFourMethod(string messageType, string message)
        {
            foreach (var writer in List1)
            {
                if (writer is ConsoleLogWriter)
                {
                    (writer as ConsoleLogWriter).VirtualFourMethod(messageType, message);
                }
                if (writer is FileLogWriter)
                {
                    (writer as FileLogWriter).VirtualFourMethod(messageType, message);
                }
            }
        }
    }
}
