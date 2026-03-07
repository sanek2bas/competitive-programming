namespace Top.Interview._150.Graph_General;

public class EvaluateDivision
{
    /// <summary>
    /// # 399
    /// https://leetcode.com/problems/evaluate-division/description/
    /// You are given an array of variable pairs equations and an array 
    /// of real numbers values, where equations[i] = [Ai, Bi] and values[i] 
    /// represent the equation Ai / Bi = values[i]. Each Ai or Bi is a string 
    /// that represents a single variable.
    /// You are also given some queries, where queries[j] = [Cj, Dj] represents 
    /// the jth query where you must find the answer for Cj / Dj = ?.
    /// Return the answers to all queries. If a single answer cannot be determined, 
    /// return -1.0. 
    /// The input is always valid. You may assume that evaluating the queries 
    /// will not result in division by zero and that there is no contradiction. 
    /// The variables that do not occur in the list of equations are undefined, 
    /// so the answer cannot be determined for them.
    /// </summary>
    public double[] Execute(
        IList<IList<string>> equations, 
        double[] values, 
        IList<IList<string>> queries)
    {
        double[] result = new double[queries.Count];

        var graph = new Dictionary<string, Dictionary<string, double>>();
        for (int i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];
            var A = equation[0];
            var B = equation[1];
            graph.TryAdd(A, []);
            graph.TryAdd(B, []);
            double value = values[i];
            graph[A].TryAdd(B, value);
            graph[B].TryAdd(A, 1.0 / value);
        }

        for (int i = 0; i < queries.Count; i++)
        {
            var query = queries[i];
            string A = query[0];
            string B = query[1];
            if (!graph.ContainsKey(A) 
                || !graph.ContainsKey(B))
                result[i] = -1.0;
            else
                result[i] = Divide(graph, A, B, []);
        }

        return result;
    }

    private double Divide(
        Dictionary<string, Dictionary<string, double>> graph,
        string A,
        string B,
        HashSet<string> seen)
    {
        if (A == B)
            return 1.0;
        
        seen.Add(A);

        foreach (string key in graph[A].Keys) 
        {
            if (seen.Contains(key))
                continue;
            double result = Divide(graph, key, B, seen);
            if (result > 0)
                return graph[A][key] * result;
        }

        return -1.0;
    }
}
