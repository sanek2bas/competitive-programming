using Interview.BinarySearch;
using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;
using TopInterview150.Intervals;
using Interview.GreedyProblems;
using TopInterview150.SlidingWindow;



foreach (var test in MinimumSizeSubarraySum.GetTests())
{
    var result = MinimumSizeSubarraySum.Execute(test.val, test.nums);
    Console.WriteLine(MinimumSizeSubarraySum.CheckResult(result, test.answer));
}

Console.ReadKey();