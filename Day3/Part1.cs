namespace Day3
{
    public static class Part1
    {
        public static void Run()
        {
            var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day3.txt";
            var reader = new StreamReader(inputFilepath);
            var nextLine = string.Empty;

            var totalPriority = 0;

            while ((nextLine = reader.ReadLine()) != null)
            {
                var compartmentSize = nextLine.Length / 2;
                var compartment1 = nextLine.Substring(0, compartmentSize);
                var compartment2 = nextLine.Substring(compartmentSize, compartmentSize);

                var commonItem = FindCommonItem(compartment1, compartment2);
                if (commonItem.HasValue)
                {
                    // Priority is the characters placement in the alphabet
                    // which we can get through it's upper case ASCII value
                    // but also make upper case characters have a higher priority

                    var basePriority = char.ToUpper(commonItem.Value) - 64;
                    var priorityValue = char.IsLower(commonItem.Value) ? basePriority : basePriority + 26;
                    totalPriority += priorityValue;
                    Console.WriteLine($"Common item: {commonItem} (Priority: {priorityValue}, {totalPriority})");
                }
            }
        }

        private static char? FindCommonItem(string compartment1, string compartment2)
        {
            foreach (var item in compartment1)
            {
                if (compartment2.Contains(item))
                {
                    return item;
                }
            }

            Console.WriteLine("No common item found");
            return null;
        }
    }
}
