namespace Day3
{
    public static class Part2
    {
        public static void Run()
        {
            var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day3.txt";
            var reader = new StreamReader(inputFilepath);

            var totalPriority = 0;

            while (!reader.EndOfStream)
            {
                var rucksack1 = reader.ReadLine();
                var rucksack2 = reader.ReadLine();
                var rucksack3 = reader.ReadLine();

                if (rucksack1 == null || rucksack2 == null || rucksack3 == null)
                {
                    Console.WriteLine("rucksack is empty");
                    return;
                }

                var badgeItem = FindCommonItem(rucksack1, rucksack2, rucksack3);

                if (badgeItem.HasValue)
                {
                    var basePriority = char.ToUpper(badgeItem.Value) - 64;
                    var priorityValue = char.IsLower(badgeItem.Value) ? basePriority : basePriority + 26;
                    totalPriority += priorityValue;
                    Console.WriteLine($"Badge item: {badgeItem} (Priority: {priorityValue}, {totalPriority})");
                }
            }
        }

        private static char? FindCommonItem(string rucksack1, string rucksack2, string rucksack3)
        {
            foreach (var item in rucksack1)
            {
                if (rucksack2.Contains(item))
                {
                    if (rucksack3.Contains(item)) return item;
                }
            }

            Console.WriteLine("No common item found");
            return null;
        }
    }
}
