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
using Multitrack;
using Route256.Sandbox;
using Route256.Contest;
using TopInterview150.GraphGeneral;

using StreamWriter st = new StreamWriter("qwerty.txt");
var t = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < t; i++)
{
    var number = Console.ReadLine();
    var str = Console.ReadLine();
    var result = ThreeRightQueue.Execute(str);
    st.WriteLine(result ? "Yes" : "No");
}



//foreach (var test in ThreeRightQueue.GetTests())
//{
//    var result = ThreeRightQueue.Execute(test.queue);
//    Console.WriteLine(ThreeRightQueue.CheckResult(result, test.answer));
//}

//Console.ReadKey();