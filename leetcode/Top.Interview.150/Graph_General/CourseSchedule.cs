namespace Top.Interview._150.Graph_General;

public class CourseSchedule
{
    /// <summary>
    /// # 207
    /// https://leetcode.com/problems/course-schedule/description/
    /// There are a total of numCourses courses you have to take, 
    /// labeled from 0 to numCourses - 1. You are given an array 
    /// prerequisites where prerequisites[i] = [ai, bi] indicates 
    /// that you must take course bi first if you want to take course ai.
    /// For example, the pair [0, 1], indicates that to take course 0 
    /// you have to first take course 1.
    /// Return true if you can finish all courses. Otherwise, return false.
    /// </summary>
    public bool Execute(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];
        var inDegree = new int[numCourses];
        
        for (int i = 0; i < numCourses; i++)
            graph[i] = new List<int>();
        
        foreach (var req in prerequisites) 
        {
            int course = req[0];
            int prereq = req[1];
            graph[prereq].Add(course);
            inDegree[course]++;
        }
        
        var queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) 
        {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }
        
        int completedCoursesCount = 0;
        
        while (queue.Count > 0) 
        {
            int current = queue.Dequeue();
            completedCoursesCount++;
            
            foreach (int neighbor in graph[current]) 
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }
        
        return completedCoursesCount == numCourses;
    }
}