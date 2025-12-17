namespace Top.Interview._150.Common;

public class ListNodeWithRandom
{
    public int Value { get; init; }

    public ListNodeWithRandom? Next { get; set; }

    public ListNodeWithRandom? Random { get; set; }

    public ListNodeWithRandom(int value = -1)
    {
        Value = value;
    }

    public static ListNodeWithRandom? Create(params (int value, int randomIndex)[] numbers)
    {
        var startNode = new ListNodeWithRandom();
        var list = new List<ListNodeWithRandom>();
        list.Add(startNode);
        var withoutRandoms = new List<(ListNodeWithRandom node, int randomIndex)>();
        for(int i = 0; i < numbers.Length; i++)
        {
            var value = numbers[i].value;
            var randomIndex = numbers[i].randomIndex;

            var node = new ListNodeWithRandom(value);
            list[i].Next = node;
            if (randomIndex != -1)
            {
                if (randomIndex < list.Count-1)
                    node.Random = list[randomIndex+1];
                else
                    withoutRandoms.Add(new(node, randomIndex));
            }
            list.Add(node);
        }

        foreach(var withoutRandom in withoutRandoms)
            withoutRandom.node.Random = list[withoutRandom.randomIndex];

        return startNode.Next;
    }
}