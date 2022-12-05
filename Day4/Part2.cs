using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public static class Part2
    {
        public static void Run()
        {
            var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day4.txt";
            var reader = new StreamReader(inputFilepath);
            var nextLine = string.Empty;

            var overlappingPairs = 0;

            while ((nextLine = reader.ReadLine()) != null)
            {
                var assignmentSections = new List<int>[2];
                var assignments = nextLine.Split(',');
                var assignmentBounds = new string[2, 2]
                {
                    { assignments[0].Split('-')[0], assignments[0].Split('-')[1] },
                    { assignments[1].Split('-')[0], assignments[1].Split('-')[1] }
                };

                for (int i = 0; i < assignmentBounds.GetLength(0); i++)
                {
                    var lowerBound = int.Parse(assignmentBounds[i, 0]);
                    var upperBound = int.Parse(assignmentBounds[i, 1]);
                    assignmentSections[i] = new List<int>();

                    for (int j = lowerBound; j <= upperBound; j++)
                    {
                        assignmentSections[i].Add(j);
                    }
                }

                // If any of the array elements overlap
                if (assignmentSections[0].Any(x => assignmentSections[1].Contains(x)))
                    overlappingPairs++;
            }

            Console.WriteLine($"Overlapping pairs: {overlappingPairs}");
        }
    }
}
