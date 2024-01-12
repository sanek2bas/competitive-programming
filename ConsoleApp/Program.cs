using Interview.BinarySearch;
using TopInterview150.Array_String;



foreach (var test in RemoveElement.GetTests())
{
    var result = RemoveElement.Execute(test.nums, test.val);
    Console.WriteLine(RemoveElement.CheckResult(test.nums, result, test.answer));
}

Console.ReadKey();