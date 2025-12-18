using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class PopulationNextRightPointersInEachNode2Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeListNode root, int?[] answer)
    {
        var solution = new PopulationNextRightPointersInEachNode2();

        var result = solution.Execute(root);
        
        await Assert.That(CheckResult(result, answer)).IsTrue();
    }

    public IEnumerable<(TreeListNode root, int?[] answer)> DataSource()
    {
        yield return (
            CreateTreeListNode(1, 2, 3, 4, 5, null, 7),
            [ 1, null, 2, 3, null, 4, 5, 7, null ]);
        yield return (
            CreateTreeListNode(),
            []);
    }

    private TreeListNode CreateTreeListNode(params int?[] values)
    {
        return TreeListNode.Create(values);
    }

    private bool CheckResult(TreeListNode result, int?[] answer)
    {
        if (result == null)
            return answer.Length == 0;

        int idx = 0;
        while (result != null)
        {
            if (result.Value != answer[idx])
                return false;
            idx++;
        }

        return idx >= answer.Length;
    }
}