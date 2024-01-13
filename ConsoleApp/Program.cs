using Interview.BinarySearch;
using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;
using TopInterview150.Intervals;
using Interview.GreedyProblems;
using TopInterview150.SlidingWindow;



foreach (var test in GroupAnagrams.GetTests())
{
    var result = GroupAnagrams.Execute(test.strs);
    Console.WriteLine(GroupAnagrams.CheckResult(result, test.answer));
}

Console.ReadKey();