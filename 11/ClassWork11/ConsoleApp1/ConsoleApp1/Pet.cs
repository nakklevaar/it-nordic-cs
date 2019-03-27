using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	class Pet
	{
		public string Kind;
		public string Name;
		public char Sex;
		public DateTimeOffset DateOfBirth;

		public int Age
		{
			get
			{
				TimeSpan age = DateTimeOffset.UtcNow.Subtract(DateOfBirth);
				return Convert.ToInt32(Math.Floor(age.TotalDays / 365.242));
			}
		}

		public string Descrition
		{
			get
			{
				return $"{Name} is a {Kind} ({Sex}) of {Age} years old.";
			}
		}

		public string ShortDescription
		{
			get
			{
				return $"{Name} is a {Kind}";
			}
		}

		public void WriteDescritpion(bool showFullDescription)
		{
			if (showFullDescription == true)
			{
				Console.WriteLine(Descrition);
			}
			else
			{
				Console.WriteLine(ShortDescription);
			}
		}
	}
}
