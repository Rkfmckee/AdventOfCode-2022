var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day2.txt";
var reader = new StreamReader(inputFilepath);
var nextLine = null as string;

// Rock (A, X), Paper (B, Y), Scissors (C, Z)
// { 'A', 'Z' } means A beats Z
var winningShapes = new Dictionary<string, string>
{
    { "A", "Z" },
    { "B", "X" },
    { "C", "Y" },
    { "X", "C" },
    { "Y", "A" },
    { "Z", "B" }
};

// Rock (1), Paper (2), Scissors (3)
// Win (6), Draw (3), Lose (0)
var shapeScores = new Dictionary<string, int>
{
    { "A", 1 },
    { "B", 2 },
    { "C", 3 },
    { "X", 1 },
    { "Y", 2 },
    { "Z", 3 }
};

var playerScore = 0;

while ((nextLine = reader.ReadLine()) != null)
{
    var shapes = nextLine.Split(' ');
    var enemyShape = shapes[0];
    var playerShape = shapes[1];

    var enemyWins = winningShapes[enemyShape] == playerShape;
    var playerWins = winningShapes[playerShape] == enemyShape;
    var draw = !enemyWins && !playerWins;

    playerScore += shapeScores[playerShape];

    if (playerWins) playerScore += 6;
    if (draw) playerScore += 3;
}

Console.WriteLine($"Final score: {playerScore}");