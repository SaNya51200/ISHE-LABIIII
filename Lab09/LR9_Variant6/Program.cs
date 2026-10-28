using System;

namespace LR9_Variant6
{
    /// <summary>
    /// Интерфейс 1: Расчет ключевого операционно-технического показателя
    /// </summary>
    public interface ICalculable
    {
        string MetricName { get; }
        double GetOperationalMetric();
    }

    /// <summary>
    /// Интерфейс 2: Отображение информации об объекте
    /// </summary>
    public interface IDisplayable
    {
        string Identifier { get; }
        void DisplayDetails();
    }

    /// <summary>
    /// Независимый класс 1: Беспилотный летательный аппарат (БПЛА)
    /// </summary>
    public class AutonomousDrone : ICalculable, IDisplayable
    {
        private string model;
        private double batteryCapacityKwh;
        private double powerConsumptionKw;
        private double payloadKg;

        public AutonomousDrone(string model, double batteryCapacityKwh, double powerConsumptionKw, double payloadKg)
        {
            this.model = model;
            this.batteryCapacityKwh = batteryCapacityKwh;
            this.powerConsumptionKw = powerConsumptionKw;
            this.payloadKg = payloadKg;
        }

        // Реализация IDisplayable
        public string Identifier
        {
            get { return string.Format("БПЛА [{0}]", this.model); }
        }

        public void DisplayDetails()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Объект мониторинга:      {0}", Identifier);
            Console.WriteLine("Емкость батареи:         {0:0.0} кВт*ч", this.batteryCapacityKwh);
            Console.WriteLine("Потребляемая мощность:   {0:0.0} кВт", this.powerConsumptionKw);
            Console.WriteLine("Полезная нагрузка:       {0:0.0} кг", this.payloadKg);
            Console.WriteLine("{0}: {1:0.00} часов", MetricName, GetOperationalMetric());
        }

        // Реализация ICalculable: Расчет времени автономного барражирования в часах
        public string MetricName
        {
            get { return "Расчетное время патрулирования"; }
        }

        public double GetOperationalMetric()
        {
            if (this.powerConsumptionKw <= 0) return 0;
            return this.batteryCapacityKwh / this.powerConsumptionKw;
        }
    }

    /// <summary>
    /// Независимый класс 2: Радиолокационная станция (РЛС)
    /// </summary>
    public class RadarStation : ICalculable, IDisplayable
    {
        private string stationCode;
        private double detectionRangeKm;
        private int antennaModules;
        private double powerOutputKw;

        public RadarStation(string stationCode, double detectionRangeKm, int antennaModules, double powerOutputKw)
        {
            this.stationCode = stationCode;
            this.detectionRangeKm = detectionRangeKm;
            this.antennaModules = antennaModules;
            this.powerOutputKw = powerOutputKw;
        }

        // Реализация IDisplayable
        public string Identifier
        {
            get { return string.Format("РЛС комплекс [{0}]", this.stationCode); }
        }

        public void DisplayDetails()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Объект мониторинга:      {0}", Identifier);
            Console.WriteLine("Дальность обнаружения:   {0:0.0} км", this.detectionRangeKm);
            Console.WriteLine("Число антенных решеток:  {0} шт", this.antennaModules);
            Console.WriteLine("Излучаемая мощность:     {0:0.0} кВт", this.powerOutputKw);
            Console.WriteLine("{0}: {1:0.0} тыс. км³", MetricName, GetOperationalMetric());
        }

        // Реализация ICalculable: Расчет объема контролируемого воздушного купола (в тыс. км³)
        public string MetricName
        {
            get { return "Объем полусферы сканирования"; }
        }

        public double GetOperationalMetric()
        {
            // Полусфера: (2/3) * pi * R^3, в тысячах км^3
            double volumeKm3 = (2.0 / 3.0) * Math.PI * Math.Pow(this.detectionRangeKm, 3);
            return volumeKm3 / 1000.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("          Лабораторная работа №9 (Вариант 6)");
            Console.WriteLine("      Полиморфизм на основе интерфейсов (ICalculable, IDisplayable)");
            Console.WriteLine("      Студент: Целенко А. А., Группа: ПИН-б-о-24-2");
            Console.WriteLine("=================================================================");

            // 1. Полиморфный массив интерфейса IDisplayable
            IDisplayable[] units = new IDisplayable[]
            {
                new AutonomousDrone("Орлан-10М", 12.0, 1.5, 5.0),
                new RadarStation("Небо-М", 600.0, 3, 450.0),
                new AutonomousDrone("ZALA Ланцет-3", 8.5, 2.8, 3.0),
                new RadarStation("Гамма-С1", 300.0, 1, 180.0)
            };

            Console.WriteLine("\n[1. ВЫЗОВ ЧЕРЕЗ ИНТЕРФЕЙСНЫЙ МАССИВ IDisplayable[]]");
            for (int i = 0; i < units.Length; i++)
            {
                Console.WriteLine("\nЭлемент #{0}:", i + 1);
                units[i].DisplayDetails();
            }

            // 2. Полиморфный массив интерфейса ICalculable
            Console.WriteLine("\n\n=================================================================");
            Console.WriteLine("[2. ВЫЗОВ ЧЕРЕЗ ИНТЕРФЕЙСНЫЙ МАССИВ ICalculable[]]");
            Console.WriteLine("=================================================================");

            ICalculable[] metrics = new ICalculable[]
            {
                new AutonomousDrone("Герань-2", 24.0, 3.2, 50.0),
                new RadarStation("Воронеж-ДМ", 6000.0, 4, 12000.0)
            };

            for (int i = 0; i < metrics.Length; i++)
            {
                Console.WriteLine("Объект #{0}: {1} = {2:0.00}", 
                    i + 1, metrics[i].MetricName, metrics[i].GetOperationalMetric());
            }

            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.WriteLine("Полиморфные интерфейсные вызовы выполнены успешно.");
        }
    }
}
