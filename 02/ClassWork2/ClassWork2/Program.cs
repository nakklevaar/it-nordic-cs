using System;

namespace ClassWork2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введи радиус круга");
			double r = double.Parse(Console.ReadLine());
			double s = Math.PI * Math.Pow(r,2);
			Console.WriteLine("Площадь круга: " + s);
			Console.ReadKey();
		}
	}
}
