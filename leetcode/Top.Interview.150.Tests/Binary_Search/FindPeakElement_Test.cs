namespace Top.Interview._150;

public class FindPeakElement_Test
{
    [Test]
    [Arguments(new int[] { 1, 2, 3, 1 }, 2)]
    [Arguments(new int[] { 1, 2, 1, 3, 5, 6, 4 }, 5)]
    public void FindPeakElement(int[] nums, int answer)
    {
        var solution = new FindPeakElement();
        var result = solution.Execute(nums);
        Assert.That(result).IsEqualTo(answer);
    }

}