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

                for (int roll = 1; roll <= numberOfRolls; roll++)
                {
                    Console.Write($"Roll {roll}: ");
                    int rollSum = 0;
                    for (int die = 0; die < numberOfDice; die++)
                    {
                        int result = random.Next(1, 7); 
                        rollSum += result;
                        Console.Write($"{result} ");
                    }
                    totalSum += rollSum;
                    minRoll = Math.Min(minRoll, rollSum);
                    maxRoll = Math.Max(maxRoll, rollSum);
                    Console.WriteLine($"(Total: {rollSum})");
                }

                Console.WriteLine($"Total Sum: {totalSum}");
                Console.WriteLine($"Average: {(double)totalSum / numberOfRolls}");
                Console.WriteLine($"Minimum Roll: {minRoll}");
                Console.WriteLine($"Maximum Roll: {maxRoll}");

                Console.Write("Do you want to roll again? (Y/N) ");
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
    }
}

