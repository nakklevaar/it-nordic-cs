using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
	interface IFlyingObject
	{
		int MaxHeight { get; }
		int CurrentHeigth { get; }
		void TakeUpper(int delta);
		void TakeLower(int delta);
	}
}
