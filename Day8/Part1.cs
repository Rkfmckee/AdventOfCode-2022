namespace Day8
{
	public static class Part1
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

			// The outside trees are always visible
			var numTreesVisible = (numRows * 2) + ((numCols - 2) * 2);

			for (int i = 1; i < treeGrid.GetLength(0) - 1; i++)
			{
				var rowVisible = 0;

				for (int j = 1; j < treeGrid.GetLength(1) - 1; j++)
				{
					// 0 (left), 1 (right), 2 (up), 3 (down)
					var visibleDirections = new bool[4] { true, true, true, true };
					var currentTreeHeight = treeGrid[i, j];

					var currentRow = Enumerable.Range(0, treeGrid.GetLength(1))
									.Select(x => treeGrid[i, x])
									.ToArray();

					for (int k = j - 1; k >= 0; k--)
					{
						var targetTreeHeight = currentRow[k];

						if (visibleDirections[0])
						{
							if (targetTreeHeight >= currentTreeHeight)
							{
								visibleDirections[0] = false;
							}
							else
							{
								visibleDirections[0] = true;
							}
						}
					}

					for (int k = j + 1; k < currentRow.Length; k++)
					{
						var targetTreeHeight = currentRow[k];

						if (visibleDirections[1])
						{
							if (targetTreeHeight >= currentTreeHeight)
							{
								visibleDirections[1] = false;
							}
							else
							{
								visibleDirections[1] = true;
							}
						}
					}

					var currentCol = Enumerable.Range(0, treeGrid.GetLength(0))
									.Select(x => treeGrid[x, j])
									.ToArray();

					for (int k = i - 1; k >= 0; k--)
					{
						var targetTreeHeight = currentCol[k];

						if (visibleDirections[2])
						{
							if (targetTreeHeight >= currentTreeHeight)
							{
								visibleDirections[2] = false;
							}
							else
							{
								visibleDirections[2] = true;
							}
						}
					}

					for (int k = i + 1; k < currentCol.Length; k++)
					{
						var targetTreeHeight = currentCol[k];

						if (visibleDirections[3])
						{
							if (targetTreeHeight >= currentTreeHeight)
							{
								visibleDirections[3] = false;
							}
							else
							{
								visibleDirections[3] = true;
							}
						}
					}

					if (visibleDirections.Any(x => x)) rowVisible++;

					Console.Write(treeGrid[i, j]);
				}

				numTreesVisible += rowVisible;
				Console.WriteLine($", {rowVisible}");
			}

			Console.WriteLine($"Number of trees visible: {numTreesVisible}");
		}
	}
}
