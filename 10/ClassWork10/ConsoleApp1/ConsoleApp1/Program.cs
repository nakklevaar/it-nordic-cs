using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Pet cat = new Pet()
			{
				Name = "Кошка",
				Age = 3,
				Kind = "Usual",
				Sex = 'M'
			};
			cat.Write();
			Pet dog = new Pet()
			{
				Name = "Собака",
				Age = 7,
				Kind = "Buldog",
				Sex = 'F'
			};
			dog.Write();
			Pet fish = new Pet()
			{
				Name = "Рыба",
				Age = 1,
				Kind = "Trout",
				Sex = ' '
			};
			fish.Write();
			Console.ReadKey();
		}
	}
}
