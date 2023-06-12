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

foreach (var test in SymmetricTree.GetTests())
{
    var result = SymmetricTree.Execute(test.root);
    Console.WriteLine(SymmetricTree.CheckResult(result, test.answer));
}

Console.ReadKey();
