namespace Top.Interview._150.Graph_BFS;

public class SnakesAndLadders
{
    /// <summary>
    /// # 909
    /// https://leetcode.com/problems/snakes-and-ladders/description/
    /// You are given an n x n integer matrix board where the cells are labeled from 1 to n2 
    /// in a Boustrophedon style starting from the bottom left of the board(i.e.board[n - 1][0]) 
    /// and alternating direction each row.
    /// You start on square 1 of the board.In each move, starting from square curr, do the following:
    /// Choose a destination square next with a label in the range[curr + 1, min(curr + 6, n2)].
    /// This choice simulates the result of a standard 6-sided die roll: i.e., there are always 
    /// at most 6 destinations, regardless of the size of the board.
    /// If next has a snake or ladder, you must move to the destination of that snake or ladder.
    /// Otherwise, you move to next.
    /// The game ends when you reach the square n2.
    /// A board square on row r and column c has a snake or ladder if board[r][c] != -1.
    /// The destination of that snake or ladder is board[r][c]. 
    /// Squares 1 and n2 are not the starting points of any snake or ladder.
    /// Note that you only take a snake or ladder at most once per move. 
    /// If the destination to a snake or ladder is the start of another snake or ladder,
    ///  you do not follow the subsequent snake or ladder.
    /// For example, suppose the board is [[-1,4], [-1,3]], and on the first move, 
    /// your destination square is 2. 
    /// You follow the ladder to square 3, but do not follow the subsequent ladder to 4.
    /// Return the least number of moves required to reach the square n2.
    /// If it is not possible to reach the square, return -1.
    /// </summary>
    public int Execute(int[][] board)
    {
        int n = board.Length;
        var cells = new KeyValuePair<int, int>[n * n + 1];
        int label = 1;
        var columns = new int[n];

        for (int i = 0; i < n; i++)
            columns[i] = i;

        for (int row = n - 1; row >= 0; row--)
        {
            foreach (int column in columns)
                cells[label++] = new KeyValuePair<int, int>(row, column);
            Array.Reverse(columns);
        }
        int[] dist = new int[n * n + 1];
        Array.Fill(dist, -1);
        var queue = new Queue<int>();
        dist[1] = 0;
        queue.Enqueue(1);
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            for (int next = curr + 1; next <= Math.Min(curr + 6, n * n); next++)
            {
                int row = cells[next].Key, column = cells[next].Value;
                int destination = board[row][column] != -1 ? board[row][column] : next;
                if (dist[destination] == -1)
                {
                    dist[destination] = dist[curr] + 1;
                    queue.Enqueue(destination);
                }
            }
        }
        return dist[n * n];
    }
}