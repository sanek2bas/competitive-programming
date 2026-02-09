using System.Text;

namespace Top.Interview._150.Stack;

public class SimplifyPath
{
    /// <summary>
    /// # 71
    /// https://leetcode.com/problems/simplify-path/description/
    /// You are given an absolute path for a Unix-style file system, 
    /// which always begins with a slash '/'. 
    /// Your task is to transform this absolute path into its 
    /// simplified canonical path.
    /// The rules of a Unix-style file system are as follows:
    /// A single period '.' represents the current directory.
    /// A double period '..' represents the previous/parent directory.
    /// Multiple consecutive slashes such as '//' and '///' 
    // are treated as a single slash '/'.
    // Any sequence of periods that does not match the rules above should 
    // be treated as a valid directory or file name. For example, 
    // '...' and '....' are valid directory or file names.
    // The simplified canonical path should follow these rules:
    // The path must start with a single slash '/'.
    // Directories within the path must be separated by exactly one slash '/'.
    // The path must not end with a slash '/', unless it is the root directory.
    // The path must not have any single or double periods ('.' and '..') 
    // used to denote current or parent directories.
    // Return the simplified canonical path.
    /// </summary>
    public string Execute(string path)
    {
        var splitedPath = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<string>();
        foreach(string p in splitedPath)
        {
            if (p == "/")
                continue;
            if (p == ".")
                continue;
            if (p == "..")
            {
                if (stack.Count > 0)
                    stack.Pop();
                continue;
            }
            stack.Push(p);
        }

        var result = new StringBuilder();
        foreach(var s in stack.Reverse())
        {
            result.Append('/');
            result.Append(s);
        }
        
        if(result.Length == 0)
            result.Append('/');
        return result.ToString();
    }
}