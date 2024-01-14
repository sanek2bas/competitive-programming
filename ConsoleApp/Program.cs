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



foreach (var test in SymmetricTree.GetTests())
{
    var result = SymmetricTree.Execute(test.root);
    Console.WriteLine(SymmetricTree.CheckResult(result, test.answer));
}

Console.ReadKey();