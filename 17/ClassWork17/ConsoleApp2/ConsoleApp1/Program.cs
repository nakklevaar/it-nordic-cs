using System;
using System.IO;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var rnd = new RandomDataGenerator();

			rnd.RandomDataGenerated += RandomData_Generated;
			rnd.RandomDataGenerationDone += RandomData_Done;

			byte[] arr;
			arr = rnd.GetRandomData(1000, 100);
			string arrString = Convert.ToBase64String(arr);
			Console.WriteLine(arrString);

			File.WriteAllBytes("text.txt",arr);
		}

		public static void RandomData_Generated(int bytesDone, int totalBytes)
		{
			Console.WriteLine($"BytesDone: {bytesDone}, of {totalBytes}");
		}

		public static void RandomData_Done(object sender, EventArgs e)
		{
			Console.WriteLine($"Work Done");
		}
	}
}
