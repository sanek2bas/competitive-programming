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
using TopInterview150._1D_DP;
using TopInterview150.TwoPointers;
using TopInterview150.Matrix;
using Route256.Sandbox;
using Route256.Contest;
using TopInterview150.GraphGeneral;
using TopInterview150.Backtracking;
using TopInterview150.BinarySearch;
using TopInterview150.GraphBFS;
using TopInterview150.Heap;
using TopInterview150.Trie;
using TopInterview150.Kadane_sAlgorithm;
using TopInterview150.Multidimensional_DP;

internal class Program
{
    private static async Task Main(string[] args)
    {
        foreach (var test in HouseRobber.GetTests())
        {
            int result = HouseRobber.Execute(test.nums);
            Console.WriteLine(HouseRobber.CheckResult(result, test.answer));
        }
    }
}