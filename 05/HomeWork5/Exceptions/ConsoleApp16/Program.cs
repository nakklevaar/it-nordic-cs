using System;

namespace ConsoleApp2
{
    class Program
    {
        enum Objects
        {
            Circle = 1,
            Triangle,
            Rectangle
        }
        static void Main(string[] args)
        {
            Print();
            try
            {
                object result = Enum.Parse(typeof(Objects), Console.ReadLine(), true);
                if ((int)result > 4 || (int)result < 1)
                    throw new Exception("Используйте только числа от 1 до 4");
                switch (result)
                {
                    case Objects.Circle:
                        CircleMethod();
                        break;
                    case Objects.Triangle:
                        TriangleMethod();
                        break;
                    case Objects.Rectangle:
                        RectangleMethod();
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.GetType() + ": " + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.GetType() + ": " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType() + ": " + e.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void Print()
        {
            string[] obj = new string[3];
            for (int i = 0; i < 3; i++)
                obj[i] = ((Objects)i + 1).ToString() + $" или {i + 1}";
            Console.Write("Введите: " + string.Join(" - ", obj) + "\n");
        }
        static void CircleMethod()
        {
            Console.WriteLine("Введите длину диаметра круга: ");
            double d = double.Parse(Console.ReadLine());
            if (d <= 0)
                throw new Exception("Операция не имеет смысла, аргумент меньше или равен 0");
            double s = Math.PI * Math.Pow(d, 2) / 4;
            double p = 2 * Math.PI * d / 2;
            Console.WriteLine($"Площадь круга  = {Math.Round(s, 2)} \nПериметр круга = {Math.Round(p, 2)}");
        }
        static void TriangleMethod()
        {
            Console.WriteLine("Введите длину стороны треугольника: ");
            double a = double.Parse(Console.ReadLine());
            if (a <= 0)
                throw new Exception("Операция не имеет смысла, аргумент меньше или равен 0");
            double s = Math.Sqrt(3) / 4 * Math.Pow(a, 2);
            double p = 3 * a;
            Console.WriteLine($"Площадь равностороннего треугольника  = {Math.Round(s, 2)} \nПериметр равностороннего треугольника = {Math.Round(p, 2)}");
        }
        static void RectangleMethod()
        {
            Console.WriteLine("Введите длину длину прямоугольника: ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите длину ширину прямоугольника: ");
            double b = double.Parse(Console.ReadLine());
            if (a <= 0 || b <= 0)
                throw new Exception("Операция не имеет смысла, аргумент меньше или равен 0");
            double s = a * b;
            double p = (a + b) / 2;
            Console.WriteLine($"Площадь прямоугольника  = {Math.Round(s, 2)} \nПериметр прямоугольника = {Math.Round(p, 2)}");
        }
    }
}

