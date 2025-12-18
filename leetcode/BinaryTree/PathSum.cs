using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral;

public static class PathSum
{
    

    public static IEnumerable<(TreeNode root, int targetSum, bool answer)> GetTests()
    {
        
    }

    public static bool CheckResult(bool result, bool answer)
    {
        return result == answer;
    }
}
