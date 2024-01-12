using Interview.BinarySearch;
using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;



foreach (var test in SingleNumber.GetTests())
{
    var result = SingleNumber.Execute(test.nums);
    Console.WriteLine(SingleNumber.CheckResult(result, test.answer));
}

Console.ReadKey();