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

foreach (var test in LongestRepeatingCharacterReplacement.GetTests())
{
    var result = LongestRepeatingCharacterReplacement.Execute(test.s, test.k);
    Console.WriteLine(LongestRepeatingCharacterReplacement.CheckResult(result, test.answer));
}

Console.ReadKey();
