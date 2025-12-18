using Top.Interview._150.Common;

namespace Top.Interview._150.Trie;

public class ImplementTriePrefixTree
{
    /// <summary>
    /// # 28
    /// https://leetcode.com/problems/implement-trie-prefix-tree/description/
    /// A trie (pronounced as "try") or prefix tree is a tree data structure 
    /// used to efficiently store and retrieve keys in a dataset of strings. 
    /// There are various applications of this data structure, 
    /// such as autocomplete and spellchecker.
    /// </summary>
    public IList<bool?> Execute(IList<(TrieCommands, string)> words)
    {
        var result = new List<bool?>();
        var trie = new Common.Trie();
        foreach (var word in words)
        {
            switch (word.Item1)
            {
                case TrieCommands.Insert:
                    trie.Insert(word.Item2);
                    result.Add(null);
                    break;
                case TrieCommands.Search:
                    result.Add(trie.Search(word.Item2));
                    break;
                case TrieCommands.StartsWith:
                    result.Add(trie.StartsWith(word.Item2));
                    break;
            }
        }
        return result;
    }
}