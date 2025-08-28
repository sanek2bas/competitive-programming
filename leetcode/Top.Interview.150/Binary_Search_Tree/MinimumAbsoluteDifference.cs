namespace Top.Interview._150.Binary_Search_Tree;

public class MinimumAbsoluteDifference
{
    /// <summary>
    /// # 530
    /// https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/
    /// Given the root of a Binary Search Tree (BST), 
    /// return the minimum absolute difference between 
    /// the values of any two different nodes in the tree.
    /// </summary>
    public int Execute(TreeNode? root)
    {
        int answer = int.MaxValue;
        int prevValue = int.MaxValue;
        var queue = new Stack<TreeNode>();
        while (root != null || queue.Count > 0)
        {
            while (root != null)
            {
                queue.Push(root);
                root = root.Left;
            }
            root = queue.Pop();
            answer = Math.Min(answer, Math.Abs(root.Value - prevValue));
            prevValue = root.Value;
            root = root.Right;
        }
        return answer;
    }
}