namespace Day2
{
    public static class Part2
    {
        public static void Run()
        {
            var inputFilepath = "C:\\Dev\\AdventOfCode\\InputFiles\\Day2.txt";
            var reader = new StreamReader(inputFilepath);
            var nextLine = string.Empty;

            // Rock (A), Paper (B), Scissors (C)
            // Lose (X), Draw (Y), Win (Z)

            // Rock (1), Paper (2), Scissors (3)
            // Win (6), Draw (3), Lose (0)
            var winScores = new Dictionary<string, int>
            {
                { "X", 0 },
                { "Y", 3 },
                { "Z", 6 }
            };

            var shapeScores = new Dictionary<string, int>
            {
                { "R", 1 },
                { "P", 2 },
                { "S", 3 }
            };

            var playerScore = 0;

            while ((nextLine = reader.ReadLine()) != null)
            {
                var game = nextLine.Split(' ');
                var enemyShape = game[0];
                var playerEndState = game[1];
                var playerShape = null as string;

                switch (enemyShape)
                {
                    case "A":
                        if (playerEndState.Equals("X")) playerShape = "S";
                        if (playerEndState.Equals("Y")) playerShape = "R";
                        if (playerEndState.Equals("Z")) playerShape = "P";
                        break;

                    case "B":
                        if (playerEndState.Equals("X")) playerShape = "R";
                        if (playerEndState.Equals("Y")) playerShape = "P";
                        if (playerEndState.Equals("Z")) playerShape = "S";
                        break;

                    case "C":
                        if (playerEndState.Equals("X")) playerShape = "P";
                        if (playerEndState.Equals("Y")) playerShape = "S";
                        if (playerEndState.Equals("Z")) playerShape = "R";
                        break;
                }

                if (!string.IsNullOrEmpty(playerShape)) playerScore += shapeScores[playerShape];
                playerScore += winScores[playerEndState];
            }

            Console.WriteLine($"Final score: {playerScore}");
        }
    }
}