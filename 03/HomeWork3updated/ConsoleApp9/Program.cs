using System;
using System.Globalization;
using System.Threading;
using System.Text;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeConsole();
            ConsoleColor defaultColor = Console.ForegroundColor;
            string[][] array = ArrayCreate();
            array = ArrayInput(array, defaultColor);
            ArrayOutput(array, defaultColor);
            Console.ReadKey();
        }
        private static void InitializeConsole()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
        }
        static string[][] ArrayCreate()
        {
            string[][] array = new string[3][];
            array[0] = new string[2];
            array[1] = new string[2];
            array[2] = new string[2];
            return array;
        }
        static string[][] ArrayInput(string[][] array, ConsoleColor defaultColor)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("Enter your name: ");
                        array[j][i] = Console.ReadLine();
                    }
                    else
                    {
                        int z = 0;
                        while (true)
                        {
                            Console.Write("Enter your age: ");
                            if (int.TryParse(Console.ReadLine(), out z))
                            {
                                array[j][i] = (z + 4).ToString();
                                Console.WriteLine();
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Wrong value! ");
                            Console.ForegroundColor = defaultColor;
                        }
                    }

                }
            }
            return array;
        }
        static void ArrayOutput(string[][] array, ConsoleColor defaultColor)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"Name: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{ array[j][i]}");
                        Console.ForegroundColor = defaultColor;
                    }
                    else
                    {
                        Console.Write($", age in 4 years: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{ array[j][i]}");
                        Console.ForegroundColor = defaultColor;
                    }
                }
            }
        }
    }
}