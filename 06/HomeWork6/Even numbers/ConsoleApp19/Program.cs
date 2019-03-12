using System;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            while (true)
            {
                Console.WriteLine("Введите натуральное число до " + int.MaxValue);
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1)
                        throw new ArgumentOutOfRangeException();
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.GetType() + ": " + e.Message);
                    Console.WriteLine("Повторите попытку!\n");
                    continue;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.GetType() + ": " + e.Message);
                    Console.WriteLine("Повторите попытку!\n");
                    continue;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.GetType() + ": " + "Ненатуральное число");
                    Console.WriteLine("Повторите попытку!\n");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetType() + "Непредвиденная ошибка");
                    throw;
                }

                break;
            }

            int sum = 0;
            foreach (char k in number.ToString())
            {
                if (k % 2 == 0)
                    sum++;
            }

            Console.WriteLine($"Четных цифр: {sum}");
            Console.ReadKey();
        }
    }
}
