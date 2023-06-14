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



foreach (var test in SearchInRotatedSortedArray.GetTests())
{
    var result = SearchInRotatedSortedArray.Execute(test.nums, test.target);
    Console.WriteLine(SearchInRotatedSortedArray.CheckResult(result, test.answer));
}

Console.ReadKey();
