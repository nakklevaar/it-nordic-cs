using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var marks = new[]
            {
                new [] {2,3,3,2,3},
                new [] {2,4,5,3},
                null,
                new [] {5,5,5,5},
                new [] {4}
            };

            double fullsum = 0; //средняя за неделю
            int p = 0; // р - кол-во массивов
            int n = 0; // счет всех оценок

            while (p < marks.Length)
            {
                if (marks[p] == null)
                {
                    Console.WriteLine($"Средний балл за день #{p + 1}: N/A");
                    p++;
                    continue;
                }

                double sum = 0;
                foreach (int k in marks[p])
                {
                    sum += k;
                }

                n += marks[p].Length;
                Console.WriteLine($"Средний балл за день #{p + 1}: " + Math.Round(sum / marks[p].Length, 1));
                fullsum += sum;
                p++;

            }

            Console.WriteLine($"Средний балл за неделю : " + Math.Round(fullsum / n, 1));
            Console.ReadKey();
        }
    }
}
