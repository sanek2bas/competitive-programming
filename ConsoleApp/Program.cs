using Interview.BinarySearch;
using Interview.Dfs_Bfs;
using Interview.HashTable;
using Interview.Heap_Hash;
using Interview.LinkedList;
using Interview.PrefixSum;
using Interview.Queue_Stack;
using Interview.Sort;
using Interview.TwoPointers;

foreach (var test in ContainerWithMostWater.GetTests())
{
    var result = ContainerWithMostWater.Execute(test.heights);
    Console.WriteLine(ContainerWithMostWater.CheckResult(result, test.answer));
}

Console.ReadKey();
