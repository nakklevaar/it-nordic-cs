using System;

namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "   lorem    ipsum    dolor      sit   amet  ";
            Method1(text);
            Method2(text);
            Method3(text);
            Console.ReadKey();
        }

        static void Method1(string text)
        {
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            text = string.Join(' ', words);
            string necessaryWord = "ipsum";
            text = text.Replace(necessaryWord, necessaryWord.ToUpper());
            Console.WriteLine("Method1:\n" + text);
        }

        static void Method2(string text)
        {
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words[1].Length; i++)
                words[1] = words[1].Replace(words[1][i], char.ToUpper(words[1][i]));
            //   words[1][i] = char.ToUpper(words[1][i]);
            text = string.Join(' ', words);
            Console.WriteLine("Method2:\n" + text);
        }

        static void Method3(string text)
        {
            int index = 0;
            text = text.Trim();

            while (true)
            {
                while (text[text.IndexOf(' ', index)] == text[text.IndexOf(' ', index) + 1])
                {
                    index = text.IndexOf(' ', index);
                    text = text.Remove(text.IndexOf(' ', index + 1), 1);

                }

                if (index >= text.LastIndexOf(' '))
                    break;
                index++;
            }

            string necessaryWord = "ipsum";
            text = text.Replace(necessaryWord, necessaryWord.ToUpper());
            Console.WriteLine("Method3:\n" + text);
        }
    }
}
