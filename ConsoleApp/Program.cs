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



foreach (var test in AddTwoNumber.GetTests())
{
    var result = AddTwoNumber.Execute(test.node1, test.node2);
    Console.WriteLine(AddTwoNumber.CheckResult(result, test.answer));
}

Console.ReadKey();
