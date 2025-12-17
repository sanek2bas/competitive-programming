namespace Top.Interview._150.Common;

public class RandomizedSet
{
    private List<int> values;
    private Dictionary<int, int> valueToIndex;
    private Random rdm;

    public RandomizedSet()
    {
        values = new List<int>();
        valueToIndex = new Dictionary<int, int>();
        rdm = new Random();
    }

    public bool Insert(int val)
    {
        if (valueToIndex.ContainsKey(val))
            return false;
        values.Add(val);
        valueToIndex.Add(val, values.Count - 1);
        return true;
    }

    public bool Remove(int val)
    {
        if (!valueToIndex.TryGetValue(val, out int idx))
            return false;
        var lastIdx = values.Count - 1;
        values[idx] = values[lastIdx];
        valueToIndex[values[lastIdx]] = idx;
        values.RemoveAt(lastIdx);
        valueToIndex.Remove(val);
        return true;
    }

    public int GetRandom()
    {
        return values[rdm.Next(values.Count)];
    }
}