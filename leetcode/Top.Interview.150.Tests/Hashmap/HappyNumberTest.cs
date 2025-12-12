using Top.Interview._150.Hash_Map;

namespace Hash_Map;

public class HappyNumberTest
{
    [Test]
    [Arguments(19, true)]
    [Arguments(2, false)]
    public async Task Solution(int n, bool answer)
    {
        var solution = new HappyNumber();
        var result = solution.Execute(n);
        await Assert.That(result).IsEqualTo(answer);
    }
}