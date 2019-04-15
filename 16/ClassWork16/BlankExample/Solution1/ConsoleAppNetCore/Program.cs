using System;
using ClassLibraryForNetCore;
using ClassLibraryForNetStandart;

namespace ConsoleAppNetCore
{
	class Program
	{
		static void Main(string[] args)
		{
			var instance1 = new NetCoreClass();
			var instance2 = new NetStandartClass();
		}
	}
}
