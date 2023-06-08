using Interview.HashTable;
using Interview.LinkedList;
using Interview.PrefixSum;

//foreach(var test in MinimumSizeSubarraySum.GetTests())
//{
//    var answer = MinimumSizeSubarraySum.Execute(test.target, test.numbers);
//    Console.WriteLine(answer == test.answer);
//}

//foreach (var test in MergeSortedLists.GetTests())
//{
//    var answer = MergeSortedLists.Execute(test.nodes);
//    Console.WriteLine(MergeSortedLists.ConvertToString(answer) == test.answer);
//}

foreach (var test in SingleNumber.GetTests())
{
    var answer = SingleNumber.Execute(test.numbers);
    Console.WriteLine(answer == test.answer);
}

Console.ReadKey();
