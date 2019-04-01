using System;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
			
			BaseDocument bd1 = new BaseDocument("Drive Licence", 234, DateTimeOffset.MinValue);
			BaseDocument bd2 = new BaseDocument("Drive Licence", 235, DateTimeOffset.MinValue);
			BaseDocument bd3 = new BaseDocument("Drive Licence", 236, DateTimeOffset.MinValue);

			Passport pass = new Passport(23, DateTimeOffset.Parse("03-04-2014"),"Russia", "Denis");

			BaseDocument[] array =
			{
				bd1,
				bd2,
				bd3,
				pass
			};

			for (int i = 0; i < array.Length; i++)
			{
				if(array[i] is Passport)
				{
					(array[i] as Passport).ChangeIssueDate(DateTimeOffset.Now);
				}
				Console.WriteLine(array[i].IssueDate);
			}

			bd1.WriteToConsole();
			pass.WriteToConsole();

			Console.ReadKey();
        }
    }
}
