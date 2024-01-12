using Interview.BinarySearch;
using TopInterview150.Array_String;



foreach (var test in RomanToInteger.GetTests())
{
    var result = RomanToInteger.Execute(test.romanNum);
    Console.WriteLine(RomanToInteger.CheckResult(result, test.answer));
}

Console.ReadKey();