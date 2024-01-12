using Interview.BinarySearch;
using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;



foreach (var test in IsomorphicStrings.GetTests())
{
    var result = IsomorphicStrings.Execute(test.s, test.t);
    Console.WriteLine(IsomorphicStrings.CheckResult(result, test.answer));
}

Console.ReadKey();