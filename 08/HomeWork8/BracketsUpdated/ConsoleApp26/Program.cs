using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            var bracketsDic = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' },
                { '>', '<' },
                { '\\', '/' }
            };

            string text = TryReadText(bracketsDic);

            var bracketsStack = new Stack<char>();

            bool soloEndBracket = false;
            foreach (var k in text)
            {
                if (bracketsDic.ContainsValue(k))
                {
                    bracketsStack.Push(k);
                    continue;
                }
                if (bracketsStack.Count != 0 && bracketsDic.ContainsKey(k) && bracketsDic[k] == bracketsStack.Peek())
                {
                    bracketsStack.Pop();
                    continue;
                }
                soloEndBracket = true;
            }

            if (!soloEndBracket)
            {
                Print(text, bracketsStack);
            }
            else
            {
                Console.WriteLine("\nUncorrect brackets, failed...");
            }

            Console.ReadKey();
        }

        static string TryReadText(Dictionary<char, char> bracketsDic)
        {
            string text = string.Empty;
            Console.Write("Введите строку состоящую только из \"( )\" , \"[ ]\" , \"{ }\" , \"<>\" , \"/ \\\": ");

            while (true)
            {
                try
                {
                    text = Console.ReadLine();

                    if (string.IsNullOrEmpty(text))
                    {
                        throw new ArgumentNullException();
                    }

                    char[] symbols = text.ToCharArray();
                    foreach (var k in symbols)
                    {
                        if (bracketsDic.ContainsKey(k) || bracketsDic.ContainsValue(k))
                        {
                            continue;
                        }
                        throw new ArgumentOutOfRangeException();
                    }

                    break;
                }

                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.GetType() + ": " + e.Message);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.GetType() + ": " + e.Message);
                }
            }

            return text;
        }

        static void Print(string text, Stack<char> bracketsStack)
        {
            if (bracketsStack.Count == 0)
            {
                Console.WriteLine("\nBrackets was opened...");
            }
            else
            {
                Console.WriteLine("\nUncorrect brackets, failed...");
            }
        }

    }
}
