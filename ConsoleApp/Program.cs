using Interview.BinarySearch;
using Interview.Dfs_Bfs;
using Interview.HashTable;
using Interview.Heap_Hash;
using Interview.LinkedList;
using Interview.PrefixSum;
using Interview.Queue_Stack;
using Interview.Sort;

foreach (var test in TopKFrequentElements.GetTests())
{
    var result = TopKFrequentElements.Execute(test.nums, test.k);
    Console.WriteLine(TopKFrequentElements.CheckResult(result, test.answer));
}

Console.ReadKey();
