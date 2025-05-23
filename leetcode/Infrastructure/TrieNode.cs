﻿namespace Infrastructure
{
    public sealed class TrieNode
    {
        public TrieNode[] Children { get; init; }

        public bool IsWord { get; set; }

        public TrieNode() 
        {
            Children = new TrieNode[26];
        }
    }
}
