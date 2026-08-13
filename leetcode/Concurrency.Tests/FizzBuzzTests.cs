using System.Text;

namespace Concurrency.Tests;

public class FizzBuzzTests
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int n, IList<string> expected)
    {
        var result = new List<object>();
        var fizzbuzz = new FizzBuzz(n);
        
        var fizzThread = new Thread(() => 
            fizzbuzz.Fizz(() => result.Add("fizz")));
        var buzzThread = new Thread(() => 
            fizzbuzz.Buzz(() => result.Add("buzz")));
        var fizzbuzzThread = new Thread(() => 
            fizzbuzz.Fizzbuzz(() => result.Add("fizzbuzz")));
        var numberThread = new Thread(() => 
            fizzbuzz.Number((x) => result.Add(x.ToString())));
        
        fizzThread.Start();
        buzzThread.Start();
        fizzbuzzThread.Start();
        numberThread.Start();

        fizzThread.Join();
        buzzThread.Join();
        fizzbuzzThread.Join();
        numberThread.Join();

        await Assert.That(result)
                    .IsEquivalentTo(expected);
    }

    public IEnumerable<(int n, IList<string> expected)> DataSource()
    {
        yield return (15,
            new List<string>{ 
                "1", "2","fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "13", "14", "fizzbuzz"});
        
        yield return (5,
            new List<string>{ 
                "1", "2", "fizz", "4", "buzz"});
    }
}