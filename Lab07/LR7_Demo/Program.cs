using System;

namespace LR7_Demo
{
    public class Box
    {
        private double a, b, c;

        public Box() : this(1, 1, 1) { }

        public Box(double val) : this(val, val, val) { }

        public Box(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public void Info()
        {
            Console.WriteLine("Box: a={0}, b={1}, c={2}, V={3}", a, b, c, a * b * c);
        }

        public void Info(ConsoleColor color)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Info();
            Console.ForegroundColor = old;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Box b1 = new Box();
            Box b2 = new Box(5);
            b1.Info();
            b2.Info(ConsoleColor.Green);
        }
    }
}
