namespace TopInterview150.Array_String
{
    public static class InsertDeleteGetRandom
    {
        /// <summary>
        /// Implement the RandomizedSet class:
        /// RandomizedSet() Initializes the RandomizedSet object.
        /// bool insert(int val) Inserts an item val into the set if not present. Returns true if the item was not present, false otherwise.
        /// bool remove(int val) Removes an item val from the set if present. Returns true if the item was present, false otherwise.
        /// int getRandom() Returns a random element from the current set of elements (it's guaranteed that at least one element exists 
        /// when this method is called). Each element must have the same probability of being returned.
        /// You must implement the functions of the class such that each function works in average O(1) time complexity.
        /// </summary>
        public static string[] Execute(Func<RandomizedSet, string[]> function)
        {
            return function.Invoke(new RandomizedSet());
        }

        public static IEnumerable<(Func<RandomizedSet, string[]> function, string[] answer)> GetTests()
        {
            yield return (
                (RandomizedSet set) =>
                {
                    var answers = new List<string>
                    {
                        set.Insert(1).ToString(),
                        set.Remove(2).ToString(),
                        set.Insert(2).ToString(),
                        set.Remove(1).ToString(),
                        set.Insert(2).ToString(),
                        set.GetRandom().ToString()
                    };
                    return answers.ToArray();
                },
                new string[] { "True", "False", "True", "True", "False", "2" });
            yield return (
                (RandomizedSet set) =>
                {
                    var answers = new List<string>();
                    answers.Add(set.Remove(0).ToString());
                    answers.Add(set.Remove(0).ToString());
                    answers.Add(set.Insert(0).ToString());
                    answers.Add(set.GetRandom().ToString());
                    answers.Add(set.Remove(0).ToString());
                    answers.Add(set.Insert(0).ToString());
                    return answers.ToArray();
                },
                new string[] { "False", "False", "True", "0", "True", "True" });
            yield return (
               (RandomizedSet set) =>
               {
                   var answers = new List<string>();
                   answers.Add(set.Insert(3).ToString());
                   answers.Add(set.Remove(3).ToString());
                   answers.Add(set.Remove(0).ToString());
                   answers.Add(set.Insert(3).ToString());
                   answers.Add(set.GetRandom().ToString());
                   answers.Add(set.Remove(0).ToString());
                   return answers.ToArray();
               },
               new string[] { "True", "True", "False", "True", "3", "False" });
        }

        public static bool CheckResult(string[] result, string[] answer)
        {
            return result.SequenceEqual(answer);
        }

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
    }
}
