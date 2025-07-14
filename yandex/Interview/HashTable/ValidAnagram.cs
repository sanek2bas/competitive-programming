public class ValidAnagram
{
    /// <summary>
    /// Given two strings s and t, return true if t is an anagram of s, 
    /// and false otherwise.
    /// </summary>
    public static void Execute(string s, string r)
    {
        TreeListNode node = root;

        while (node != null)
        {
            TreeListNode dummy = new TreeListNode();

            for (TreeListNode needle = dummy; node != null; node = node.Next)
            {
                if (node.Left != null)
                {
                    needle.Next = node.Left;
                    needle = needle.Next;
                }
                if (node.Right != null)
                {
                    needle.Next = node.Right;
                    needle = needle.Next;
                }
            }

            node = dummy.Next;
        }

        return root;
    }

    public static IEnumerable<(TreeListNode root, int?[] answer)> GetTests()
    {
        yield return (
            TreeListNode.Map(1, 2, 3, 4, 5, 6, 7),
            new int?[] { 1, null, 2, 3, null, 4, 5, 7, null });
        yield return (
            TreeListNode.Map(),
            new int?[] { });
    }

    public static bool CheckResult(TreeListNode result, int?[] answer)
}