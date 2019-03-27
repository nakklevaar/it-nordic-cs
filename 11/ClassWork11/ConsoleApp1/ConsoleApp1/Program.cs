using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Pet p1 = new Pet()
			{
				Name = "Cat",
				DateOfBirth=DateTimeOffset.Parse("2010-03-04"),
				Kind = "Usual",
				Sex = 'M'
			};
			p1.WriteDescritpion(true);

			Pet p2 = new Pet()
			{
				Name = "Dog",
				DateOfBirth = DateTimeOffset.Parse("2013-11-07"),
				Kind = "Buldog",
				Sex = 'F'
			};
			p2.WriteDescritpion(false);

			Console.ReadKey();
		}
	}
}
