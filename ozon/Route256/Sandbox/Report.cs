namespace Route256.Sandbox
{
    public static class Report
    {
        public static void Main()
        {
            int employeesCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < employeesCount; i++)
            {
                var tasksCount = Convert.ToInt32(Console.ReadLine());
                var tasks = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();

                var tasksHash = new HashSet<int>();
                int currTask = -1;
                string answer = "YES";
                foreach (int task in tasks)
                {
                    if (currTask == task)
                        continue;
                    if (tasksHash.Contains(task))
                    {
                        answer = "NO";
                        break;
                    }
                    currTask = task;
                    tasksHash.Add(currTask);
                }
                Console.WriteLine(answer);
            }
        }
    }
}
