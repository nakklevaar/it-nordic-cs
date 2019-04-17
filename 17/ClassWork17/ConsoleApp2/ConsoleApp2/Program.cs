using System;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			var worker = new Worker();

			worker.WorkPerformed += Worker_WorkPerformed;
			worker.WorkComplited += Worker_WorkComplited;
			worker.DoWork(6, WorkType.Work);
		}

		private static void Worker_WorkComplited(object sender, EventArgs e)
		{
			Console.WriteLine("Work Done " + sender.GetHashCode());
		}

		private static void Worker_WorkPerformed(int hours, WorkType workType)
		{
			Console.WriteLine($"Work of type {workType}: {hours} hours");
		}

		//	WorkPerformedEventHandler del1 = WorkPerformed1;
		//	WorkPerformedEventHandler del2 = WorkPerformed2;
		//	WorkPerformedEventHandler del3 = WorkPerformed3;

		//	del1 += del2 + del3;

		//	int result = del1(8, WorkType.DoNothing);

		//	Console.WriteLine($"Result: {result} hours");
		//}

		//private static int WorkPerformed1(int hours, WorkType workType)
		//{
		//	Console.WriteLine($"WorkPerformed1: Work of type {workType}: {hours} hours");
		//	return hours + 1;
		//}

		//private static int WorkPerformed2(int hours, WorkType workType)
		//{
		//	Console.WriteLine($"WorkPerformed2: Work of type {workType}: {hours} hours");
		//	return hours + 2;
		//}

		//private static int WorkPerformed3(int hours, WorkType workType)
		//{
		//	Console.WriteLine($"WorkPerformed3: Work of type {workType}: {hours} hours");
		//	return hours + 3;
		//}

	}
}
