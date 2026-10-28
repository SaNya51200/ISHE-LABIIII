using System;

namespace LR9_Demo
{
    public interface ICalculate
    {
        double Calculate();
    }

    public interface IVisual
    {
        void Draw();
    }

    public class Human : ICalculate, IVisual
    {
        private string name;
        private double salary;

        public Human(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public double Calculate()
        {
            return salary * 0.87; // Налог 13%
        }

        public void Draw()
        {
            Console.WriteLine("Человек: {0}, Чистый доход: {1}", name, Calculate());
        }
    }

    public class Car : ICalculate, IVisual
    {
        private string model;
        private double fuelPrice;
        private double liters;

        public Car(string model, double fuelPrice, double liters)
        {
            this.model = model;
            this.fuelPrice = fuelPrice;
            this.liters = liters;
        }

        public double Calculate()
        {
            return fuelPrice * liters;
        }

        public void Draw()
        {
            Console.WriteLine("Автомобиль: {0}, Стоимость заправки: {1}", model, Calculate());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IVisual[] items = new IVisual[]
            {
                new Human("Сергей", 75000),
                new Car("Lada Vesta", 58.5, 45)
            };

            foreach (var item in items)
            {
                item.Draw();
            }
        }
    }
}
