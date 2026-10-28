using System;
using System.IO;

namespace MatrixLib
{
    public class FileMatrix
    {
        private int rows;
        private int cols;
        private int[,] data;
        private string filePath;

        public FileMatrix(string filePath)
        {
            this.filePath = filePath;
            LoadFromFile();
        }

        public int Rows { get { return this.rows; } }
        public int Cols { get { return this.cols; } }
        public string FilePath { get { return this.filePath; } }

        public int this[int i, int j]
        {
            get { return data[i, j]; }
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл матрицы не найден: " + filePath);
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                string header = sr.ReadLine();
                if (header == null) throw new InvalidDataException("Файл пуст.");

                string[] dims = header.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                rows = int.Parse(dims[0]);
                cols = int.Parse(dims[1]);

                data = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    string line = sr.ReadLine();
                    if (line == null) throw new InvalidDataException("Недостаточно строк в файле матрицы.");

                    string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < cols; j++)
                    {
                        data[i, j] = int.Parse(parts[j]);
                    }
                }
            }
        }

        public long GetTotalSum()
        {
            long sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sum += data[i, j];
                }
            }
            return sum;
        }

        public void Print(string title)
        {
            Console.WriteLine("Матрица {0} ({1}x{2}) из файла [{3}]:", title, rows, cols, Path.GetFileName(filePath));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0,6}", data[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static long CalculateDifference(FileMatrix m1, FileMatrix m2)
        {
            return m1.GetTotalSum() - m2.GetTotalSum();
        }
    }
}
