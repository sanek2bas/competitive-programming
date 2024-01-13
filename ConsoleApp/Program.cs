using Interview.BinarySearch;
using TopInterview150.Array_String;
using TopInterview150.Hashmap;
using TopInterview150.BitManipulation;
using TopInterview150.Intervals;
using Interview.GreedyProblems;



foreach (var test in BestTimeToBuyAndSellStockII.GetTests())
{
    var result = BestTimeToBuyAndSellStockII.Execute(test.prices);
    Console.WriteLine(BestTimeToBuyAndSellStockII.CheckResult(result, test.answer));
}

Console.ReadKey();