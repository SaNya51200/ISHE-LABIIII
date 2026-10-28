using System;

namespace LR8_Demo
{
    public enum Gender { Male, Female }

    public class Person
    {
        protected string name;
        protected int age;
        protected Gender gender;

        public Person(string name, int age, Gender gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Человек: {0}, возраст: {1}, пол: {2}", name, age, gender);
        }
    }

    public class Student : Person
    {
        private string group;

        public Student(string name, int age, Gender gender, string group)
            : base(name, age, gender)
        {
            this.group = group;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine(" -> Студент группы: {0}", group);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person("Иван", 40, Gender.Male),
                new Student("Алексей", 20, Gender.Male, "ПИН-б-о-24-2")
            };

            foreach (var p in people)
            {
                p.PrintInfo();
            }
        }
    }
}
