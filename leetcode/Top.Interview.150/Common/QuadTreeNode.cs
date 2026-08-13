namespace Top.Interview._150.Common;

public class QuadTreeNode
{
    public bool Value { get; }
    public bool IsLeaf { get; }
    public QuadTreeNode TopLeft { get; }
    public QuadTreeNode TopRight { get; }
    public QuadTreeNode BottomLeft { get; }
    public QuadTreeNode BottomRight { get; }

    public QuadTreeNode() 
    {
        Value = false;
        IsLeaf = false;
        TopLeft = null;
        TopRight = null;
        BottomLeft = null;
        BottomRight = null;
    }
    
    public QuadTreeNode(
        bool value, 
        bool isLeaf) 
    {
        Value = value;
        IsLeaf = isLeaf;
        TopLeft = null;
        TopRight = null;
        BottomLeft = null;
        BottomRight = null;
    }
    
    public QuadTreeNode(
        bool value,
        bool isLeaf,
        QuadTreeNode topLeft,
        QuadTreeNode topRight,
        QuadTreeNode bottomLeft,
        QuadTreeNode bottomRight) 
    {
        Value = value;
        IsLeaf = isLeaf;
        TopLeft = topLeft;
        TopRight = topRight;
        BottomLeft = bottomLeft;
        BottomRight =bottomRight;
    }

    public static int?[][] Serialize(QuadTreeNode root) 
    {
        var result = new List<int?[]>();
        var queue = new Queue<QuadTreeNode>();
        queue.Enqueue(root);
    
        while (queue.Count > 0) 
        {
            QuadTreeNode node = queue.Dequeue();
        
            if (node == null) 
            {
                result.Add(null);
                continue;
            }
        
            result.Add(new int?[] 
            { 
                node.IsLeaf ? 1 : 0, 
                node.Value ? 1 : 0 
            });
        
            queue.Enqueue(node.TopLeft);
            queue.Enqueue(node.TopRight);
            queue.Enqueue(node.BottomLeft);
            queue.Enqueue(node.BottomRight);
        }
        while (result.Count > 0 
            && result[result.Count - 1] == null) 
        {
            result.RemoveAt(result.Count - 1);
        }
    
        return result.ToArray();
    }
}