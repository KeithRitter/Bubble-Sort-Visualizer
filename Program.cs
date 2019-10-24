using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleSortVisualizer
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().StartingInput();
        }

        public void StartingInput()
        {
            Console.WriteLine("Please input numbers to sort, seperated by a space.");
            var input = Console.ReadLine();

            var numsS = input.Split(' ');

            var nums = new List<int>();

            foreach (var entry in numsS)
            {
                if (!int.TryParse(entry, out var num))
                {
                    InvalidInput();
                }
                nums.Add(num);
            }

            var numsA = nums.ToArray();
            Console.WriteLine("\nInput:");
            Console.WriteLine($"{string.Join(", ", numsA)}\n");
            SortInput(numsA);
        }

        public void SortInput(int[] arr)
        {

            // for 1 repeats for 2 so the array is entirely
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                for (int n = 0; n < arr.Count() - 1; n++)
                {
                    int held = 0;
                    var numA = arr[n];
                    var numB = arr[n + 1];
                    if (numA < numB)
                    {
                        held = numA;
                        arr[n] = arr[n + 1];
                        arr[n + 1] = held;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{numA} is < {numB}. Moving {numB} up.\n");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Updated array:\n{string.Join(", ", arr)}\n");
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine($"Finished sorting.\nFinal result: {string.Join(", ", arr)}");
            FinalDisplay(arr);
        }

        public void FinalDisplay(int[] arr)
        {
            var ascending = string.Join(", ", arr);
            var descending = string.Join(", ", arr.Reverse());
            Console.Write("Descending: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{ascending} ");
            Console.ResetColor();
            Console.Write("| ");
            Console.Write("Ascending: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{descending}\n");
            Console.ResetColor();
            StartingInput();
        }

        public void InvalidInput()
        {
            Console.WriteLine("Your input was invalid. Your input must be all numbers seperated by a space.\n");
            StartingInput();
        }
    }
}
