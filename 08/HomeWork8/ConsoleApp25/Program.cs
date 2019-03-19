using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp25
{
    class Program
    {
        static void Main(string[] args)
        {
            var parens = new Dictionary<char, char>
            {
                {')','(' },
                {']','[' }
            };

            string text = string.Empty;
            bool ok = false;
            Console.Write("Введите строку состоящую только из \"( )\" , \"[ ]\": ");

            while (true)
            {
                text = Console.ReadLine();
                if (string.IsNullOrEmpty(text))
                {
                    ok = true;
                    Console.Write("Error, try again: ");
                }

                char[] symbols = text.ToCharArray();
                foreach (var k in symbols)
                {
                    if (k == parens.ElementAt(0).Key || k == parens.ElementAt(0).Value || k == parens.ElementAt(1).Key || k == parens.ElementAt(1).Value)
                    {
                        ok = false;
                        continue;
                    }
                    Console.Write("Error, try again: ");
                    ok = true;
                    break;
                }
                if (ok == false)
                {
                    break;
                }
            }

            int symbolIndex = 0;
            int i = 1;
            Console.WriteLine("Debug:");

            while (true)
            {
                if (text.Contains(parens.ElementAt(0).Key) && text.Contains(parens.ElementAt(1).Key))
                {
                    symbolIndex = Math.Min(text.IndexOf(parens.ElementAt(0).Key), text.IndexOf(parens.ElementAt(1).Key));
                }

                else if (text.Contains(parens.ElementAt(0).Key))
                {
                    symbolIndex = text.IndexOf(parens.ElementAt(0).Key);
                }

                else if (text.Contains(parens.ElementAt(1).Key))
                {
                    symbolIndex = text.IndexOf(parens.ElementAt(1).Key);
                }


                if (text.Length > 1)
                {
                    if (parens[text[symbolIndex]] == text[symbolIndex - 1])
                    {
                        Console.WriteLine(text);
                        text = text.Remove(symbolIndex - 1, 2);
                        Console.WriteLine($"Step{i}: good");
                        i++;
                    }

                    else
                    {
                        Console.WriteLine(text);
                        Console.WriteLine($"Step{i}: failed");
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (text == string.Empty)
            {
                Console.WriteLine("\nBrackets was opened...");
            }
            else
            {
                Console.WriteLine("\nUncorrect brackets, failed...");
            }

            Console.ReadKey();
        }
    }
}
