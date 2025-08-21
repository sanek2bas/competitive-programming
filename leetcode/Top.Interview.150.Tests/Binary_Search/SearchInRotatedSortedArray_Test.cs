using Top.Interview._150.Binary_Search;

namespace Binary_Search;

public class SearchInRotatedSortedArray_Test
{
    [Test]
    [Arguments(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [Arguments(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
    [Arguments(new int[] { 1 }, 0, -1)]
    public void SearchInRotatedSortedArray(int[] nums, int target, int answer)
    {
        var solution = new SearchInRotatedSortedArray();
        var result = solution.Execute(nums, target);
        Equals(result, answer);
    }
}
