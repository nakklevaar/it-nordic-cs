using System;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 3, 1, 4, 2 };
			string x = "test";
			Met(arr, x);
			Console.WriteLine(string.Join(' ', arr));
			Console.WriteLine(x);
		}
		static void Met(int[] arr, string x)
		{
			arr[3] = 10;
			x = x+ "trggfgf";
		}
	}
}
