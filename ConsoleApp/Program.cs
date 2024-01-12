using Interview.BinarySearch;
using TopInterview150.Array_String;



foreach (var test in BestTimeToBuyAndSellStock.GetTests())
{
    var result = BestTimeToBuyAndSellStock.Execute(test.nums);
    Console.WriteLine(BestTimeToBuyAndSellStock.CheckResult(result, test.answer));
}

Console.ReadKey();