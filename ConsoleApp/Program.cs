using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;
using TopInterview150.Intervals;
using Interview.GreedyProblems;
using TopInterview150.SlidingWindow;



foreach (var test in TwoSum.GetTests())
{
    var result = TwoSum.Execute(test.nums, test.target);
    Console.WriteLine(TwoSum.CheckResult(result, test.answer));
}

Console.ReadKey();