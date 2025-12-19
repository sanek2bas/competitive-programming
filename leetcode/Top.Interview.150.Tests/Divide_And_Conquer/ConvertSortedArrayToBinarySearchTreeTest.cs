using Top.Interview._150.Common;
using Top.Interview._150.Divide_And_Conquer;

namespace Divide_And_Conquer;

public class ConvertSortedArrayToBinarySearchTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, TreeNode answer1, TreeNode answer2)
    {
        var solution = new ConvertSortedArrayToBinarySearchTree();

        var result = solution.Execute(nums);
        
        await Assert.That(CheckResult(result, answer1, answer2)).IsTrue();
    }

    public IEnumerable<(int[], TreeNode, TreeNode)> DataSource()
    {
        yield return (
            new int[] { -10, -3, 0, 5, 9 },
            CreateTreeNode(0, -3, 9, -10, null, 5),
            CreateTreeNode(0, -10, 5, null, -3, null, 9));
        yield return (
            new int[] { 1, 3 },
            CreateTreeNode(3, 1),
            CreateTreeNode(1, null, 3));
    }

    private bool CheckResult(TreeNode result, TreeNode answer1, TreeNode answer2)
    {
        var resultArray = result.ToArray();
        var answer1Array = answer1.ToArray();
        var answer2Array = answer2.ToArray();
        return resultArray.SequenceEqual(answer1Array)
            || resultArray.SequenceEqual(answer2Array);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}