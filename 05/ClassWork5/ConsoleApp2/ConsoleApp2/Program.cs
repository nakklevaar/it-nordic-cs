using System;

namespace ConsoleApp2
{
	class Program
	{
		enum Colors
		{
			Black=0x0,
			Blue=0x1,
			Cyan= 0x1 << 1,
			Grey= 0x1 << 2,
			Green= 0x1 << 3,
			Magenta= 0x1 << 4,
			Red= 0x1 << 5,
			White= 0x1 << 6,
			Yellow= 0x1 << 7
		}
		static void WriteByteValueWithBits(byte value)
		{
			Console.WriteLine(
				"0x{0}\t({1})\t{2}",
				value.ToString("x").PadLeft(2, '0'),
				Convert.ToString(value, 2).PadLeft(8, '0'),
				value.ToString().PadLeft(3, '0'));
		}
		static void Main(string[] args)
		{
			Colors notColor = 0;
			object color;
			for (int i = 0; i < 4; i++)
			{
				Console.WriteLine($"Введите {i} из четырех: ");
				if (Enum.TryParse(typeof(Colors), Console.ReadLine(), true, out color))
					notColor = notColor | (Colors)color;
			}
			WriteByteValueWithBits((byte)notColor);
			//int?[] array = new int?[4];
			for(int i = 0; i < 9; i++)
			{
				if ((notColor & (Colors)i) == (Colors)i)

			}
			Console.ReadKey();
		}
	}
}

//ввести 4 цвета
//вывести введенные цвета
//вывести невошедшие цвета