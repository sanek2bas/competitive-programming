using System.Text;

namespace Top.Interview._150.Array_String;

public class ZigzagConversion
{
    /// <summary>
    /// # 6
    /// https://leetcode.com/problems/zigzag-conversion/description/
    /// The string "PAYPALISHIRING" is written in a zigzag pattern on a 
    /// given number of rows like this: 
    /// P   A   H   N
    /// A P L S I I G
    /// Y   I   R
    /// And then read line by line: "PAHNAPLSIIGYIR"
    /// Write the code that will take a string and make this conversion 
    /// given a number of rows:
    /// string convert(string s, int numRows);
    /// </summary>
    public string Execute(string s, int numRows)
    {
        if (numRows == 1)
            return s;
        
        var rows = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
            rows[i] = new StringBuilder();
        
        int currentRow = 0;
        int step = 0;
        foreach (char c in s)
        {
            rows[currentRow].Append(c);
            if (currentRow == 0)
                step = 1;
            else if(currentRow == numRows-1)
                step = -1;
            currentRow += step;
        }

        var result = new StringBuilder();
        foreach (var row in rows)
            result.Append(row);
        return result.ToString();
    }
}