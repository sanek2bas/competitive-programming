using Interview.BinarySearch;
using Interview.HashTable;
using Interview.LinkedList;
using Interview.PrefixSum;
using Interview.Queue_Stack;

foreach (var test in ValidParentheses.GetTests())
{
    var answer = ValidParentheses.Execute(test.str);
    Console.WriteLine(answer == test.answer);
}

Console.ReadKey();
