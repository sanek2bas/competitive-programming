using Interview.BinarySearch;
using Interview.Dfs_Bfs;
using Interview.HashTable;
using Interview.LinkedList;
using Interview.PrefixSum;
using Interview.Queue_Stack;
using Interview.Sort;

foreach (var test in MergeIntervals.GetTests())
{
    var answer = MergeIntervals.Execute(test.intervals);
    Console.WriteLine(MergeIntervals.EqualAnswer(answer, test.answer));
}

Console.ReadKey();
