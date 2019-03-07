using System;

namespace ConsoleApp2
{
    class Program
    {
        enum Colors
        {
            Black,
            Blue,
            Cyan,
            Grey,
            Green,
            Magenta,
            Red,
            White,
            Yellow
        }
        static void Main(string[] args)
        {
            Colors[] chosen = new Colors[4];
            Colors?[] notChosen = new Colors?[8];
            Input(ref chosen, ref notChosen);
            Calc(ref chosen, ref notChosen);
            Print(chosen, notChosen);
            Console.ReadKey();
        }

        static void Input(ref Colors[] chosen, ref Colors?[] notChosen)
        {

            Console.WriteLine("Список возможных цветов: " + string.Join(" - ", Enum.GetNames(typeof(Colors))) + "\n");
            object color;
            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Введите {i + 1} цвет из четырех: ");
                    string value = Console.ReadLine();
                    if (!int.TryParse(value, out int ignoreMe) && Enum.TryParse(typeof(Colors), value, true, out color))
                    {
                        chosen[i] = (Colors)color;
                        break;
                    }
                    Console.WriteLine("Ошибка, введите цвет правильно.");
                }
            }
        }
        static void Calc(ref Colors[] chosen, ref Colors?[] notChosen)
        {
            int m = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((Colors)i == chosen[j])
                        break;
                    else if (j == 3)
                    {
                        notChosen[m] = (Colors)i;
                        m++;
                    }
                }
            }
        }
        static void Print(Colors[] chosen, Colors?[] notChosen)
        {
            Console.WriteLine();
            string s = "";
            foreach (var k in chosen)
            {
                if (!s.Contains(k.ToString()))
                    s = s + k + " ";
            }
            Console.WriteLine("\n \n" + "Избранные цвета: " + s + "\n");
            Console.Write("Не вошедшее: ");
            foreach (var k in notChosen)
            {
                if (k != null)
                    Console.Write(k + " ");
            }
        }
    }
}

//ввести 4 цвета
//вывести введенные цвета
//вывести невошедшие цвета
