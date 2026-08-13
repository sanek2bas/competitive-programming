using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_General;

public class BinarySearchTreeIterator
{
    /// <summary>
    /// # 173
    /// https://leetcode.com/problems/binary-search-tree-iterator/description/
    /// Implement the BSTIterator class that represents an iterator over 
    /// the in-order traversal of a binary search tree (BST):
    /// BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. 
    /// The root of the BST is given as part of the constructor. 
    /// The pointer should be initialized to a non-existent number smaller than any element in the BST.
    /// boolean hasNext() Returns true if there exists a number in the traversal 
    /// to the right of the pointer, otherwise returns false.
    /// int next() Moves the pointer to the right, then returns the number at the pointer.
    /// Notice that by initializing the pointer to a non-existent smallest number,
    /// the first call to next() will return the smallest element in the BST.
    /// You may assume that next() calls will always be valid. That is, 
    /// there will be at least a next number in the in-order traversal when next() is called.
    /// </summary>
    
    private int currentIndex;
    private List<int> values;

    public BinarySearchTreeIterator(TreeNode root) 
    {
        currentIndex = 0;
        values = new List<int>();
        PerformInorderTraversal(root);
    }
    
    public int Next() 
    {
        return values[currentIndex++];
    }
    
    public bool HasNext() 
    {
        return currentIndex < values.Count();
    }

    private void PerformInorderTraversal(TreeNode node) 
    {
        if (node == null)
            return;
      
        PerformInorderTraversal(node.Left);
        values.Add(node.Value);
        PerformInorderTraversal(node.Right);
    }
}