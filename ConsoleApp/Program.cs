using Interview.BinarySearch;
using Interview.Dfs_Bfs;
using Interview.HashTable;
using Interview.Heap_Hash;
using Interview.LinkedList;
using Interview.PrefixSum;
using Interview.Queue_Stack;
using Interview.SlidingWindow;
using Interview.Sort;
using Interview.Tree;
using Interview.TwoPointers;

foreach (var test in SameTree.GetTests())
{
    var result = SameTree.Execute(test.p, test.q);
    Console.WriteLine(SameTree.CheckResult(result, test.answer));
}

Console.ReadKey();
