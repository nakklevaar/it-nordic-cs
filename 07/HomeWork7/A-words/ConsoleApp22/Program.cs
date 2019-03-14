using System;
using System.Globalization;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку из нескольких русских слов: ");
            string text = string.Empty;
            char[] ch = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            bool ok = true;

            while (true)
            {
                text = Console.ReadLine();

                foreach (var k in ch)
                {
                    if (text.Contains(k))
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok && (text.Contains(' ') || text.Contains(',')) && !string.IsNullOrWhiteSpace(text))
                {
                    break;
                }

                Console.Write("\nОшибка, неправильно введено значение. Повторите попытку:");
            }

            string[] words = text.Split(new char[] { ' ', ',', '.', ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int aWordCount = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith("а", true, CultureInfo.InvariantCulture))
                    aWordCount++;
            }

            Console.WriteLine($"\nКоличество слов, начинающихся с буквы 'А': {aWordCount}");
            Console.ReadKey();
        }
    }
}
