using Interview.BinarySearch;
using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;
using TopInterview150.Intervals;



foreach (var test in MergeIntervals.GetTests())
{
    var result = MergeIntervals.Execute(test.intervals);
    Console.WriteLine(MergeIntervals.CheckResult(result, test.answer));
}

Console.ReadKey();