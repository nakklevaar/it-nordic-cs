using System;
using System.Collections.Generic;

namespace ConsoleApp28
{
    class Program
    {
		static void Main()
		{
			Helicopter hel = new Helicopter(235, 3);
			hel.TakeUpper(16);
			hel.TakeUpper(30);
			hel.TakeLower(11);
			hel.WriteAllProperties();
			hel.WriteAllProperties2();
			Console.ReadKey();
		}
    }
}
