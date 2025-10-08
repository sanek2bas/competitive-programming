using Top.Interview._150.Linked_List;

namespace Linked_List;

public class RotateList_Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task RotateList(ListNode head, int k, int[] answer)
    {
        var solution = new RotateList();
        var result = solution.Execute(head, k);
        await Assert.That(ListNode.ToArray(result)).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode head, int k, int[] answer)> DataSource()
    {
         yield return (
            ListNode.Map(1, 2, 3, 4, 5),
            2,
            new int[] { 4, 5, 1, 2, 3 });
        yield return (
            ListNode.Map(0, 1, 2), 
            4,
            new int[] {2, 0, 1});
    }
}