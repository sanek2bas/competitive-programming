using Interview.BinarySearch;
using TopInterview150.Array_String;



foreach (var test in FindIndexOfFirstOccurrenceInString.GetTests())
{
    var result = FindIndexOfFirstOccurrenceInString.Execute(test.haystack, test.needle);
    Console.WriteLine(FindIndexOfFirstOccurrenceInString.CheckResult(result, test.answer));
}

Console.ReadKey();