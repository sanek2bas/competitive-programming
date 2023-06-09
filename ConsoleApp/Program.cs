using Interview.BinarySearch;
using Interview.HashTable;
using Interview.LinkedList;
using Interview.PrefixSum;

foreach (var test in BinarySearch.GetTests())
{
    var answer = BinarySearch.Execute(test.numbers, test.target);
    Console.WriteLine(answer == test.answer);
}

Console.ReadKey();
