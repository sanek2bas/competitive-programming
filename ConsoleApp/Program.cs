using Interview.BinarySearch;
using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.TwoPointers;



foreach (var test in RansomNote.GetTests())
{
    var result = RansomNote.Execute(test.ransomNote, test.magazine);
    Console.WriteLine(RansomNote.CheckResult(result, test.answer));
}

Console.ReadKey();