using System;
using System.IO;

namespace LR6_Variant6
{
    /// <summary>
    /// Класс "Шар" для представления геометрического тела в трехмерном пространстве
    /// </summary>
    public class Sphere
    {
        private double radius;

        public Sphere()
        {
            this.radius = 1.0;
        }

        public Sphere(double radius)
        {
            SetRadius(radius);
        }

        public void SetRadius(double r)
        {
            if (r < 0)
            {
                throw new ArgumentException("Радиус шара не может быть отрицательным.");
            }
            this.radius = r;
        }

        public double GetRadius()
        {
            return this.radius;
        }

        public double GetDiameter()
        {
            return 2.0 * this.radius;
        }

        public double GetVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(this.radius, 3);
        }

        public double GetSurfaceArea()
        {
            return 4.0 * Math.PI * Math.Pow(this.radius, 2);
        }

        public void Info()
        {
            Console.WriteLine("================ Информация об объекте ШАР ================");
            Console.WriteLine("Радиус (R):              {0:0.0000}", GetRadius());
            Console.WriteLine("Диаметр (D):             {0:0.0000}", GetDiameter());
            Console.WriteLine("Объем (V):               {0:0.0000}", GetVolume());
            Console.WriteLine("Площадь поверхности (S): {0:0.0000}", GetSurfaceArea());
            Console.WriteLine("===========================================================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
#if !DEBUG
            TextWriter saveOut = Console.Out;
            TextReader saveIn = Console.In;

            StreamWriter sw = new StreamWriter("sphere_output.txt");
            StreamReader sr = new StreamReader("sphere_input.txt");

            Console.SetOut(sw);
            Console.SetIn(sr);
#endif

            Console.WriteLine("Лабораторная работа №6 (Вариант 6)");
            Console.WriteLine("Студент: Целенко А. А., Группа: ПИН-б-о-24-2");
            Console.WriteLine();

            Console.Write("Введите радиус первого шара: ");
            string line = Console.ReadLine();
            double r1 = double.Parse(line.Replace('.', ','));
            Sphere s1 = new Sphere(r1);
            s1.Info();

            Console.WriteLine();
            Console.Write("Введите радиус второго шара: ");
            line = Console.ReadLine();
            double r2 = double.Parse(line.Replace('.', ','));
            Sphere s2 = new Sphere(r2);
            s2.Info();

#if !DEBUG
            Console.SetOut(saveOut);
            sw.Close();
            Console.SetIn(saveIn);
            sr.Close();
#endif
        }
    }
}
