namespace Top.Interview._150.Trie;

public sealed class Trie
{
    private readonly TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode node = root;
        foreach(char letter in word)
        {
            int idx = letter - 'a';
            if (node.Children[idx] == null)
                node.Children[idx] = new TrieNode();
            node = node.Children[idx];
        }
        node.IsWord = true;
    }

    public bool Search(string word)
    {
        TrieNode? node = Find(word);
        return node != null && node.IsWord;
    }

    public bool StartsWith(string prefix)
    {
        return Find(prefix) != null;
    }

    private TrieNode? Find(string prefix)
    {
        TrieNode node = root;
        foreach (char letter in prefix)
        {
            int idx = GetIdx(letter);
            if (node.Children[idx] == null)
                return null;
            node = node.Children[idx];
        }
        return node;
    }

    private int GetIdx(char letter)
    {
        return letter - 'a';
    }
}