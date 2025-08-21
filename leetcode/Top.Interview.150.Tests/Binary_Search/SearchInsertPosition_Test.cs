using Top.Interview._150.Binary_Search;

namespace Top.Interview._150.Tests
{
    public class SearchInsertPosition_Test
    {
        [Test]
        [Arguments(new int[] { 1, 3, 5, 6 }, 5, 2)]
        [Arguments(new int[] { 1, 3, 5, 6 }, 2, 1)]
        [Arguments(new int[] { 1, 3, 5, 6 }, 7, 4)]
        public void SearchInsertPosition(int[] nums, int target, int answer)
        {
            var solution = new SearchInsertPosition();
            var result = solution.Execute(nums, target);
            Assert.Equals(result, answer);
        }
    }
}