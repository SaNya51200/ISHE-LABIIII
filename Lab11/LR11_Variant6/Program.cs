using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LR11_Variant6
{
    public class Target
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Param1 { get; set; }
        public double Param2 { get; set; }
        public bool HasWeapon { get; set; }

        public static Target Create(string line)
        {
            string[] p = line.Split(new char[] { ';', ',' }, StringSplitOptions.None);
            if (p.Length < 6) return null;

            return new Target
            {
                Id = int.Parse(p[0].Trim()),
                Name = p[1].Trim(),
                Category = p[2].Trim(),
                Param1 = double.Parse(p[3].Trim().Replace('.', ',')),
                Param2 = double.Parse(p[4].Trim().Replace('.', ',')),
                HasWeapon = bool.Parse(p[5].Trim())
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
#if !DEBUG
            TextWriter saveOut = Console.Out;
            StreamWriter sw = new StreamWriter("lr11_output.txt");
            Console.SetOut(sw);
#endif

            Console.WriteLine("=================================================================");
            Console.WriteLine("          Лабораторная работа №11 (Вариант 6)");
            Console.WriteLine("     Обработка структурированных данных (CSV и LINQ)");
            Console.WriteLine("      Студент: Целенко А. А., Группа: ПИН-б-о-24-2");
            Console.WriteLine("=================================================================\n");

            string csvPath = "targets.csv";
            if (!File.Exists(csvPath))
            {
                Console.WriteLine("Файл {0} не найден!", csvPath);
                return;
            }

            List<Target> targets = new List<Target>();
            string[] lines = File.ReadAllLines(csvPath);

            // Пропускаем заголовок
            for (int i = 1; i < lines.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    Target t = Target.Create(lines[i]);
                    if (t != null) targets.Add(t);
                }
            }

            Console.WriteLine("Успешно загружено объектов (целей): {0}\n", targets.Count);

            // 1. Среднее значение Param1 по каждой из категорий
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("ЗАДАЧА 1: Среднее значение Param1 по каждой из категорий:");
            var avgParam1ByCategory = targets
                .GroupBy(t => t.Category)
                .Select(g => new { Category = g.Key, Avg = g.Average(t => t.Param1) })
                .OrderBy(x => x.Category);

            foreach (var item in avgParam1ByCategory)
            {
                Console.WriteLine("  Категория [{0,-15}]: {1:0.00}", item.Category, item.Avg);
            }

            // 2. Сумма параметров Param2 для каждой категории
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.WriteLine("ЗАДАЧА 2: Сумма параметров Param2 по каждой категории:");
            var sumParam2ByCategory = targets
                .GroupBy(t => t.Category)
                .Select(g => new { Category = g.Key, Sum = g.Sum(t => t.Param2) })
                .OrderBy(x => x.Category);

            foreach (var item in sumParam2ByCategory)
            {
                Console.WriteLine("  Категория [{0,-15}]: {1:0.0}", item.Category, item.Sum);
            }

            // 3. Сколько целей снабжены оружием, а сколько – нет
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.WriteLine("ЗАДАЧА 3: Распределение целей по наличию вооружения:");
            int withWeapon = targets.Count(t => t.HasWeapon);
            int withoutWeapon = targets.Count(t => !t.HasWeapon);

            Console.WriteLine("  Снабжены оружием (HasWeapon = True):   {0} объектов", withWeapon);
            Console.WriteLine("  Без оружия (HasWeapon = False):        {0} объектов", withoutWeapon);

            // 4. Найти объект с максимальным значением Param1
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.WriteLine("ЗАДАЧА 4: Объект с максимальным значением Param1:");
            var maxParam1Target = targets.OrderByDescending(t => t.Param1).FirstOrDefault();

            if (maxParam1Target != null)
            {
                Console.WriteLine("  ID:           {0}", maxParam1Target.Id);
                Console.WriteLine("  Наименование: {0}", maxParam1Target.Name);
                Console.WriteLine("  Категория:    {0}", maxParam1Target.Category);
                Console.WriteLine("  Param1:       {0:0.00} (МАКСИМУМ)", maxParam1Target.Param1);
                Console.WriteLine("  Param2:       {0:0.0}", maxParam1Target.Param2);
                Console.WriteLine("  Вооружение:   {0}", maxParam1Target.HasWeapon ? "Да" : "Нет");
            }
            Console.WriteLine("=================================================================");

#if !DEBUG
            Console.SetOut(saveOut);
            sw.Close();
#endif
        }
    }
}
