using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp27
{
    class Person
    {
        public string Name;
        int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (_age > 0 && _age < 140)
                {
                    _age = value;
                }
                else throw new IndexOutOfRangeException();
            }
        }
        public void PrintPlus4()
        {
            Console.WriteLine($"Name: {Name}, age  in 4 years: {Age + 4}");
        }
    }
}
