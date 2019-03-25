using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	class Pet
	{
		public string Kind;
		public string Name;
		char _sex;
		public char Sex
		{
			get
			{
				return _sex;
			}
			set
			{
				if (value == 'F' || value == 'M')
					_sex = value;
				else _sex = '?';
			}
		}
		public int Age;
		public void Write()
		{
			Console.WriteLine($"Name: {Name}, Age: {Age}, Kind: {Kind}, Sex: {Sex}");
		}
	}
}
