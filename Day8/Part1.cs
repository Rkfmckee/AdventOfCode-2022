using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public static class Part1
    {
        private static int[,]? treeGrid;

        public static void Run()
        {
            var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day8 test.txt";
            var reader = new StreamReader(inputFilepath);
            var nextLine = string.Empty;

            // Read through the file just to figure out the size first
            var numRows = 0;
            var numCols = 0;

            while ((nextLine = reader.ReadLine()) != null)
            {
                if (numCols == 0) numCols = nextLine.Length;
                numRows++;
            }

            // Then read through to populate the array
            reader.BaseStream.Position = 0;
            treeGrid = new int[numRows, numCols];
            int rowNum = 0;
            while ((nextLine = reader.ReadLine()) != null)
            {
                for (int i = 0; i < nextLine.Length; i++)
                {
                    var nextNum = int.Parse(nextLine[i].ToString());
                    treeGrid[rowNum, i] = nextNum;
                }
                rowNum++;
            }

            // The outside trees are always visible
            var treesVisible = (numRows * 2) + ((numCols - 2) * 2);
        }
    }
}
