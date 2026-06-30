using Top.Interview._150.Graph_General;

namespace Graph_General;

public class CourseScheduleTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int numCourses, int[][] prerequisites, bool answer)
    {
        var solution = new CourseSchedule();
        
        var result = solution.Execute(numCourses, prerequisites);
        
        await Assert.That(result).IsEqualTo(answer);
    }
    public IEnumerable<(int numCourses, int[][] prerequisites, bool answer)> DataSource()
    {
        yield return (
            2,
            [ [1, 0] ],
            true);

        yield return (
            2,
            [ [1, 0], [0, 1]],
            false);
    }
}