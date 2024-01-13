using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;
using TopInterview150.Intervals;
using Interview.GreedyProblems;
using TopInterview150.SlidingWindow;
using TopInterview150.Stack;
using TopInterview150.Mathematics;
using TopInterview150.LinkedList;



foreach (var test in MergeTwoSortedLists.GetTests())
{
    var result = MergeTwoSortedLists.Execute(test.node1, test.node2);
    Console.WriteLine(MergeTwoSortedLists.CheckResult(result, test.answer));
}

Console.ReadKey();