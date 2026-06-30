namespace Top.Interview._150.Graph_BFS;

public class MinimumGeneticMutation
{
    /// <summary>
    /// # 433
    /// https://leetcode.com/problems/minimum-genetic-mutation/description/
    /// A gene string can be represented by an 8-character long string, 
    /// with choices from 'A', 'C', 'G', and 'T'.
    /// Suppose we need to investigate a mutation from a gene string startGene 
    /// to a gene string endGene where one mutation is defined as one 
    /// single character changed in the gene string.
    /// For example, "AACCGGTT" --> "AACCGGTA" is one mutation.
    /// There is also a gene bank bank that records all the valid gene mutations. 
    /// A gene must be in bank to make it a valid gene string.
    /// Given the two gene strings startGene and endGene and the gene bank bank, 
    /// return the minimum number of mutations needed to mutate from startGene to endGene. 
    /// If there is no such a mutation, return -1.
    /// Note that the starting point is assumed to be valid, so it might not be included in the bank.
    /// </summary>
    public int Execute(string startGene, string endGene, string[] bank)
    {
        var bankSet = new HashSet<string>(bank);
        
        if (!bankSet.Contains(endGene))
            return -1;
        
        var validCharacters = new char[] { 'A', 'C', 'G', 'T' };
        
        Queue<(string Gene, int Steps)> queue = new Queue<(string, int)>();
        HashSet<string> visited = new HashSet<string>();
        
        queue.Enqueue((startGene, 0));
        visited.Add(startGene);
        
        while (queue.Count > 0) 
        {
            var current = queue.Dequeue();
            string currentGene = current.Gene;
            int currentSteps = current.Steps;
            
            if (currentGene == endGene)
                return currentSteps;
            
            char[] geneArray = currentGene.ToCharArray();
            for (int i = 0; i < geneArray.Length; i++) 
            {
                char originalChar = geneArray[i];
                
                foreach (char c in validCharacters) 
                {
                    if (c == originalChar) 
                        continue;
                    
                    geneArray[i] = c;
                    string mutatedGene = new string(geneArray);
                    
                    if (bankSet.Contains(mutatedGene) && !visited.Contains(mutatedGene)) 
                    {
                        visited.Add(mutatedGene);
                        queue.Enqueue((mutatedGene, currentSteps + 1));
                    }
                }
                
                geneArray[i] = originalChar;
            }
        }
        
        return -1;
    }
}