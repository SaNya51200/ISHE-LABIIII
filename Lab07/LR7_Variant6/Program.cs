using System;
using System.IO;

namespace LR7_Variant6
{
    /// <summary>
    /// Класс "Правильная треугольная пирамида"
    /// </summary>
    public class RegularTriangularPyramid
    {
        private double a; // сторона основания
        private double h; // высота пирамиды

        public RegularTriangularPyramid()
        {
            this.a = 2.0;
            this.h = 3.0;
        }

        public RegularTriangularPyramid(double a, double h)
        {
            SetDimensions(a, h);
        }

        public RegularTriangularPyramid(string line)
        {
            string[] parts = line.Split(new char[] { ' ', '\t', ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                throw new ArgumentException("Недостаточно данных для инициализации пирамиды.");
            }
            double pa = double.Parse(parts[0].Replace('.', ','));
            double ph = double.Parse(parts[1].Replace('.', ','));
            SetDimensions(pa, ph);
        }

        public void SetDimensions(double a, double h)
        {
            if (a <= 0 || h <= 0)
            {
                throw new ArgumentException("Сторона основания и высота должны быть строго положительными.");
            }
            this.a = a;
            this.h = h;
        }

        public double GetBaseSide() { return this.a; }
        public double GetHeight() { return this.h; }

        public double GetBaseArea()
        {
            return (Math.Pow(this.a, 2) * Math.Sqrt(3.0)) / 4.0;
        }

        public double GetApothem()
        {
            double r = (this.a * Math.Sqrt(3.0)) / 6.0;
            return Math.Sqrt(Math.Pow(this.h, 2) + Math.Pow(r, 2));
        }

        public double GetLateralArea()
        {
            return 1.5 * this.a * GetApothem();
        }

        public double GetTotalArea()
        {
            return GetBaseArea() + GetLateralArea();
        }

        public double GetVolume()
        {
            return (GetBaseArea() * this.h) / 3.0;
        }

        // Перегрузка 1: Стандартный вывод
        public void Info()
        {
            Console.WriteLine("================ Правильная треугольная пирамида ================");
            Console.WriteLine("Сторона основания (a):       {0:0.0000}", this.a);
            Console.WriteLine("Высота (h):                  {0:0.0000}", this.h);
            Console.WriteLine("Апофема боковой грани (l):   {0:0.0000}", GetApothem());
            Console.WriteLine("Площадь основания (S_осн):   {0:0.0000}", GetBaseArea());
            Console.WriteLine("Площадь боковая (S_бок):     {0:0.0000}", GetLateralArea());
            Console.WriteLine("Полная площадь (S):          {0:0.0000}", GetTotalArea());
            Console.WriteLine("Объем пирамиды (V):          {0:0.0000}", GetVolume());
            Console.WriteLine("=================================================================");
        }

        // Перегрузка 2: Цветной вывод
        public void Info(ConsoleColor titleColor, ConsoleColor dataColor)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = titleColor;
            Console.WriteLine("================ Правильная треугольная пирамида (Цветной) ========");
            Console.ForegroundColor = dataColor;
            Console.WriteLine("a = {0:0.00}, h = {1:0.00} | S_бок = {2:0.0000}, S_полн = {3:0.0000}, V = {4:0.0000}", 
                this.a, this.h, GetLateralArea(), GetTotalArea(), GetVolume());
            Console.ForegroundColor = titleColor;
            Console.WriteLine("=================================================================");
            Console.ForegroundColor = old;
        }

        // Перегрузка 3: Краткий формат
        public void Info(bool shortForm)
        {
            if (shortForm)
            {
                Console.WriteLine("[Пирамида: a={0:0.00}, h={1:0.00} | V={2:0.0000}, S={3:0.0000}]",
                    this.a, this.h, GetVolume(), GetTotalArea());
            }
            else
            {
                Info();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
#if !DEBUG
            TextWriter saveOut = Console.Out;
            TextReader saveIn = Console.In;

            StreamWriter sw = new StreamWriter("pyramid_output.txt");
            StreamReader sr = new StreamReader("pyramid_input.txt");

            Console.SetOut(sw);
            Console.SetIn(sr);
#endif

            Console.WriteLine("Лабораторная работа №7 (Вариант 6)");
            Console.WriteLine("Студент: Целенко А. А., Группа: ПИН-б-о-24-2");
            Console.WriteLine();

            // 1. Конструктор по умолчанию
            Console.WriteLine("1) Объект по умолчанию:");
            RegularTriangularPyramid pDef = new RegularTriangularPyramid();
            pDef.Info();
            Console.WriteLine();

            // 2. Параметризованный ввод
            Console.WriteLine("2) Объект из параметров ввода:");
            string line = Console.ReadLine();
            RegularTriangularPyramid pUser = new RegularTriangularPyramid(line);
            pUser.Info(ConsoleColor.Cyan, ConsoleColor.Yellow);
            Console.WriteLine();

            // 3. Краткий вывод
            Console.WriteLine("3) Краткая форма вывода:");
            pUser.Info(true);

#if !DEBUG
            Console.SetOut(saveOut);
            sw.Close();
            Console.SetIn(saveIn);
            sr.Close();
#endif
        }
    }
}
