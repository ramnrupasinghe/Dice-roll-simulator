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
                for (int roll = 1; roll <= numberOfRolls; roll++)
                {
                    Console.Write($"Roll {roll}: ");
                    for (int die = 0; die < numberOfDice; die++)
                    {
                        int result = random.Next(1, 7);
                        Console.Write($"{result} ");
                    }
                    Console.WriteLine();
                }


                string input;
                Console.Write("Do you want to get the sequence for another number? (Y/N) ");
                input = Console.ReadLine();

                while (!(input.ToUpper() == "Y" || input.ToUpper() == "N"))
                {
                    Console.Write("Invalid input. Please enter Y or N: ");
                    input = Console.ReadLine();

                }

                if (input.ToUpper() == "N")
                {
                    Console.WriteLine("Please press enter key to end...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }
    }
}
