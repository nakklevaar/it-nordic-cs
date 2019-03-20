using System;
using System.Diagnostics;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 20; i++)
			{
				int[] initialArray = GetTestArray(2*i*1000, 1_000_000);
				Stopwatch stopwatch = new Stopwatch();
				//WriteArrayState("Initial state:", initialArray);
				int[] bubbleSortedArray = (int[])initialArray.Clone();
				stopwatch.Start();
				BubleSort(bubbleSortedArray);
				stopwatch.Stop();
				Console.WriteLine($"Bubble sort done in {stopwatch.ElapsedMilliseconds} ms): ");
				int[] dotNetSort = (int[])initialArray.Clone();
				stopwatch.Restart();
				Array.Sort(dotNetSort);
				Console.WriteLine($".Net sort done in {stopwatch.ElapsedMilliseconds} ms \n");
				//WriteArrayState("Bubbled state:", bubbleSortedArray);
			}
		}
		static int[] GetTestArray(int length,int maxValue)
		{
			var arr = new int[length];

			var rnd = new Random();
			for (var i = 0; i < arr.Length; i++)
			{
				arr[i] = rnd.Next(maxValue);
			}

			return arr;
		}
		static void WriteArrayState(string message, int[] arr)
		{
			Console.WriteLine(message);
			for (var i = 0; i < arr.Length; i++)
			{
				Console.WriteLine(arr[i]);
			}
		}
		static void BubleSort(int[] arr)
		{
			for (int i = 0; i < arr.Length-1; i++)
			{
				for (int j = 0; j < arr.Length-1-i; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}

			}
		}
	}
}
