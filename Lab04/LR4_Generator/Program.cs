using System;
using System.IO;

namespace LR4_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 12;
            double[] arr = new double[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                // Вещественные числа от -100 до 100 с одним знаком после запятой
                arr[i] = Math.Round((rnd.NextDouble() * 200.0 - 100.0), 1);
            }

            using (StreamWriter sw = new StreamWriter("input.txt"))
            {
                sw.WriteLine(n);
                for (int i = 0; i < n; i++)
                {
                    sw.Write(arr[i].ToString("0.0") + (i < n - 1 ? " " : ""));
                }
                sw.WriteLine();
            }

            Console.WriteLine("Файл input.txt успешно сгенерирован (N = {0})", n);
        }
    }
}
