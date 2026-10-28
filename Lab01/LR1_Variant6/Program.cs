using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR_One_Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Часть 1. Вывод персональной информации о студенте
            Console.WriteLine("==========================================================");
            Console.WriteLine("           ЛАБОРАТОРНАЯ РАБОТА №1 (ВАРИАНТ 6)             ");
            Console.WriteLine("==========================================================");
            Console.WriteLine("ФИО студента:           Целенко Александр Андреевич");
            Console.WriteLine("Группа:                 ПИН-б-о-24-2");
            Console.WriteLine("Шифр специальности:     09.03.03 Прикладная информатика");
            Console.WriteLine("Дата рождения:          22.08.2005");
            Console.WriteLine("Место жительства:       г. Ставрополь");
            Console.WriteLine("Любимый школьный предм: Информатика");
            Console.WriteLine("Хобби и увлечения:      Программирование на C#, веб-разработка, спорт");
            Console.WriteLine("----------------------------------------------------------\n");

            // Часть 2. Вычисление выражения по варианту 6:
            // Z = (35 / f) + y * f - (f + y) / 4
            Console.WriteLine("ВЫЧИСЛЕНИЕ ВЫРАЖЕНИЯ ПО ВАРИАНТУ 6:");
            Console.WriteLine("Формула: Z = (35 / f) + y * f - (f + y) / 4\n");

            double f = 5.0;
            double y = 3.0;

            double term1 = 35.0 / f;
            double term2 = y * f;
            double term3 = (f + y) / 4.0;
            double Z = term1 + term2 - term3;

            Console.WriteLine("Исходные переменные:");
            Console.WriteLine("  f = {0:0.00}", f);
            Console.WriteLine("  y = {0:0.00}", y);
            Console.WriteLine();
            Console.WriteLine("Промежуточные слагаемые:");
            Console.WriteLine("  35 / f             = {0:0.0000}", term1);
            Console.WriteLine("  y * f              = {0:0.0000}", term2);
            Console.WriteLine("  (f + y) / 4        = {0:0.0000}", term3);
            Console.WriteLine();
            Console.WriteLine("Итоговый результат: Z = {0:0.0000}", Z);
            Console.WriteLine("==========================================================");
            Console.WriteLine("\nДля завершения работы программы нажмите любую клавишу...");

            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
