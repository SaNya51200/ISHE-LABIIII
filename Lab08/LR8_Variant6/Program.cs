using System;

namespace LR8_Variant6
{
    // 1. Тип-перечисление
    public enum WeaponStatus
    {
        InReserve,      // В резерве
        ServiceReady,   // Готово к эксплуатации
        InCombat,       // В боевом дежурстве
        Decommissioned  // Списано
    }

    /// <summary>
    /// Базовый класс: Вооружение
    /// </summary>
    public class Weaponry
    {
        protected string name;
        protected string country;
        protected double weightKg;
        protected WeaponStatus status;

        public Weaponry(string name, string country, double weightKg, WeaponStatus status)
        {
            this.name = name;
            this.country = country;
            this.weightKg = weightKg;
            this.status = status;
        }

        // Переопределяемое свойство
        public virtual string TacticalName
        {
            get { return string.Format("Вооружение [{0}] ({1})", this.name, this.country); }
        }

        public string Country { get { return this.country; } }
        public double WeightKg { get { return this.weightKg; } }
        public WeaponStatus Status { get { return this.status; } }

        // Метод базового класса для вызова через base
        public string GetBaseClassification()
        {
            return string.Format("Класс изделия: {0}, статус: {1}", this.GetType().Name, this.status);
        }

        // Виртуальный метод вычисления боевого рейтинга
        public virtual double CalculateCombatRating()
        {
            return this.weightKg * 0.1;
        }

        // Виртуальный метод вывода информации
        public virtual void Info()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Наименование:        {0}", TacticalName);
            Console.WriteLine("Базовая сводка:      {0}", GetBaseClassification());
            Console.WriteLine("Страна разработки:   {0}", this.country);
            Console.WriteLine("Масса (кг):          {0:0.0}", this.weightKg);
            Console.WriteLine("Боевой рейтинг:      {0:0.00}", CalculateCombatRating());
        }
    }

    /// <summary>
    /// Производный класс 1: Стрелковое оружие
    /// </summary>
    public class SmallArms : Weaponry
    {
        private double caliberMm;
        private int magazineCapacity;
        private int fireRateRpm;

        public SmallArms(string name, string country, double weightKg, WeaponStatus status,
                         double caliberMm, int magazineCapacity, int fireRateRpm)
            : base(name, country, weightKg, status) // Вызов базового конструктора
        {
            this.caliberMm = caliberMm;
            this.magazineCapacity = magazineCapacity;
            this.fireRateRpm = fireRateRpm;
        }

        // Переопределение свойства
        public override string TacticalName
        {
            get { return string.Format("Стрелковое: {0} ({1:0.00} мм)", this.name, this.caliberMm); }
        }

        // Переопределение метода расчета
        public override double CalculateCombatRating()
        {
            return (this.caliberMm * 10.0) + (this.fireRateRpm * 0.5) + (this.magazineCapacity * 2.0);
        }

        // Переопределение метода Info
        public override void Info()
        {
            base.Info(); // Вызов базового метода
            Console.WriteLine("Тип спецификации:    Стрелковое оружие");
            Console.WriteLine("Калибр:              {0:0.00} мм", this.caliberMm);
            Console.WriteLine("Емкость магазина:    {0} патронов", this.magazineCapacity);
            Console.WriteLine("Скорострельность:    {0} выстр/мин", this.fireRateRpm);
        }
    }

    /// <summary>
    /// Производный класс 2: Танк
    /// </summary>
    public class Tank : Weaponry
    {
        private double armorMm;
        private double gunCaliberMm;
        private int engineHorsePower;

        public Tank(string name, string country, double weightKg, WeaponStatus status,
                    double armorMm, double gunCaliberMm, int engineHorsePower)
            : base(name, country, weightKg, status)
        {
            this.armorMm = armorMm;
            this.gunCaliberMm = gunCaliberMm;
            this.engineHorsePower = engineHorsePower;
        }

        public override string TacticalName
        {
            get { return string.Format("Основной боевой танк: {0} (Орудие {1:0} мм)", this.name, this.gunCaliberMm); }
        }

        public override double CalculateCombatRating()
        {
            return (this.gunCaliberMm * 15.0) + (this.armorMm * 8.0) + (this.engineHorsePower * 0.1);
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine("Тип спецификации:    Бронетанковое вооружение");
            Console.WriteLine("Толщина брони:       {0:0} мм", this.armorMm);
            Console.WriteLine("Калибр орудия:       {0:0} мм", this.gunCaliberMm);
            Console.WriteLine("Мощность двигателя:  {0} л.с.", this.engineHorsePower);
        }
    }

    /// <summary>
    /// Производный класс 3: Самолет
    /// </summary>
    public class Aircraft : Weaponry
    {
        private double maxSpeedKmh;
        private double ceilingMeters;
        private double payloadKg;

        public Aircraft(string name, string country, double weightKg, WeaponStatus status,
                        double maxSpeedKmh, double ceilingMeters, double payloadKg)
            : base(name, country, weightKg, status)
        {
            this.maxSpeedKmh = maxSpeedKmh;
            this.ceilingMeters = ceilingMeters;
            this.payloadKg = payloadKg;
        }

        public override string TacticalName
        {
            get { return string.Format("Боевой самолет: {0} (Скорость до {1:0} км/ч)", this.name, this.maxSpeedKmh); }
        }

        public override double CalculateCombatRating()
        {
            return (this.maxSpeedKmh * 0.8) + (this.payloadKg * 0.5) + (this.ceilingMeters * 0.05);
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine("Тип спецификации:    Авиационная техника");
            Console.WriteLine("Макс. скорость:      {0:0} км/ч", this.maxSpeedKmh);
            Console.WriteLine("Практический потолок:{0:0} м", this.ceilingMeters);
            Console.WriteLine("Боевая нагрузка:     {0:0} кг", this.payloadKg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("          Лабораторная работа №8 (Вариант 6)");
            Console.WriteLine("      Иерархия классов: Вооружение -> Стрелковое / Танк / Самолет");
            Console.WriteLine("      Студент: Целенко А. А., Группа: ПИН-б-о-24-2");
            Console.WriteLine("=================================================================");

            // Полиморфный массив базового типа Weaponry
            Weaponry[] arsenal = new Weaponry[]
            {
                new SmallArms("АК-12", "Россия", 3.5, WeaponStatus.InCombat, 5.45, 30, 700),
                new Tank("Т-90М «Прорыв»", "Россия", 48000.0, WeaponStatus.InCombat, 950.0, 125.0, 1130),
                new Aircraft("Су-35С", "Россия", 19000.0, WeaponStatus.ServiceReady, 2500.0, 20000.0, 8000.0),
                new SmallArms("ВСС «Винторез»", "Россия", 2.6, WeaponStatus.ServiceReady, 9.00, 20, 600)
            };

            Console.WriteLine("\n[ДЕМОНСТРАЦИЯ ПОЛИМОРФИЗМА: Перебор полиморфного массива Weaponry[]]");
            for (int i = 0; i < arsenal.Length; i++)
            {
                Console.WriteLine("\n>>> Элемент массива #{0} (Тип в рантайме: {1})", i + 1, arsenal[i].GetType().Name);
                arsenal[i].Info(); // Полиморфный вызов виртуального метода
            }

            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.WriteLine("Все объекты успешно обработаны полиморфным массивом базового типа.");
        }
    }
}
