using Top.Interview._150.Two_Pointers;

namespace Two_Pointers;

public class ContainerWithMostWaterTest
{
    [Test]
    [Arguments(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [Arguments(new int[] { 1, 1 }, 1)]
    public async Task Solution(int[] height, int answer)
    {
        var solution = new ContainerWithMostWater();
        var result = solution.Execute(height);
        await Assert.That(result).IsEqualTo(answer);
    }
}