namespace Route256.Sandbox
{
    public static class MapValidation
    {
        public static void Main()
        {
            var testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var nm = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();

                int n = nm[0];
                int m = nm[1];

                var map = new List<string>();
                for (int j = 0; j < nm[0]; j++)
                    map.Add(Console.ReadLine());

                var answer = "YES";
                var dot = '.';
                var colors = new HashSet<char>();
                var visitedHexagon = new Dictionary<char, HashSet<(int, int)>>();
                for (int row = 0; row < n; row++)
                {
                    for (int column = 0; column < m; column++)
                    {
                        var hexagon = map[row][column];

                        if (hexagon == dot)
                            continue;

                        if (visitedHexagon.ContainsKey(hexagon))
                        {
                            if (!visitedHexagon[hexagon].Contains(new(row, column)))
                            {
                                answer = "NO";
                                break;
                            }
                        }
                        else
                        {
                            visitedHexagon.Add(hexagon, new HashSet<(int, int)>());
                            var unVisitedSameHexagons = new Stack<(int row, int column)>();
                            unVisitedSameHexagons.Push(new(row, column));
                            while (unVisitedSameHexagons.Count > 0)
                            {
                                var unVisitedHexagon = unVisitedSameHexagons.Pop();
                                if (visitedHexagon[hexagon].Contains(unVisitedHexagon))
                                    continue;
                                else
                                    visitedHexagon[hexagon].Add(unVisitedHexagon);
                                visitedHexagon[hexagon].Add(unVisitedHexagon);
                                foreach (var neighbour in findAdjacentHexagons(unVisitedHexagon.row, unVisitedHexagon.column, map))
                                {
                                    if (map[neighbour.row][neighbour.column] != hexagon)
                                        continue;
                                    unVisitedSameHexagons.Push(neighbour);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine(answer);
            }
        }

        private static List<(int row, int column)> findAdjacentHexagons(int row, int column, List<string> map)
        {
            int rowsCount = map.Count;
            int columnsCount = map[0].Length;
            var result = new List<(int, int)>();

            if (column > 0)
            {
                if (column > 1)
                    result.Add((row, column - 2));

                if (row > 0)
                    result.Add((row - 1, column - 1));

                if (row < rowsCount - 1)
                    result.Add((row + 1, column - 1));
            }

            if (column < columnsCount - 1)
            {
                if (column < columnsCount - 2)
                    result.Add((row, column + 2));

                if (row > 0)
                    result.Add((row - 1, column + 1));

                if (row < rowsCount - 1)
                    result.Add((row + 1, column + 1));
            }

            return result;
        }
    }
}
