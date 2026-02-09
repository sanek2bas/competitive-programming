using Top.Interview._150.Stack;

namespace Stack;

public class SimplifyPathTest
{
    [Test]
    [Arguments("/home/", "/home")]
    [Arguments("/home//foo/", "/home/foo")]
    [Arguments("/home/user/Documents/../Pictures", "/home/user/Pictures")]
    [Arguments("/../", "/")]
    [Arguments("/.../a/../b/c/../d/./", "/.../b/d")]
    public async Task Solution(string path, string answer)
    {
        var solution = new SimplifyPath();        
        var result = solution.Execute(path);
        await Assert.That(result).IsEqualTo(answer);
    }
}