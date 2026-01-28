using System.Text;

namespace Concurrency.Tests;

public class PrintInOrderTests
{
    [Test]
    [Arguments(new[] { 1, 2, 3 }, "firstsecondthird")]
    [Arguments(new[] { 1, 3, 2 }, "firstsecondthird")]
    [Arguments(new[] { 2, 1, 3 }, "firstsecondthird")]
    [Arguments(new[] { 2, 3, 1 }, "firstsecondthird")]
    [Arguments(new[] { 3, 1, 2 }, "firstsecondthird")]
    [Arguments(new[] { 3, 2, 1 }, "firstsecondthird")]
    public async Task Solution(int[] order, string expected)
    {
        var printInOrder = new PrintInOrder();
        var result = new StringBuilder();
        void firstAction() => result.Append("first");
        void secondAction() => result.Append("second");
        void thirdAction() => result.Append("third");

        var tasks = new List<Task>();
        foreach (var methodId in order)
        {
            tasks.Add(Task.Run(() =>
            {
                switch (methodId)
                {
                    case 1:
                        printInOrder.First(firstAction);
                        break;
                    case 2:
                        printInOrder.Second(secondAction);
                        break;
                    case 3:
                        printInOrder.Third(thirdAction);
                        break;
                }
            }));
        }

        Task.WaitAll([.. tasks]);

        await Assert.That(result.ToString()).IsEqualTo(expected);
    }
}
