using System;
using MatrixLib;

namespace MatrixApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("          Лабораторная работа №10 (Вариант 6)");
            Console.WriteLine("     Многомодульное приложение: библиотека MatrixLib.dll");
            Console.WriteLine("  Расчет разности сумм элементов матриц: Diff = Sum(M1) - Sum(M2)");
            Console.WriteLine("      Студент: Целенко А. А., Группа: ПИН-б-о-24-2");
            Console.WriteLine("=================================================================\n");

            try
            {
                FileMatrix m1 = new FileMatrix("matrix1.txt");
                FileMatrix m2 = new FileMatrix("matrix2.txt");

                m1.Print("M1");
                long sum1 = m1.GetTotalSum();
                Console.WriteLine(">>> Сумма элементов матрицы M1: {0}\n", sum1);

                m2.Print("M2");
                long sum2 = m2.GetTotalSum();
                Console.WriteLine(">>> Сумма элементов матрицы M2: {0}\n", sum2);

                long diff = FileMatrix.CalculateDifference(m1, m2);
                Console.WriteLine("=================================================================");
                Console.WriteLine("ИТОГОВЫЙ РАСЧЕТ:");
                Console.WriteLine("Разность сумм элементов матриц (Sum(M1) - Sum(M2)):");
                Console.WriteLine("{0} - {1} = {2}", sum1, sum2, diff);
                Console.WriteLine("=================================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении: " + ex.Message);
            }
        }
    }
}
