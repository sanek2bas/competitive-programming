using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;
using TopInterview150.Intervals;
using Interview.GreedyProblems;
using TopInterview150.SlidingWindow;
using TopInterview150.Stack;
using TopInterview150.Mathematics;
using TopInterview150.LinkedList;
using TopInterview150.BinaryTreeGeneral;



foreach (var test in SameTree.GetTests())
{
    var result = SameTree.Execute(test.root1, test.root2);
    Console.WriteLine(SameTree.CheckResult(result, test.answer));
}

Console.ReadKey();