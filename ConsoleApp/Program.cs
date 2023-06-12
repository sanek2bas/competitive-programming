using Interview.BinarySearch;
using Interview.Dfs_Bfs;
using Interview.GreedyProblems;
using Interview.HashTable;
using Interview.Heap_Hash;
using Interview.LinkedList;
using Interview.PrefixSum;
using Interview.Queue_Stack;
using Interview.SlidingWindow;
using Interview.Sort;
using Interview.Tree;
using Interview.TwoPointers;



foreach (var test in TwoSum.GetTests())
{
    var result = TwoSum.Execute(test.numbers, test.target);
    Console.WriteLine(TwoSum.CheckResult(result, test.answer));
}

Console.ReadKey();
