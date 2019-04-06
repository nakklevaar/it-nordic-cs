using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
	public class Helicopter : FlyingObject, IFlyingObject
	{
		public byte BladesCount { get; private set; }

		public Helicopter(int maxHeigth, byte bladesCount) : base(maxHeigth)
		{
			BladesCount = bladesCount;
			Console.WriteLine("It's a helicopter, welcome aboard");
		}

		public override void WriteAllProperties()
		{
			Console.WriteLine($"{nameof(BladesCount)}: {BladesCount} \n" +
								$"{nameof(CurrentHeigth)}: {CurrentHeigth} \n" +
								$"{nameof(MaxHeight)}: {MaxHeight} \n");
		}

		public override void WriteAllProperties2()
		{
			Console.WriteLine($"{nameof(BladesCount)}: {BladesCount}");
			base.WriteAllProperties2();
		}
	}
}
