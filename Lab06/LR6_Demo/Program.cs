using System;

namespace LR6_Demo
{
    public class Par
    {
        private double a;
        private double b;
        private double c;

        public Par(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double GetVolume()
        {
            return a * b * c;
        }

        public double GetArea()
        {
            return 2 * (a * b + b * c + a * c);
        }

        public void PrintInfo()
        {
            Console.WriteLine("Параллелепипед: a={0}, b={1}, c={2}, V={3}, S={4}", a, b, c, GetVolume(), GetArea());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Par p = new Par(3, 4, 5);
            p.PrintInfo();
        }
    }
}
