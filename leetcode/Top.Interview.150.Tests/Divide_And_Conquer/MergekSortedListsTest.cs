using Top.Interview._150.Common;
using Top.Interview._150.Divide_And_Conquer;

namespace Divide_And_Conquer;

public class MergekSortedListsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode[] lists, int[] answer)
    {
        var solution = new MergekSortedLists();

        var result = solution.Execute(lists);
        
        await Assert.That(CheckResult(result, answer)).IsTrue();
    }

    public IEnumerable<(ListNode[] lists, int[] answer)> DataSource()
    {
        yield return (
            new ListNode[]
            {
                CreateTreeNode(1, 4, 5),
                CreateTreeNode(1, 3, 4),
                CreateTreeNode(2, 6)
            },
            new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });
        yield return (
            new ListNode[0],
            new int[0]);
        yield return (
            new ListNode[] { CreateTreeNode() },
            new int[0]);
    }

    public bool CheckResult(ListNode result, int[] answer)
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