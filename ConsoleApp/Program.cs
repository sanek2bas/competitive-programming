using Interview.BinarySearch;
using TopInterview150.Array_String;



foreach (var test in MergeSortedArray.GetTests())
{
    MergeSortedArray.Execute(test.nums1, test.m, test.nums2, test.n);
    Console.WriteLine(MergeSortedArray.CheckResult(test.nums1, test.answer));
}

Console.ReadKey();