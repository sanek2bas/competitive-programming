using System;
using Infrastructure;

namespace TopInterview150.GraphGeneral;

public class CloneGraph
{
    /// <summary>
    /// Given a reference of a node in a connected undirected graph.
    /// Return a deep copy (clone) of the graph.
    /// </summary>
    public static Node Execute(Node node)
    {
    }

доделать
    public static IEnumerable<(Node node, Node answer)> GetTests()
    {
        yield return (
            Node.Map(
                new List<int[]>
                {
                    new int[] { }
                                })
    new char[][]
    {
                    new char[] { 'X', 'X', 'X', 'X' },
                    new char[] { 'X', 'O', 'O', 'X' },
                    new char[] { 'X', 'X', 'O', 'X' },
                    new char[] { 'X', 'O', 'X', 'X' },
    },
    new char[][]
    {
                    new char[] { 'X', 'X', 'X', 'X' },
                    new char[] { 'X', 'X', 'X', 'X' },
                    new char[] { 'X', 'X', 'X', 'X' },
                    new char[] { 'X', 'O', 'X', 'X' }
    });
        yield return (
            new char[][]
            {
                    new char[] { 'X' }
            },
            new char[][]
            {
                    new char[] { 'X' }
            });
    }

    public static bool CheckResult(char[][] result, char[][] answer)
    {
        if (result.Length != answer.Length)
            return false;
        for(int i = 0; i < result.Length; i++)
        {
            if (!result[i].SequenceEqual(answer[i]))
                return false;
        }
        return true;
    }
}