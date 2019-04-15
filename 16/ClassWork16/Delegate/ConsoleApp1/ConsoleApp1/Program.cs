using System;

namespace ConsoleApp1
{
	class Program
	{
		delegate int fd(int a);

		static void Main(string[] args)
		{
			var p = new Circle(1.5);
			Console.WriteLine(p.Calculate((double r) => 2 * Math.PI * r));
			fd f  = new fd((int a) =>
			{				
				return a;
			});


			var s = new Calculation(new[] { 1, 2, 3, 4, 5 });
			int result = s.CalcSingleValue(
				(int[] array) =>
				{
					int x=0;
					foreach (var m in array)
						x += m;
					x /= array.Length;
					return x;
				}
			);
			Console.WriteLine(result);

			Console.WriteLine(f(120));
		}
	}
}
