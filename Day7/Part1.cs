using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public static class Part1
    {
        private static Dictionary<string, int> directorySizes = new Dictionary<string, int>
        {
            //{ directoryName, size }
            { "home", 0 }
        };

        public static void Run()
        {
            var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day7.txt";
            var reader = new StreamReader(inputFilepath);
            var nextLine = string.Empty;

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
                        // Can ignore the ls command
                        var directory = lineParts[2];

                        if (directory.Equals("/"))
                        {
                            currentDirectory = "home";
                        } 
                        else if (directory.Equals(".."))
                        {
                            currentDirectory = GetPreviousDirectory(currentDirectory);
                        }
                        else
                        {
                            currentDirectory += $"/{directory}";

                            if (!directorySizes.ContainsKey(currentDirectory))
                            {
                                directorySizes[currentDirectory] = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (!nextLine.StartsWith("dir"))
                    {
                        //File size and name
                        var fileSize = int.Parse(lineParts[0]);
                        var fileName = lineParts[1];

                        AddFileSizeToDirectory(currentDirectory, fileSize);
                    }
                }
            }

            var totalSmallDirectorySize = 0;
            var smallDirectorySizeLimit = 100000;

            foreach(var directory in directorySizes.Keys)
            {
                var directorySize = directorySizes[directory];

                if (directorySize <= smallDirectorySizeLimit)
                    totalSmallDirectorySize += directorySize;

                Console.WriteLine($"{directory}: {directorySize}");
            }

            Console.WriteLine("----------");
            Console.WriteLine($"Small directory total: {totalSmallDirectorySize}");
        }

        private static string GetPreviousDirectory(string directory)
        {
            // Remove the most recent directory, including the / before

            var previousDirectoryIndex = directory.LastIndexOf('/');

            if (previousDirectoryIndex != -1)
                return directory.Substring(0, previousDirectoryIndex);
            else
                return string.Empty;
        }

        private static void AddFileSizeToDirectory(string directory, int fileSize)
        {
            if (directorySizes.ContainsKey(directory))
                directorySizes[directory] += fileSize;
            else
                Console.WriteLine($"{directory} hasn't been stored yet.");

            // If we're in a subdirectory, add the current fileSize to all parent directories
            var parent = GetPreviousDirectory(directory);
            if (parent != string.Empty) AddFileSizeToDirectory(parent, fileSize);
        }
    }
}
