using Interview.BinarySearch;
using TopInterview150.Array_String;



foreach (var test in RemoveDuplicatesFromSortedArray.GetTests())
{
    var result = RemoveDuplicatesFromSortedArray.Execute(test.nums);
    Console.WriteLine(RemoveDuplicatesFromSortedArray.CheckResult(test.nums, result, test.answer));
}

Console.ReadKey();