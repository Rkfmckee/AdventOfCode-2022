using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public static class Part1
    {
        public static void Run()
        {
            var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day7.txt";
            var reader = new StreamReader(inputFilepath);
            var nextLine = string.Empty;

            var directorySizes = new Dictionary<string, int>();
            var currentDirectory = string.Empty;

            while ((nextLine = reader.ReadLine()) != null)
            {
                var lineParts = nextLine.Split(' ');

                if (nextLine.StartsWith('$'))
                {
                    // Command
                    // Ignore the $ signifying a command
                    var command = lineParts[1];

                    if (command.Equals("cd"))
                    {
                        // Change directory
                        // Only the cd command has a second parameter
                        var directory = lineParts[2];
                    }
                    else
                    {
                        // List current directory
                    }
                }
                else
                {
                    if (nextLine.StartsWith("dir"))
                    {
                        // Directory name
                        // Ignore the 'dir' signifying a directory
                        var directoryName = lineParts[1];
                    }
                    else
                    {
                        //File size and name
                        var fileSize = lineParts[0];
                        var fileName = lineParts[1];
                    }
                }
            }
        }
    }
}
