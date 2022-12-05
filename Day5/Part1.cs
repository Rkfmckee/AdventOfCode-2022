using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public static class Part1
    {
        public static void Run()
        {
            var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day5.txt";
            var reader = new StreamReader(inputFilepath);
            var nextLine = string.Empty;

            var topCrates = string.Empty;
            var stacks = new Stack<char>[9]
            {
                new Stack<char>(new[] {'S', 'C', 'V', 'N'}),
                new Stack<char>(new[] {'Z', 'M', 'J', 'H', 'N', 'S'}),
                new Stack<char>(new[] {'M', 'C', 'T', 'G', 'J', 'N', 'D'}),
                new Stack<char>(new[] {'T', 'D', 'F', 'J', 'W', 'R', 'M'}),
                new Stack<char>(new[] {'P', 'F', 'H'}),
                new Stack<char>(new[] {'C', 'T', 'Z', 'H', 'J'}),
                new Stack<char>(new[] {'D', 'P', 'R', 'Q', 'F', 'S', 'L', 'Z'}),
                new Stack<char>(new[] {'C', 'S', 'L', 'H', 'D', 'F', 'P', 'W'}),
                new Stack<char>(new[] {'D', 'S', 'M', 'P', 'F', 'N', 'G', 'Z'}),
            };

            while ((nextLine = reader.ReadLine()) != null)
            {
                if (!nextLine.Contains("move")) continue;

                // Indexes 1, 3 and 5 contain the useful values so ignore all the others
                // -1 to align with 'stacks' array indexes
                var parts = nextLine.Split(' ');
                var numToMove = int.Parse(parts[1]);
                var startStack = int.Parse(parts[3]) - 1;
                var endStack = int.Parse(parts[5]) - 1;

                for (int i = 0; i < numToMove; i++)
                {
                    var crate = stacks[startStack].Pop();
                    stacks[endStack].Push(crate);
                }
            }

            foreach (var stack in stacks)
            {
                topCrates += stack.Peek();
            }

            Console.WriteLine($"Top crates: {topCrates}");
        }
    }
}
