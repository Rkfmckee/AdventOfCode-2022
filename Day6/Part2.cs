using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public static class Part2
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
            int numCharactersToSearch = 14;

            for (int i = 0; i < text.Length - numCharactersToSearch - 1; i++)
            {
                var nextChars = string.Empty;
                for (int j = 0; j < numCharactersToSearch; j++)
                {
                    nextChars += text[i + j];
                }

                var numRepeatingCharacters = nextChars.GroupBy(x => x).Count(x => x.Count() >= 2);

                Console.WriteLine($"{nextChars}. Repeating: {numRepeatingCharacters}");
                if (numRepeatingCharacters == 0) return i + numCharactersToSearch;
            }

            return null;
        }
    }
}
