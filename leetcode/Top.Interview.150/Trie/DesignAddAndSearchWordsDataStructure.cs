using Top.Interview._150.Common;
using Top.Interview._150.Trie;

namespace Trie;

public class DesignAddAndSearchWordsDataStructure
{
    /// <summary>
    /// # 211
    /// https://leetcode.com/problems/design-add-and-search-words-data-structure/description/
    /// Design a data structure that supports adding new words and finding if a 
    /// string matches any previously added string.
    /// Implement the WordDictionary class:
    /// WordDictionary() Initializes the object.
    /// void addWord(word) Adds word to the data structure, it can be matched later.
    /// bool search(word) Returns true if there is any string in the data structure 
    /// that matches word or false otherwise. word may contain dots '.' where dots can be matched with any letter.
    /// </summary>
    
    private readonly TrieNode root;
    
    public DesignAddAndSearchWordsDataStructure()
    {
        root = new TrieNode();
    }

    public void AddWord(string word) 
    {
        TrieNode current = root;
        foreach (char c in word) 
        {
            int index = c - 'a';
            if (current.Children[index] == null) {
                current.Children[index] = new TrieNode();
            }
            current = current.Children[index];
        }
        current.IsWord = true;
    }
    
    public bool Search(string word) 
    {
        return Match(word, 0, root);
    }

    private bool Match(string word, int index, TrieNode node) 
    {
        if (node == null) 
            return false;
        
        if (index == word.Length)
            return node.IsWord;

        char c = word[index];

        if (c == '.') 
        {
            foreach (var child in node.Children) 
            {
                if (child != null 
                    && Match(word, index + 1, child))
                    return true;
            }
            return false;
        } 
        else 
        {
            int childIndex = c - 'a';
            return Match(word, index + 1, node.Children[childIndex]);
        }
    }
}