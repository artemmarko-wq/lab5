
using System;
using System.Globalization;

namespace ConsoleApplication5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const double Limit = 1000000;

            double bacteria;
            double growthPercent;

            // Введення початкової кількості бактерій
            while (true)
            {
                Console.Write("Введіть початкову кількість бактерій: ");

                string input = Console.ReadLine();

                if (double.TryParse(input, NumberStyles.Float,
                        CultureInfo.CurrentCulture, out bacteria) &&
                    !double.IsNaN(bacteria) &&
                    !double.IsInfinity(bacteria) &&
                    bacteria > 0)
                {
                    break;
                }

                Console.WriteLine(
                    "Помилка! Введіть додатне скінченне число.");
            }

            // Введення відсотка приросту
            while (true)
            {
                Console.Write("Введіть приріст за годину (%): ");

                string input = Console.ReadLine();

                if (double.TryParse(input, NumberStyles.Float,
                        CultureInfo.CurrentCulture, out growthPercent) &&
                    !double.IsNaN(growthPercent) &&
                    !double.IsInfinity(growthPercent) &&
                    growthPercent > 0)
                {
                    break;
                }

                Console.WriteLine(
                    "Помилка! Введіть додатне скінченне число.");
            }

            // Таблиця росту бактерій
            int hours = 0;

            Console.WriteLine();
            Console.WriteLine("Таблиця росту бактерій");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Година\tКількість бактерій");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("{0}\t{1:F2}", hours, bacteria);

            while (bacteria <= Limit)
            {
                double nextBacteria =
                    bacteria * (1 + growthPercent / 100.0);

                if (double.IsNaN(nextBacteria) ||
                    double.IsInfinity(nextBacteria))
                {
                    Console.WriteLine(
                        "Помилка: результат обчислення занадто великий.");
                    return;
                }

                bacteria = nextBacteria;
                hours++;

                Console.WriteLine("{0}\t{1:F2}", hours, bacteria);
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine(
                "Кількість годин до перевищення ліміту: " + hours);
            Console.WriteLine(
                "Кінцева кількість бактерій: " +
                bacteria.ToString("F2", CultureInfo.CurrentCulture));

            // Рівень Б: квадрат із символів
            Console.WriteLine();
            Console.WriteLine("Рівень Б");

            int n;

            while (true)
            {
                Console.Write("Введіть розмір квадрата (3-20): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out n) && n >= 3 && n <= 20)
                {
                    break;
                }

                Console.WriteLine(
                    "Помилка! Введіть ціле число від 3 до 20.");
            }

            // Побудова квадрата
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || i == n - 1 ||
                        j == 0 || j == n - 1)
                    {
                        Console.Write("*");
                    }
                    else if (i == j || i + j == n - 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Програму завершено.");
        }
    }
}
