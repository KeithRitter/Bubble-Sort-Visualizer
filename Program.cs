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

            foreach (var entry in numsS)                    // Parses each input as an integer and adds it to the sorted list
            {
                if (!int.TryParse(entry, out var num))
                {
                    InvalidInput();
                }
                nums.Add(num);
            }

            Console.WriteLine("\nInput:");
            Console.WriteLine($"> {string.Join("\n> ", nums)}\n");
            SortInput(nums);
        }

        public void SortInput(List<int> nums)
        {
            var sList = new SortedList<int, int>();
            int step = 0;

            for (int i = 0; i < nums.Count; i++)           // Begins sorting by comparing the value to position and dropping it down if need be. "Sinking Sort", "Bubble Sort"
            {
                var num = nums[i];
                int posA = 0;                              // Position in list
                int posB = 0;                              // Where to place the current value
                while (posA < nums.Count)
                {
                    if (num < nums[posA])
                    {
                        posB++;
                    }
                    posA++;
                }
                sList.Add(posB, num);
                step++;
                Console.WriteLine($"Step: {step}\n> {string.Join("\n> ", sList.Values)}\n");
            }

            Console.Write("Descending: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{string.Join(", ", sList.Values)} ");
            Console.ResetColor();
            Console.Write("Ascending: ");
            Console.ForegroundColor = ConsoleColor.Red;
            var reversed = sList.Reverse();
            Console.WriteLine($"{string.Join(", ", reversed.Select(x => x.Value))}\n");
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
