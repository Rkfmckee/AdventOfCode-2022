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

var orderedCalorieCount = calorieCount.OrderByDescending(c => c).ToList();
var topThreeTotal = orderedCalorieCount[0] + orderedCalorieCount[1] + orderedCalorieCount[2];
Console.WriteLine($"Total of top 3 elves: {topThreeTotal}");