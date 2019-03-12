using System;
using System.Globalization;
using System.Threading;
namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            float number1 = 0;
            float number2 = 0;
            float number3 = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите сумму первоначального взноса в рублях: ");
                    number1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ежедневный процент дохода в виде десятичной дроби (1% = 0.01): ");
                    number2 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Введите желаемую сумму накопления в рублях: ");
                    number3 = float.Parse(Console.ReadLine());
                    if (number1 <= 0 || number2 <= 0 || number2 > 1 || number3 <= number1)
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
                    Console.WriteLine(e.GetType() + ": " + "Ошибка в логике");
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

            int days = 0;
            do
            {
                number1 = (number1 * number2) + number1;
                days++;
            }
            while (number1 < number3);

            Console.WriteLine($"Необходимое количество дней для накопления желаемой суммы {days}");
            Console.ReadKey();
        }
    }
}
