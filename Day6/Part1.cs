using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public static class Part1
    {
        public static void Run()
        {
            var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day6.txt";
            var reader = new StreamReader(inputFilepath);
            var nextLine = string.Empty;

            var markerEndIndex = null as int?;

            while ((nextLine = reader.ReadLine()) != null)
            {
                markerEndIndex = IndexOfMarkerEnd(nextLine);
                if (markerEndIndex.HasValue) break;
            }

            Console.WriteLine($"End of marker: Position {markerEndIndex}");
        }

        public static int? IndexOfMarkerEnd(string text)
        {
            for (int i = 0; i < text.Length - 3; i++)
            {
                var nextFour = $"{text[i]}{text[i + 1]}{text[i + 2]}{text[i + 3]}";
                var numRepeatingCharacters = nextFour.GroupBy(x => x).Count(x => x.Count() >= 2);

                Console.WriteLine($"{nextFour}. Repeating: {numRepeatingCharacters}");
                if (numRepeatingCharacters == 0) return (i + 4);
            }

            return null;
        }
    }
}
