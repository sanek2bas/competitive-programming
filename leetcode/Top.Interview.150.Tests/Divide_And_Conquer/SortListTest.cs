using Top.Interview._150.Common;
using Top.Interview._150.Divide_And_Conquer;

namespace Divide_And_Conquer;

public class SortListTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode head, int[] answer)
    {
        var solution = new SortList();

        var result = solution.Execute(head);
        
        await Assert.That(CheckResult(result, answer)).IsTrue();
    }

    public IEnumerable<(ListNode head, int[] answer)> DataSource()
    {
        yield return (
            CreateTreeNode(4, 2, 1, 3),
            new int[] { 1, 2, 3, 4 });
        yield return (
            CreateTreeNode(-1, 5, 3, 4, 0),
            new int[] { -1, 0, 3, 4, 5 });
        yield return (
            CreateTreeNode(),
            new int[] {});
    }

     private bool CheckResult(ListNode result, int[] answer)
    {
        for (int i = 0; i < answer.Length; i++)
        {
            if (result == null)
                return false;
            if (result.Value != answer[i])
                return false;
            result = result.Next;
        }
        return result == null;
    }

    private ListNode CreateTreeNode(params int[] values)
    {
        return ListNode.Create(values);
    }
}