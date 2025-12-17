using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class PartitionListTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode<int> head, int x, int[] answer)
    {
        var solution = new RotateList();

        var result = solution.Execute(head, x);
        
        await Assert.That(ListNode<int>.ConvertToArray(result)).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode<int>? head, int x, int[] answer)> DataSource()
    {
        yield return (
           ListNode<int>.Create(1, 2, 3, 4, 5),
            2,
            new int[] { 4, 5, 1, 2, 3 });
        yield return (
            ListNode<int>.Create(0, 1, 2), 
            4,
            new int[] {2, 0, 1});
    }
}