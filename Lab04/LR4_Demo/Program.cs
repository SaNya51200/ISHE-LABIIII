using System;
using System.IO;

namespace LR4_Demo
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
            int n = int.Parse(lines[0]);
            string[] parts = lines[1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            double[] arr = new double[n];
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                arr[i] = double.Parse(parts[i].Replace('.', ','));
                sum += arr[i];
            }

            double avg = sum / n;

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine("Исходный массив (N = {0}):", n);
                for (int i = 0; i < n; i++)
                {
                    sw.Write("{0:0.0} ", arr[i]);
                }
                sw.WriteLine();
                sw.WriteLine("Среднее арифметическое: {0:0.00}", avg);
                sw.WriteLine("Элементы больше среднего:");
                for (int i = 0; i < n; i++)
                {
                    if (arr[i] > avg)
                    {
                        sw.Write("{0:0.0} ", arr[i]);
                    }
                }
                sw.WriteLine();
            }

            Console.WriteLine("Демо-программа завершена. Результаты в output.txt");
        }
    }
}
