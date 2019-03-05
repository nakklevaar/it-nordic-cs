using System;
using System.Globalization;
using System.Threading;
using System.Text;
namespace ConsoleApp11
{
    [Flags]
    enum Bags : byte
    {
        bag1 = 0x1,
        bag5 = 0x1 << 1,
        bag20 = 0x1 << 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            InitializeConsole();
            ConsoleColor defaultColor = Console.ForegroundColor;
            double v1;
            while (true)
            {
                Console.Write("Какой объем сока (в литрах) требуется упаковать? - ");
                if (double.TryParse(Console.ReadLine(), out v1))
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Wrong value! ");
                Console.ForegroundColor = defaultColor;
            }
            int v = (int)Math.Ceiling(v1);
            Bags usedBag = 0;
            int sum20 = 0;
            int sum5 = 0;
            int sum1 = 0;
            Calc(v, ref sum20, ref sum5, ref sum1, ref usedBag);
            PrintResult(usedBag, sum1, sum5, sum20, defaultColor, (byte)usedBag);
            Console.ReadKey();
        }
        static void Calc(int v, ref int sum20, ref int sum5, ref int sum1, ref Bags usedBag)
        {
            Console.WriteLine();
            if (v - 20 >= 0)
            {
                usedBag = usedBag | Bags.bag20;
                while (v - 20 >= 0)
                {
                    v -= 20;
                    sum20++;
                }
                // WriteByteValueWithBits((byte)Bags.bag20);
                WriteByteValueWithBits((byte)usedBag);
            }
            if (v - 5 >= 0)
            {
                usedBag = usedBag | Bags.bag5;
                while (v - 5 >= 0)
                {
                    v -= 5;
                    sum5++;
                }
                // WriteByteValueWithBits((byte)Bags.bag5);
                WriteByteValueWithBits((byte)usedBag);
            }
            if (v - 1 >= 0)
            {
                usedBag = usedBag | Bags.bag1;
                while (v - 1 >= 0)
                {
                    v -= 1;
                    sum1++;
                }
                //WriteByteValueWithBits((byte)Bags.bag1);
                WriteByteValueWithBits((byte)usedBag);
            }
        }
        static void WriteByteValueWithBits(byte value)
        {
            Console.WriteLine(
                "0x{0}\t({1})\t{2}",
                value.ToString("x").PadLeft(2, '0'),
                Convert.ToString(value, 2).PadLeft(8, '0'),
                value.ToString().PadLeft(3, '0'));
        }
        static void PrintResult(Bags usedBag, int sum1, int sum5, int sum20, ConsoleColor defaultColor, byte value)
        {
            Console.WriteLine();
            if ((usedBag & Bags.bag20) == Bags.bag20)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("20 литров : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(sum20);
            }
            if ((usedBag & Bags.bag5) == Bags.bag5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("5 литров : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(sum5);
            }
            if ((usedBag & Bags.bag1) == Bags.bag1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1 литров : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(sum1);
                Console.ForegroundColor = defaultColor;
            }
            Console.Write("int значение = ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(value);
            Console.ForegroundColor = defaultColor;
        }
        private static void InitializeConsole()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
        }
    }
}
