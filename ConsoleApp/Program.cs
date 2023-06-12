using Interview.BinarySearch;
using Interview.Dfs_Bfs;
using Interview.HashTable;
using Interview.Heap_Hash;
using Interview.LinkedList;
using Interview.PrefixSum;
using Interview.Queue_Stack;
using Interview.SlidingWindow;
using Interview.Sort;
using Interview.TwoPointers;

foreach (var test in MergeSortedLists.GetTests())
{
    var result = MergeSortedLists.Execute(test.nodes);
    Console.WriteLine(MergeSortedLists.CheckResult(result, test.answer));
}

Console.ReadKey();
