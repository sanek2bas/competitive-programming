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



foreach (var test in LinkedListCycle.GetTests())
{
    var result = LinkedListCycle.Execute(test.node);
    Console.WriteLine(LinkedListCycle.CheckResult(result, test.answer));
}

Console.ReadKey();
