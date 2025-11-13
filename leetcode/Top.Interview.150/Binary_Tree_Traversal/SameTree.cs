namespace Top.Interview._150.Binary_Tree
{
    public class SameTree
    {
        /// <summary>
        /// # 100
        /// https://leetcode.com/problems/same-tree/description/
        /// Given the roots of two binary trees p and q, 
        /// write a function to check if they are the same or not.
        /// Two binary trees are considered the same 
        /// if they are structurally identical, 
        /// and the nodes have the same value.
        /// </summary>
        public bool Execute(TreeNode p, TreeNode q)
        {
            if (p == null 
                && q == null)
                return true;

            if (p == null 
                || q == null 
                || p.Value != q.Value)
                return false;

            return Execute(p.Left, q.Left)
                && Execute(p.Right, q.Right);
        }
    }
}
