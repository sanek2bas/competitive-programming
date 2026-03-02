using Top.Interview._150.Multidimensional_DP;

namespace Multidimensional_DP;

public class EditDistanceTest
{
    [Test]
    [Arguments("horse", "ros", 3)]
    [Arguments("intention", "execution", 5)]
    public async Task Solution(string word1, string word2, int answer)
    {
        var solution = new EditDistance();

        var result = 
            solution.Execute(word1, word2);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}