using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
	class Plane : FlyingObject
	{
		public byte EnginesCount { get; private set; }

		public Plane(int maxHeigth, byte enginesCount) : base(maxHeigth)
		{
			EnginesCount = enginesCount;
			Console.WriteLine("It's a plane, welcome aboard");
		}

        public override void WriteAllProperties()
        {
            Console.WriteLine($"{nameof(EnginesCount)}: {EnginesCount} \n" +
                                $"{nameof(CurrentHeigth)}: {CurrentHeigth} \n" +
                                $"{nameof(MaxHeight)}: {MaxHeight} \n");
        }

        public override void WriteAllProperties2()
        {
            Console.WriteLine($"{nameof(EnginesCount)}: {EnginesCount} \n");
            base.WriteAllProperties2();
        }
    }
}
