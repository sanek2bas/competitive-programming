using Infrastructure;

namespace TopInterview150.Trie
{
    public static class ImplementTrie_PrefixTree
    {
        /// <summary
        /// A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. 
        /// There are various applications of this data structure, such as autocomplete and spellchecker.
        /// </summary>
        public static IList<bool?> Execute(IList<(TrieCommands, string)> words)
        {
            var result = new List<bool?>();
            var trie = new Infrastructure.Trie();
            foreach (var word in words) 
            {
                switch(word.Item1)
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

        public static IEnumerable<(IList<(TrieCommands, string)> words, IList<bool?> answer)> GetTests()
        {
            yield return (
                new (TrieCommands, string)[] 
                { 
                    (TrieCommands.Insert, "apple"), 
                    (TrieCommands.Search, "apple"), 
                    (TrieCommands.Search, "app"), 
                    (TrieCommands.StartsWith, "app"), 
                    (TrieCommands.Insert, "app"), 
                    (TrieCommands.Search, "app")
                },
                new bool?[] { null, true, false, true, null, true });
        }

        public static bool CheckResult(IList<bool?> result, IList<bool?> answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}
