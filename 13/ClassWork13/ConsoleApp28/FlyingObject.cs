using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
	public abstract class FlyingObject:IFlyingObject
	{
		public int MaxHeight { get; private set; }
		public int CurrentHeigth { get; private set; }

		public FlyingObject(int maxHeigth)
		{
			MaxHeight = maxHeigth;
			CurrentHeigth = 0;
		}

		public void TakeUpper(int delta)
		{
			if (delta <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			if (CurrentHeigth + delta > MaxHeight)
			{
				CurrentHeigth = MaxHeight;
				return;
			}

			CurrentHeigth += delta;
		}

		public void TakeLower(int delta)
		{
			if (delta <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			if (CurrentHeigth - delta > 0)
			{
				CurrentHeigth -= delta;
				return;
			}

			if (CurrentHeigth - delta == 0)
			{
				CurrentHeigth = 0;
				return;
			}

			if (CurrentHeigth - delta < 0)
			{
				throw new InvalidOperationException("Crash!");
			}
		}

		public abstract void WriteAllProperties();
		public virtual void WriteAllProperties2()
		{
			Console.WriteLine(
				$"{nameof(CurrentHeigth)}: {CurrentHeigth} \n" +
				$"{nameof(MaxHeight)}: {MaxHeight} \n");
		}
	}
}
