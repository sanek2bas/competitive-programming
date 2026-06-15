using Top.Interview._150.Common;

namespace Top.Interview._150.Divide_And_Conquer;

public class ConstructQuadTree
{
    /// <summary>
    /// # 427
    /// https://leetcode.com/problems/construct-quad-tree/
    /// Given a n * n matrix grid of 0's and 1's only. We want to represent
    /// grid with a Quad-Tree.
    /// Return the root of the Quad-Tree representing grid.
    /// A Quad-Tree is a tree data structure in which each internal node has 
    /// exactly four children. Besides, each node has two attributes:
    /// val: True if the node represents a grid of 1's or False if the node 
    /// represents a grid of 0's. Notice that you can assign the val to True or
    /// False when isLeaf is False, and both are accepted in the answer.
    /// isLeaf: True if the node is a leaf node on the tree or False if the node has four children.
    /// class Node {
    ///     public boolean val;
    ///     public boolean isLeaf;
    ///     public Node topLeft;
    ///     public Node topRight;
    ///     public Node bottomLeft;
    ///     public Node bottomRight;
    /// }
    /// We can construct a Quad-Tree from a two-dimensional area using the following steps:
    /// 1. If the current grid has the same value (i.e all 1's or all 0's) set isLeaf 
    /// True and set val to the value of the grid and set the four children to Null and stop.
    /// 2. If the current grid has different values, set isLeaf to False and set val 
    /// to any value and divide the current grid into four sub-grids as shown in the photo.
    /// 3. Recurse for each of the children with the proper sub-grid.
    /// Quad-Tree format:
    /// You don't need to read this section for solving the problem. 
    /// This is only if you want to understand the output format here.
    /// The output represents the serialized format of a Quad-Tree using level order traversal, 
    /// where null signifies a path terminator where no node exists below.
    /// It is very similar to the serialization of the binary tree. The only 
    /// difference is that the node is represented as a list [isLeaf, val].
    /// If the value of isLeaf or val is True we represent it as 1 in the list [isLeaf, val] 
    /// and if the value of isLeaf or val is False we represent it as 0.
    /// </summary>
    
    public QuadTreeNode Execute(int[][] grid)
    {
        return Helper(grid, 0, 0, grid.Length);
    }
    
    private QuadTreeNode Helper(
        int[][] grid, 
        int i, 
        int j, 
        int w) 
    {
        if (AllSame(grid, i, j, w))
            return new QuadTreeNode(grid[i][j] == 1, true);
        
        int half = w / 2;
        return new QuadTreeNode(
            value: true, 
            isLeaf:false,
            topLeft: Helper(grid, i, j, half),
            topRight: Helper(grid, i, j + half, half),
            bottomLeft: Helper(grid, i + half, j, half),
            bottomRight: Helper(grid, i + half, j + half, half));
    }

    private bool AllSame(
        int[][] grid, 
        int i, 
        int j,
        int w) {
        for (int x = i; x < i + w; ++x) 
        {
            for (int y = j; y < j + w; ++y) 
            {
                if (grid[x][y] != grid[i][j])
                    return false;
            }
        }
        return true;
    }
}