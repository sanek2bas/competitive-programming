using Interview.BinarySearch;
using TopInterview150.Array_String;
using TopInterview150.TwoPointers;



foreach (var test in ContainerWithMostWater.GetTests())
{
    var result = ContainerWithMostWater.Execute(test.heights);
    Console.WriteLine(ContainerWithMostWater.CheckResult(result, test.answer));
}

Console.ReadKey();