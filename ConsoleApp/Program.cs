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


//foreach (var test in DataCompression.GetTests())
//{
//    var result = DataCompression.Execute(test.numbers);
//    Console.WriteLine(DataCompression.CheckResult(result, test.answer));
//}


int testCount = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < testCount; i++)
{
    var count = Convert.ToInt32(Console.ReadLine());
    var numbers = Console.ReadLine()
                         .Split(' ')
                         .Select(x => Convert.ToInt32(x))
                         .ToArray();
    var result = Execute(numbers);
    Console.WriteLine(result.Length);
    Console.WriteLine("{0}", string.Join(" ", result));
}

static int[] Execute(int[] numbers)
{
    var result = new List<int>();
    int step = 0;
    int firstNum = numbers[0];
    int countNum = 0;
    for (int i = 1; i < numbers.Length; i++)
    {
        if (step == 0)
        {
            if (Math.Abs(numbers[i] - numbers[i - 1]) == 1)
            {
                step = numbers[i] - numbers[i - 1];
                countNum++;
            }
            else
            {
                result.Add(firstNum);
                result.Add(countNum * step);
                firstNum = numbers[i];
            }
        }
        else
        {
            if (numbers[i - 1] + step == numbers[i])
            {
                countNum++;
            }
            else
            {
                result.Add(firstNum);
                result.Add(countNum * step);
                step = 0;
                countNum = 0;
                firstNum = numbers[i];
            }
        }
    }
    result.Add(firstNum);
    result.Add(countNum * step);
    return result.ToArray();
}

Console.ReadKey();