using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace  Linked_List;

public class CopyListWithRandomPointerTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNodeWithRandom head, ListNodeWithRandom answer)
    {
        var solution = new CopyListWithRandomPointer();

        var result = solution.Execute(head);

        await Assert.That(CheckResult(result, answer)).IsTrue();
    }

    public IEnumerable<(ListNodeWithRandom head, ListNodeWithRandom answer)> DataSource()
    {
        var node1 = ListNodeWithRandom.Create(
            (7, -1), (13, 0), (11, 4), (10, 2), (1, 0));
        yield return (node1, node1);
        
        var node2 = ListNodeWithRandom.Create(
            (1, 1), (2, 1));
        yield return (node2, node2);

        var node3 = ListNodeWithRandom.Create(
            (3, -1), (3, 0), (3, -1));
        yield return (node3, node3);
    }

    public bool CheckResult(ListNodeWithRandom result, ListNodeWithRandom answer)
    {
        if (ReferenceEquals(result, answer))
            return false;

        while (result != null && answer != null)
        {
            if(result.Value != answer.Value)
                return false;
            if (result.Next?.Value != answer.Next?.Value)
                return false;
            if(result.Random?.Value != result.Random?.Value)
                return false;
            result = result.Next;
            answer = answer.Next;
        }

        return result == null && answer == null;
    }
}