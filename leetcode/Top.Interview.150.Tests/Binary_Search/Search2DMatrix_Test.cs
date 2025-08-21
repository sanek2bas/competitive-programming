using Top.Interview._150.Binary_Search;

namespace Top.Interview._150.Tests
{
    public class Search2DMatrix_Test
    {
        [Test]
        [MethodDataSource(nameof(DataSource))]
        public void Search2DMatrix(int[][] matrix, int target, bool answer)
        {
            var solution = new Search2DMatrix();
            var result = solution.Execute(matrix, target);
            Assert.Equals(result, answer);
        }

        public IEnumerable<(int[][] matrix, int traget, bool answer)> DataSource()
        {
            yield return (
               new int[3][]
               {
                    new int[] { 1, 3, 5, 7 },
                    new int[] { 10, 11, 16, 20 },
                    new int[] { 23, 30, 34, 60 }
               },
               3,
               true);
            yield return (
                new int[3][]
                {
                    new int[] { 1,3,5,7 },
                    new int[] { 10, 11, 16, 20 },
                    new int[] { 23, 30, 34, 60 }
                },
                13,
                false);
        }
    }
}
