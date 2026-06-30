using Top.Interview._150.Graph_General;

namespace Graph_General;

public class CourseSchedule2Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int numCourses, int[][] prerequisites, int[] answer)
    {
        var solution = new CourseSchedule2();
        
        var result = solution.Execute(numCourses, prerequisites);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }
    public IEnumerable<(int numCourses, int[][] prerequisites, int[] answer)> DataSource()
    {
        yield return (
            2,
            [[1, 0]],
            [0, 1]);

        yield return (
            4,
            [[1,0], [2,0], [3,1], [3,2]],
            [0, 2, 1, 3]);
    }
}