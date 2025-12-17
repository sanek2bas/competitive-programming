namespace Top.Interview._150.Common;

public class RandomizedSet<T>
{
    private List<T> values;
    private Dictionary<T, int> valueToIndex;
    private Random rdm;

    public RandomizedSet()
    {
        values = new List<T>();
        valueToIndex = new Dictionary<T, int>();
        rdm = new Random();
    }

    public bool Insert(T val)
    {
        if (valueToIndex.ContainsKey(val))
            return false;
        values.Add(val);
        valueToIndex.Add(val, values.Count - 1);
        return true;
    }

    public bool Remove(T val)
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

    public T GetRandom()
    {
        return values[rdm.Next(values.Count)];
    }
}