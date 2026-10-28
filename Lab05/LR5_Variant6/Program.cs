using System;
using System.IO;

namespace LR5_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            string inPath = "input.txt";
            string outPath = "output.txt";

            if (!File.Exists(inPath))
            {
                Console.WriteLine("Ошибка: входной файл {0} не найден!", inPath);
                return;
            }

            string[] lines = File.ReadAllLines(inPath);
            string[] dims = lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(dims[0]); // Строки
            int m = int.Parse(dims[1]); // Столбцы

            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] parts = lines[i + 1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(parts[j]);
                }
            }

            // 2) Отрицательный максимум для каждого столбца
            string[] colMaxNeg = new string[m];
            for (int j = 0; j < m; j++)
            {
                bool found = false;
                int maxNeg = int.MinValue;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (!found || matrix[i, j] > maxNeg)
                        {
                            maxNeg = matrix[i, j];
                            found = true;
                        }
                    }
                }
                colMaxNeg[j] = found ? maxNeg.ToString() : "нет";
            }

            // 3) Модифицированная матрица:
            // кратные 2 заменяются на 2, кратные 3 - на 3, остальные - на 0
            int[,] modMatrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int val = matrix[i, j];
                    if (val != 0 && val % 2 == 0)
                    {
                        modMatrix[i, j] = 2;
                    }
                    else if (val != 0 && val % 3 == 0)
                    {
                        modMatrix[i, j] = 3;
                    }
                    else
                    {
                        modMatrix[i, j] = 0;
                    }
                }
            }

            // Запись результатов в файл output.txt
            using (StreamWriter sw = new StreamWriter(outPath))
            {
                sw.WriteLine("=== Обработка матрицы {0}x{1} (Вариант 6) ===", n, m);
                sw.WriteLine();

                sw.WriteLine("1) Исходная матрица:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        sw.Write("{0,7}", matrix[i, j]);
                    }
                    sw.WriteLine();
                }
                sw.WriteLine();

                sw.WriteLine("2) Отрицательный максимум для каждого столбца:");
                for (int j = 0; j < m; j++)
                {
                    sw.WriteLine("   Столбец {0}: {1}", j + 1, colMaxNeg[j]);
                }
                sw.WriteLine();

                sw.WriteLine("3) Модифицированная матрица (кратные 2 -> 2, кратные 3 -> 3, остальные -> 0):");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        sw.Write("{0,5}", modMatrix[i, j]);
                    }
                    sw.WriteLine();
                }
            }

            Console.WriteLine("Матрица успешно обработана. Результаты сохранены в {0}", outPath);
        }
    }
}
