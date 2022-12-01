var inputFilepath = "G:\\Dev\\AdventOfCode-2022\\InputFiles\\Day1.txt";
var reader = new StreamReader(inputFilepath);
var nextLine = null as string;

var calorieCount = new List<int>();
var elfNum = 0;

while ((nextLine = reader.ReadLine()) != null)
{
	if (string.IsNullOrWhiteSpace(nextLine))
	{
		elfNum++;
		continue;
	}

	if (calorieCount.ElementAtOrDefault(elfNum) == 0)
	{
		calorieCount.Insert(elfNum, 0);
	}

	var caloriesForElf = calorieCount[elfNum];
	caloriesForElf += int.Parse(nextLine);
	calorieCount[elfNum] = caloriesForElf;
}

foreach (var calories in calorieCount)
{
	Console.WriteLine($"{calorieCount.IndexOf(calories)}: {calories}");
}

var max = calorieCount.Max();
Console.WriteLine($"Elf with most calories: {calorieCount.IndexOf(max)}, Calories: {max}.");
