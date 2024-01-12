using Interview.BinarySearch;
using TopInterview150.Array_String;



foreach (var test in LengthOfLastWord.GetTests())
{
    var result = LengthOfLastWord.Execute(test.str);
    Console.WriteLine(LengthOfLastWord.CheckResult(result, test.answer));
}

Console.ReadKey();