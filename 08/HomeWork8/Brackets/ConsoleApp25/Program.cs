using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp25
{
    class Program
    {
        static void Main(string[] args)
        {
            var brackets = new Dictionary<char, char>
            {
                {')','(' },
                {']','[' }
            };

            string text = TryReadText(brackets);
            text = LogicAndDebug(text, brackets);
            Print(text);

            Console.ReadKey();
        }
        static string TryReadText(Dictionary<char, char> brackets)
        {
            string text = string.Empty;
            Console.Write("Введите строку состоящую только из \"( )\" , \"[ ]\": ");

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
                        if (k == brackets.ElementAt(0).Key || k == brackets.ElementAt(0).Value || k == brackets.ElementAt(1).Key || k == brackets.ElementAt(1).Value)
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

        static string LogicAndDebug(string text, Dictionary<char, char> brackets)
        {
            int symbolIndex = 0;
            int steps = 1;
            bool ok = true;
            Console.WriteLine("Debug:");

            while (ok)
            {
                if (text.Contains(brackets.ElementAt(0).Key) && text.Contains(brackets.ElementAt(1).Key))
                {
                    symbolIndex = Math.Min(text.IndexOf(brackets.ElementAt(0).Key), text.IndexOf(brackets.ElementAt(1).Key));
                }

                else if (text.Contains(brackets.ElementAt(0).Key))
                {
                    symbolIndex = text.IndexOf(brackets.ElementAt(0).Key);
                }

                else if (text.Contains(brackets.ElementAt(1).Key))
                {
                    symbolIndex = text.IndexOf(brackets.ElementAt(1).Key);
                }

                switch (text.Length)
                {
                    default:
                        {
                            if (brackets[text[symbolIndex]] == text[symbolIndex - 1])
                            {
                                Console.WriteLine(text);
                                text = text.Remove(symbolIndex - 1, 2);
                                Console.WriteLine($"Step{steps}: good");
                                steps++;
                            }

                            else
                            {
                                Console.WriteLine(text);
                                Console.WriteLine($"Step{steps}: failed");
                                ok = false;
                            }
                            break;
                        }

                    case 1:
                        {
                            Console.WriteLine(text);
                            Console.WriteLine($"Step{steps}: failed");
                            ok = false;
                            break;
                        }

                    case 0:
                        {
                            ok = false;
                            break;
                        }

                }

                //if (text.Length > 1)
                //{
                //    if (parens[text[symbolIndex]] == text[symbolIndex - 1])
                //    {
                //        Console.WriteLine(text);
                //        text = text.Remove(symbolIndex - 1, 2);
                //        Console.WriteLine($"Step{steps}: good");
                //        steps++;
                //    }

                //    else
                //    {
                //        Console.WriteLine(text);
                //        Console.WriteLine($"Step{steps}: failed");
                //        break;
                //    }
                //}
                //else if (text.Length == 1)
                //{
                //    Console.WriteLine(text);
                //    Console.WriteLine($"Step{steps}: failed");
                //    break;
                //}

                //else
                //{
                //    break;
                //}
            }

            return text;
        }

        static void Print(string text)
        {
            if (text == string.Empty)
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
