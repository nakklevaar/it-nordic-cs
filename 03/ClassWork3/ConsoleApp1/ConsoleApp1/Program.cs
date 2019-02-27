using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			//var num1 = 3.14f;
			//var num2 = 1d;
			//var num3 = 49l;
			//var num4 = (byte)255;
			//Console.WriteLine(num1.GetType());
			//Console.WriteLine(num2.GetType());
			//Console.WriteLine(num3.GetType());
			//Console.WriteLine(num4.GetType());
			//Console.ReadKey();
			//Console.WriteLine($"{default(int)}");
			string [] array = new string[5];
			for (int i = 0; i < array.Length; i++)
			{
				Console.WriteLine($"Введите число {i + 1}");
				array[i] = Console.ReadLine();
			}
			for (int i = 0; i < array.Length; i++)
			{
				Console.WriteLine(array[i]);
			}
			Console.ReadKey();
		}
	}
}
