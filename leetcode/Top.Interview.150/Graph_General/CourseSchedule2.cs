namespace Top.Interview._150.Graph_General;

public class CourseSchedule2
{
    /// <summary>
    /// # 210
    /// https://leetcode.com/problems/course-schedule-ii/description/
    /// here are a total of numCourses courses you have to take, 
    /// labeled from 0 to numCourses - 1. You are given an array 
    /// prerequisites where prerequisites[i] = [ai, bi] indicates 
    /// that you must take course bi first if you want to take course ai.
    /// For example, the pair [0, 1], indicates that to 
    /// take course 0 you have to first take course 1.
    /// Return the ordering of courses you should take to finish all courses.
    /// If there are many valid answers, return any of them. 
    /// If it is impossible to finish all courses, return an empty array.
    /// </summary>
    public int[] Execute(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];
        var inDegree = new int[numCourses];
        
        for (int i = 0; i < numCourses; i++)
            graph[i] = new List<int>();
        
        foreach (var pre in prerequisites) 
        {
            int course = pre[0];
            int prerequisite = pre[1];
            graph[prerequisite].Add(course);
            inDegree[course]++;
        }
        
        var queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) 
        {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }
        
        int[] order = new int[numCourses];
        int index = 0;
        
        while (queue.Count > 0) 
        {
            int currentCourse = queue.Dequeue();
            order[index++] = currentCourse;
            
            foreach (int nextCourse in graph[currentCourse]) 
            {
                inDegree[nextCourse]--;
                if (inDegree[nextCourse] == 0)
                    queue.Enqueue(nextCourse);
            }
        }
        
        return index == numCourses ? order : new int[0];
    }
}