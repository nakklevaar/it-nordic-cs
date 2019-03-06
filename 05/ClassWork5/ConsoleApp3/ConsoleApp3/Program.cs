using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите число: ");
			try
			{
				int a = int.Parse(Console.ReadLine());
				if (a > 3)
					throw new Exception("ОШИБКА");
				Console.WriteLine("Число " + ((a < 0) ? "отрицательное" : "неотрицательное"));
			}
			catch (FormatException e)
			{
				Console.WriteLine($"{e.GetType()},{e.Message}");
				
			}
			finally
			{
				Console.WriteLine("fdfdf");
			}
			Console.ReadKey();
		}
	}
}
