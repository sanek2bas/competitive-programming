using Top.Interview._150.Common;
using Top.Interview._150.Graph_General;

namespace Graph_General;

public class CloneGraphTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(Node node)
    {
        var solution = new CloneGraph();
        
        var result = solution.Execute(node);
        
        await Assert.That(Compare(node, result)).IsTrue();
    }

    public IEnumerable<Node> DataSource()
    {
        yield return(
            Node.Create([[2,4], [1,3], [2,4], [1,3]]));
        yield return(
            Node.Create([[]]));
        yield return(
            Node.Create([]));
    }

    private static bool Compare(Node original, Node clone)
    {
        if (original == null 
            || clone == null)
            return original == clone;
        
        var originalQueue = new Queue<Node>();
        var cloneQueue = new Queue<Node>();

        originalQueue.Enqueue(original);
        cloneQueue.Enqueue(clone);

        var originalVisited = new HashSet<Node>();
        var cloneVisited = new HashSet<Node>();

        while (originalQueue.Count > 0)
        {
            if (cloneQueue.Count == 0)
                return false;

            var o = originalQueue.Dequeue();
            var c = cloneQueue.Dequeue();

            if (ReferenceEquals(o, c))
                return false;
            if (o.Value != c.Value)
                return false;

            originalVisited.Add(o);
            cloneVisited.Add(c);

            foreach (var n in o.Neighbors)
            {
                if (originalVisited.Contains(n))
                    continue;
                originalQueue.Enqueue(n);
            }

            foreach (var n in c.Neighbors)
            {
                if (cloneVisited.Contains(n))
                    continue;
                cloneQueue.Enqueue(n);
            }            
        }

        return cloneQueue.Count == 0;
    }
}