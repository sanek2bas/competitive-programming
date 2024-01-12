using Interview.BinarySearch;
using TopInterview150.Array_String;



foreach (var test in MajorityElement.GetTests())
{
    var result = MajorityElement.Execute(test.nums);
    Console.WriteLine(MajorityElement.CheckResult(result, test.answer));
}

Console.ReadKey();