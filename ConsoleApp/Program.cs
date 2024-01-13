using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;
using TopInterview150.Intervals;
using Interview.GreedyProblems;
using TopInterview150.SlidingWindow;
using TopInterview150.Stack;
using TopInterview150.Mathematics;



foreach (var test in PlusOne.GetTests())
{
    var result = PlusOne.Execute(test.digits);
    Console.WriteLine(PlusOne.CheckResult(result, test.answer));
}

Console.ReadKey();