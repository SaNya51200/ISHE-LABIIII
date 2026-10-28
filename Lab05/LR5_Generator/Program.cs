using System;
using System.IO;

namespace LR5_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 4;
            int cols = 5;
            int[,] matrix = new int[rows, cols];
            Random rnd = new Random();

            using (StreamWriter sw = new StreamWriter("input.txt"))
            {
                sw.WriteLine("{0} {1}", rows, cols);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = rnd.Next(-100, 101);
                        sw.Write("{0,6}", matrix[i, j]);
                    }
                    sw.WriteLine();
                }
            }

            Console.WriteLine("Матрица {0}x{1} успешно сгенерирована в input.txt", rows, cols);
        }
    }
}
