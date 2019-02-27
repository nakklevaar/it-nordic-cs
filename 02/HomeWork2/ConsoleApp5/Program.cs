using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main()
        {
            bool y;
            do
            {
                y = false;
                try
                {
                        Console.WriteLine("Введите 1-ое число");
                        double chislo1 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите 2-ое число");
                        double chislo2 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите операцию: + , - , * , / , % , ^ .");
                        char chislo3 = char.Parse(Console.ReadLine());
                        switch (chislo3)
                        {
                            case '+':
                                Console.WriteLine("Результат: " + (chislo1 + chislo2));
                                break;
                            case '-':
                                Console.WriteLine("Результат: " + (chislo1 - chislo2));
                                break;
                            case '*':
                                Console.WriteLine("Результат: " + (chislo1 * chislo2));
                                break;
                            case '/':
                            if (chislo2 == 0)
                                Console.WriteLine("Деление на ноль");
                            else
                                Console.WriteLine("Результат: " + (chislo1 / chislo2));
                                break;
                            case '%':
                                Console.WriteLine("Результат: " + (chislo1 % chislo2));
                                break;
                            case '^':
                                Console.WriteLine("Результат: " + Math.Pow(chislo1, chislo2));
                                break;
                            default:
                                Console.WriteLine("Используйте один из представленных типов операций: \n + , - , * , / , % , ^ .");
                                Console.WriteLine("________________________________\n");
                                y = true;
                                break;
                        }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка форматов");
                    Console.WriteLine("________________________________\n");
                    y = true;
                }
                //catch (DivideByZeroException)
                //{
                //    Console.WriteLine("Деление на 0");
                //    Console.WriteLine("________________________________\n");
                //    y = true;
                //}
                y = End(y);
            } while (y == true);
            Console.WriteLine("Конец");
            Console.ReadKey();
        }
       static bool End (bool y)
        {
            string endslovo;
            if (y == false)
            {
                Console.WriteLine("________________________________\n");
                Console.WriteLine("Считать далее? 'Да' для продолжения, любая кнопка для выхода");
                endslovo = Console.ReadLine().ToLower();
                if (endslovo == "да")
                {
                    y = true;
                }
                else
                    y = false;
            }
            return y;
        }
    }
}
