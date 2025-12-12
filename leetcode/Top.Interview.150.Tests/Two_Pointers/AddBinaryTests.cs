using TopInterview150.Two_Pointers;

namespace Two_Pointers;

public class AddBinaryTest
{
    [Test]
    [Arguments("11", "1", "100")]
    [Arguments("1010", "1011", "10101")]
    public async Task Solution(string a, string b, string answer)
    {
        var solution = new AddBinary();

        var result = solution.Execute(a, b);
        
        await Assert.That(result).IsEqualTo(answer);
    }    
}