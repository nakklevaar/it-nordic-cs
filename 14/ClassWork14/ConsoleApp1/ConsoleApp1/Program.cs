using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var err = new ErrorList("type");
			err.Add("type error1");
			err.Add("type error12");
			err.Add("type error1235");

			err.WriteToConsole();
		}
	}
}
