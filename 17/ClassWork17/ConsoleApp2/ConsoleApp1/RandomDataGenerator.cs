using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public delegate void RandomDataGeneratedHandler(int bytesDone, int totalBytes);

	class RandomDataGenerator
	{
		public event RandomDataGeneratedHandler RandomDataGenerated;
		public event EventHandler RandomDataGenerationDone;

	
		public byte[] GetRandomData(int dataSize, int bytesDoneRaiseEvent)
		{
			byte[] array = new byte[dataSize];

			for (int i =0; i<array.Length; i++)
			{
				array[i] = (byte)new Random().Next(256);
				if ((i+1) % bytesDoneRaiseEvent == 0)
				{
					RandomDataGenerated(i, array.Length);
				}
			}

			RandomDataGenerationDone(this, EventArgs.Empty);
			return array; 
		}
	}
}
