using System.Collections;
using Top.Interview._150.Stack;

namespace Stack;

public class MinStackTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(IList<(string command, int arg)> data)
    {
        var stack = new MinStack();

        foreach(var d in data)
        {
            switch(d.command)
            {
                case "push":
                    stack.Push(d.arg);
                    break;

                case "pop":
                    stack.Pop();
                    break;

                case "top":
                    await Assert.That(stack.Top()).IsEqualTo(d.arg);
                    break;

                case "getMin":
                    await Assert.That(stack.GetMin()).IsEqualTo(d.arg);
                    break;
            }
        }
    }

    public IEnumerable<IList<(string command, int arg)>>  DataSource()
    {
        yield return new List<(string, int)>
        {
            ("push", -2),
            ("push", 0),
            ("push", -3),
            ("getMin", -3),
            ("pop", int.MinValue),
            ("top", 0),
            ("getMin", -2)
        };
    }
}