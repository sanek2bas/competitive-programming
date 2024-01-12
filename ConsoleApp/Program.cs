using Interview.BinarySearch;
using TopInterview150.Array_String;
using TopInterview150.TwoPointers;



foreach (var test in ValidPalindrome.GetTests())
{
    var result = ValidPalindrome.Execute(test.str);
    Console.WriteLine(ValidPalindrome.CheckResult(result, test.answer));
}

Console.ReadKey();