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
            Colors[] array1 = new Colors[4];
            Colors?[] array2 = new Colors?[8];
            Console.WriteLine("Список возможных цветов: " + string.Join(" - ", Enum.GetNames(typeof(Colors))) + "\n");
            object color;
            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Введите {i + 1} цвет из четырех: ");
                    string d = Console.ReadLine();
                    try
                    {
                        int.Parse(d);
                    }
                    catch
                    {
                        if (Enum.TryParse(typeof(Colors), d, true, out color))
                        {
                            Console.WriteLine(color);
                            array1[i] = (Colors)color;
                            break;
                        }
                    }
                    Console.WriteLine("Ошибка, введите цвет правильно");
                }
            }
            int m = 0;
            for (int i = 0; i < 9; i++)
            {
                int sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    if ((Colors)i != array1[j])
                    {
                        sum++;
                    }
                }
                if (sum == 4)
                {
                    array2[m] = (Colors)i;
                    m++;
                }
            }
            Console.WriteLine();
            string s = "";
            foreach (var k in array1)
            {
                if (!s.Contains(k.ToString()))
                    s = s + k + " ";
            }
            Console.WriteLine("\n \n" + s + "\n");
            foreach (var k in array2)
            {
                if (k != null)
                    Console.Write(k + " ");
            }
            Console.ReadKey();
        }
    }
}

//ввести 4 цвета
//вывести введенные цвета
//вывести невошедшие цвета