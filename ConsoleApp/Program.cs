using Interview.BinarySearch;
using TopInterview150.Array_String;



foreach (var test in LongestCommonPrefix.GetTests())
{
    var result = LongestCommonPrefix.Execute(test.strs);
    Console.WriteLine(LongestCommonPrefix.CheckResult(result, test.answer));
}

Console.ReadKey();