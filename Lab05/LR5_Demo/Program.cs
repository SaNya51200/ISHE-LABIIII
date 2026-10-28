using System;
using System.IO;

namespace LR5_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("Файл input.txt не найден.");
                return;
            }

            string[] lines = File.ReadAllLines("input.txt");
            string[] dims = lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(dims[0]);
            int cols = int.Parse(dims[1]);

            int[,] m = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string[] parts = lines[i + 1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cols; j++)
                {
                    m[i, j] = int.Parse(parts[j]);
                }
            }

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine("Демо-матрица {0}x{1}:", rows, cols);
                for (int i = 0; i < rows; i++)
                {
                    int maxRow = m[i, 0];
                    for (int j = 0; j < cols; j++)
                    {
                        sw.Write("{0,6}", m[i, j]);
                        if (m[i, j] > maxRow) maxRow = m[i, j];
                    }
                    sw.WriteLine("  | Максимум строки: {0}", maxRow);
                }
            }

            Console.WriteLine("Демо ЛР 5 завершено. Результаты в output.txt");
        }
    }
}
