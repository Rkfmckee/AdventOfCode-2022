namespace Day8
{
	public static class Part2
	{
		private static int[,]? treeGrid;

		public static void Run()
		{
			var solutionDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName;
			var inputFilepath = $"{solutionDirectory}\\InputFiles\\Day8.txt";
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

			var scenicScores = new List<int>();

			for (int i = 0; i < treeGrid.GetLength(0); i++)
			{
				var rowVisible = 0;

				for (int j = 0; j < treeGrid.GetLength(1); j++)
				{
					// 0 (left), 1 (right), 2 (up), 3 (down)
					var treesInDirection = new int[4];
					var currentTreeHeight = treeGrid[i, j];

					var currentRow = Enumerable.Range(0, treeGrid.GetLength(1))
									.Select(x => treeGrid[i, x])
									.ToArray();

					var viewBlocked = false;
					for (int k = j - 1; k >= 0; k--)
					{
						var targetTreeHeight = currentRow[k];

						if (!viewBlocked)
						{
							treesInDirection[0]++;

							if (targetTreeHeight >= currentTreeHeight)
							{
								viewBlocked = true;
							}
						}
					}

					viewBlocked = false;
					for (int k = j + 1; k < currentRow.Length; k++)
					{
						var targetTreeHeight = currentRow[k];

						if (!viewBlocked)
						{
							treesInDirection[1]++;

							if (targetTreeHeight >= currentTreeHeight)
							{
								viewBlocked = true;
							}
						}
					}

					var currentCol = Enumerable.Range(0, treeGrid.GetLength(0))
									.Select(x => treeGrid[x, j])
									.ToArray();

					viewBlocked = false;
					for (int k = i - 1; k >= 0; k--)
					{
						var targetTreeHeight = currentCol[k];

						if (!viewBlocked)
						{
							treesInDirection[2]++;

							if (targetTreeHeight >= currentTreeHeight)
							{
								viewBlocked = true;
							}
						}
					}

					viewBlocked = false;
					for (int k = i + 1; k < currentCol.Length; k++)
					{
						var targetTreeHeight = currentCol[k];

						if (!viewBlocked)
						{
							treesInDirection[3]++;

							if (targetTreeHeight >= currentTreeHeight)
							{
								viewBlocked = true;
							}
						}
					}

					var scenicScore = treesInDirection[0] * treesInDirection[1] * treesInDirection[2] * treesInDirection[3];
					scenicScores.Add(scenicScore);
					Console.Write(scenicScore);
				}
				Console.WriteLine();
			}

			Console.WriteLine($"Highest scenic score: {scenicScores.Max()}");
		}
	}
}
