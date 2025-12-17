namespace Top.Interview._150.Hashmap;

public class GroupAnagrams
{
    /// <summary>
    /// # 49
    /// https://leetcode.com/problems/group-anagrams/
    /// Given an array of strings strs, group the anagrams together. 
    /// You can return the answer in any order.
    /// An Anagram is a word or phrase formed by rearranging 
    /// the letters of a different word or phrase, 
    /// typically using all the original letters exactly once.
    /// </summary>
    public IList<IList<string>> Execute(string[] strs)
    {
        var dic = new Dictionary<string, IList<string>>();

        foreach (string str in strs)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            var key = new string(chars);
            if (!dic.ContainsKey(key))
                dic.Add(key, new List<string>());
            dic[key].Add(str);
        }

        var answer = new List<IList<string>>();
        foreach (var keyValuePair in dic)
            answer.Add(keyValuePair.Value);

        return answer;
    }

}
