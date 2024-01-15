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
using TopInterview150.BinaryTreeBFS;
using TopInterview150.BinarySearchTree;
using TopInterview150.Divide_Conquer;



foreach (var test in ConvertSortedArrayToBinarySearchTree.GetTests())
{
    var result = ConvertSortedArrayToBinarySearchTree.Execute(test.nums);
    Console.WriteLine(ConvertSortedArrayToBinarySearchTree.CheckResult(result, test.answer));
}

Console.ReadKey();