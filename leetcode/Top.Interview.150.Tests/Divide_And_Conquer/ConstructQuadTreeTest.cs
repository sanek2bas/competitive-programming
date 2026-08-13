using Mono.Cecil.Cil;
using Top.Interview._150.Common;
using Top.Interview._150.Divide_And_Conquer;

namespace Divide_And_Conquer;

public class ConstructQuadTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[][] grid, int?[][] answer)
    {
        var solution = new ConstructQuadTree();

        var result = solution.Execute(grid);
        
        await Assert.That(QuadTreeNode.Serialize(result))
                    .IsEquivalentTo(answer);
    }

    public IEnumerable<(int[][] grid, int?[][] answer)> DataSource()
    {
        yield return (
            new int[][]
            {
                [0, 1],
                [1, 0]
            },
            new int?[][] 
            { 
                [0, 1], 
                [1, 0],
                [1, 1],
                [1, 1],
                [1, 0]
            });

        yield return (
            new int[][]
            {
                [1, 1, 1, 1, 0, 0, 0, 0],
                [1, 1, 1, 1, 0, 0, 0, 0],
                [1, 1, 1, 1, 1, 1, 1, 1],
                [1, 1, 1, 1, 1, 1, 1, 1],
                [1, 1, 1, 1, 0, 0, 0, 0],
                [1, 1, 1, 1, 0, 0, 0, 0],
                [1, 1, 1, 1, 0, 0, 0, 0],
                [1, 1, 1, 1, 0, 0, 0, 0]
            },
            new int?[][] 
            { 
                [0, 1], 
                [1, 1],
                [0, 1],
                [1, 1],
                [1, 0],
                null,
                null,
                null,
                null,
                [1, 0],
                [1, 0],
                [1, 1],
                [1, 1]
            });
    }
}