using System;
using System.IO;
using System.Collections.Generic;

namespace LR4_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            string inPath = "input.txt";
            string outPath = "output.txt";

            if (!File.Exists(inPath))
            {
                Console.WriteLine("Ошибка: файл {0} не найден!", inPath);
                return;
            }

            string[] lines = File.ReadAllLines(inPath);
            if (lines.Length < 2)
            {
                Console.WriteLine("Ошибка: неверный формат входного файла!");
                return;
            }

            int n = int.Parse(lines[0].Trim());
            string[] rawNumbers = lines[1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            double[] a = new double[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = double.Parse(rawNumbers[i].Replace('.', ','));
            }

            // 1) Максимальный отрицательный элемент
            bool hasNeg = false;
            double maxNeg = double.MinValue;
            for (int i = 0; i < n; i++)
            {
                if (a[i] < 0)
                {
                    if (!hasNeg || a[i] > maxNeg)
                    {
                        maxNeg = a[i];
                        hasNeg = true;
                    }
                }
            }

            // 2) Минимальный положительный элемент
            bool hasPos = false;
            double minPos = double.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (a[i] > 0)
                {
                    if (!hasPos || a[i] < minPos)
                    {
                        minPos = a[i];
                        hasPos = true;
                    }
                }
            }

            // 3) Список элементов, не превышающих по модулю 50 (|x| <= 50)
            List<double> leq50 = new List<double>();
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(a[i]) <= 50.0)
                {
                    leq50.Add(a[i]);
                }
            }

            // Запись в выходной файл
            using (StreamWriter sw = new StreamWriter(outPath))
            {
                sw.WriteLine("=== Результаты обработки одномерного массива (Вариант 6) ===");
                sw.WriteLine("Количество элементов N: {0}", n);
                sw.WriteLine("Исходный массив:");
                for (int i = 0; i < n; i++)
                {
                    sw.Write("{0:0.0} ", a[i]);
                }
                sw.WriteLine();
                sw.WriteLine();

                sw.WriteLine("1) Максимальный отрицательный элемент: {0}", 
                    hasNeg ? maxNeg.ToString("0.0") : "отрицательные элементы отсутствуют");

                sw.WriteLine("2) Минимальный положительный элемент: {0}", 
                    hasPos ? minPos.ToString("0.0") : "положительные элементы отсутствуют");

                sw.WriteLine("3) Элементы, не превышающие по модулю 50 (|x| <= 50):");
                if (leq50.Count > 0)
                {
                    for (int i = 0; i < leq50.Count; i++)
                    {
                        sw.Write("{0:0.0} ", leq50[i]);
                    }
                    sw.WriteLine();
                    sw.WriteLine("Всего элементов: {0}", leq50.Count);
                }
                else
                {
                    sw.WriteLine("Такие элементы не найдены.");
                }
            }

            Console.WriteLine("Обработка завершена успешно. Результаты сохранены в {0}", outPath);
        }
    }
}
