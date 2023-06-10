using Interview.BinarySearch;
using Interview.Dfs_Bfs;
using Interview.HashTable;
using Interview.LinkedList;
using Interview.PrefixSum;
using Interview.Queue_Stack;

foreach (var test in NumberOfIslands.GetTests())
{
    var answer = NumberOfIslands.Execute(test.grid);
    Console.WriteLine(answer == test.answer);
}

Console.ReadKey();
