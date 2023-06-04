using Interview.PrefixSum;

foreach(var test in MinimumSizeSubarraySum.GetTests())
{
    var answer = MinimumSizeSubarraySum.MinSubArrayLen(test.target, test.numbers);
    Console.WriteLine(answer == test.answer);
}

Console.ReadKey();
