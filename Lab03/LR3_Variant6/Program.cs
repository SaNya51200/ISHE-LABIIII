using System;
using System.IO;

namespace LR_Three_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сохранение исходных потоков ввода-вывода
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;

            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");

            Console.SetOut(new_out);
            Console.SetIn(new_in);

            int t = 0, N = 1;
            double X = 0, Y = 0, Z = 1.0;

            t = Convert.ToInt32(Console.ReadLine().Trim());
            N = Convert.ToInt32(Console.ReadLine().Trim());
            X = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            Y = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));

            // Вычисление ряда:
            // Z = 1 - X/2! + Y^2/3! - X^3/4! + Y^4/5! - ...
            // Общий член: для нечетного i: - (X^i) / (i+1)!
            //             для четного i:   + (Y^i) / (i+1)!

            if (t == 0)
            {
                // Реализация с использованием цикла for
                double fact = 1.0;
                for (int i = 1; i <= N; i++)
                {
                    fact *= (i + 1);
                    double term;
                    if (i % 2 != 0)
                    {
                        double chisl = Math.Pow(X, i);
                        term = -chisl / fact;
                    }
                    else
                    {
                        double chisl = Math.Pow(Y, i);
                        term = chisl / fact;
                    }
                    Z += term;
                }
            }
            else if (t == 1)
            {
                // Реализация с использованием цикла while
                double fact = 1.0;
                int i = 1;
                while (i <= N)
                {
                    fact *= (i + 1);
                    double term;
                    if (i % 2 != 0)
                    {
                        double chisl = Math.Pow(X, i);
                        term = -chisl / fact;
                    }
                    else
                    {
                        double chisl = Math.Pow(Y, i);
                        term = chisl / fact;
                    }
                    Z += term;
                    i++;
                }
            }
            else if (t == 2)
            {
                // Реализация с использованием цикла do ... while
                double fact = 1.0;
                int i = 1;
                if (N >= 1)
                {
                    do
                    {
                        fact *= (i + 1);
                        double term;
                        if (i % 2 != 0)
                        {
                            double chisl = Math.Pow(X, i);
                            term = -chisl / fact;
                        }
                        else
                        {
                            double chisl = Math.Pow(Y, i);
                            term = chisl / fact;
                        }
                        Z += term;
                        i++;
                    } while (i <= N);
                }
            }

            Console.WriteLine(string.Format("{0:0.0000000}", Z));

            // Восстановление потоков и закрытие файлов
            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
        }
    }
}
