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
				if (value > 0 && value < 140)
				{
					_age = value;
				}
				else throw new ArgumentOutOfRangeException();
			}
		}
		public void PrintAgePlusFour()
		{
			Console.WriteLine($"Name: {Name}, age  in 4 years: {Age + 4}");
		}
	}
}
