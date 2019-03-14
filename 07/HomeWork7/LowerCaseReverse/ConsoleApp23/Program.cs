using System;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите непустую строку: ");
            string text = string.Empty;

            while (true)
            {
                text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.Write("Вы ввели пустую строку :(Попробуйте ещё раз: ");
                }
                break;
            }

            text = text.Trim();
            char[] letters = text.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
                letters[i] = char.ToLower(letters[i]);
            Array.Reverse(letters);
            Console.WriteLine(string.Concat(letters));
            Console.ReadKey();
        }
    }
}
