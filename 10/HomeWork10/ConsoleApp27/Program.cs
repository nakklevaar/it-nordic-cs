using System;
using System.Collections.Generic;
namespace ConsoleApp27
{
	class Program
	{
		static void Main(string[] args)
		{
			var PersonList = new List<Person>(3);

			for (int i = 0; i < 3; i++)
			{
				PersonList.Add(new Person());
				Console.Write("Введите имя: ");
				PersonList[i].Name = Console.ReadLine();
				while (true)
				{
					Console.Write("Введите возраст(полных лет): ");
					if (int.TryParse(Console.ReadLine(), out int value))
					{
						PersonList[i].Age = value;
						break;
					}
					Console.Write("Ошибка\n");
				}
			}

			foreach (var k in PersonList)
			{
				k.PrintAgePlusFour();
			}
			Console.ReadKey();
		}
	}
}
