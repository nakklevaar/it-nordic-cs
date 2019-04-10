using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var id1 = new Account<int>(3, "id1");
			var id2 = new Account<string>("4", "id2");
			var id3 = new Account<Guid>(Guid.NewGuid(), "id3");
			id1.WriteToProperties();
			id2.WriteToProperties();
			id3.WriteToProperties();
		}
	}
}
