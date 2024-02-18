using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contact_book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dice Rolling Simulator");

            while (true)
            {
                Console.Write("Enter the number of dice: ");
                if (!int.TryParse(Console.ReadLine(), out int numberOfDice) || numberOfDice <= 0)
                {
                    Console.WriteLine("Please enter a valid positive integer for the number of dice.");
                    continue;
                }

                Console.Write("Enter the number of sides for each die: ");
                if (!int.TryParse(Console.ReadLine(), out int sides) || sides <= 0)
                {
                    Console.WriteLine("Please enter a valid positive integer for the number of sides.");
                    continue;
                }

                Console.Write("Enter the number of rolls: ");
                if (!int.TryParse(Console.ReadLine(), out int numberOfRolls) || numberOfRolls <= 0)
                {
                    Console.WriteLine("Please enter a valid positive integer for the number of rolls.");
                    continue;
                }

                Console.WriteLine("\nRolling the dice...");

                Random random = new Random();
                int totalSum = 0;
                int minRoll = int.MaxValue;
                int maxRoll = int.MinValue;
                List<int> rollHistory = new List<int>();

                for (int roll = 1; roll <= numberOfRolls; roll++)
                {
                    Console.Write($"Roll {roll}: ");
                    int rollSum = 0;
                    for (int die = 0; die < numberOfDice; die++)
                    {
                        int result = random.Next(1, sides + 1);
                        rollSum += result;
                        Console.Write($"{result} ");
                    }
                    totalSum += rollSum;
                    minRoll = Math.Min(minRoll, rollSum);
                    maxRoll = Math.Max(maxRoll, rollSum);
                    rollHistory.Add(rollSum);
                    Console.WriteLine($"(Total: {rollSum})");
                }

                Console.WriteLine($"\nTotal Sum: {totalSum}");
                Console.WriteLine($"Average: {(double)totalSum / numberOfRolls}");
                Console.WriteLine($"Minimum Roll: {minRoll}");
                Console.WriteLine($"Maximum Roll: {maxRoll}");

                Console.WriteLine("\nRoll History:");
                foreach (var roll in rollHistory)
                {
                    Console.Write($"{roll} ");
                }

                Console.WriteLine("\n\nAdditional Statistics:");
                Console.WriteLine($"Standard Deviation: {CalculateStandardDeviation(rollHistory)}");
                Console.WriteLine("Roll Frequency Distribution:");
                DisplayFrequencyDistribution(rollHistory);

                Console.Write("\nDo you want to roll again? (Y/N) ");
                string input = Console.ReadLine();

                while (!(input.ToUpper() == "Y" || input.ToUpper() == "N"))
                {
                    Console.Write("Invalid input. Please enter Y or N: ");
                    input = Console.ReadLine();
                }

                if (input.ToUpper() == "N")
                {
                    Console.WriteLine("Press enter key to exit...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }

        static double CalculateStandardDeviation(List<int> values)
        {
            double mean = values.Average();
            double variance = values.Sum(val => Math.Pow(val - mean, 2)) / values.Count;
            return Math.Sqrt(variance);
        }

        static void DisplayFrequencyDistribution(List<int> values)
        {
            var frequencyDict = values.GroupBy(x => x)
                                      .OrderBy(x => x.Key)
                                      .ToDictionary(grp => grp.Key, grp => grp.Count());

            foreach (var kvp in frequencyDict)
            {
                Console.WriteLine($"Value: {kvp.Key}, Frequency: {kvp.Value}");
            }
        }
    }
}

