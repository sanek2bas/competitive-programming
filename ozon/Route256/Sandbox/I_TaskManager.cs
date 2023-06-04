namespace Route256.Sandbox
{
    public static class I_TaskManager
    {
        public static void Main()
        {;
            var nm = Console.ReadLine()
                .Split(' ')
                .Select(x => Convert.ToInt32(x))
                .ToArray();
            
            int processorsCount = nm[0];
            int tasksCount = nm[1];

            var freePQ = new PriorityQueue<Processor, int>();
            var busyPQ = new PriorityQueue<Processor, int>();

            foreach (var power in Console.ReadLine().Split().Select(x => Convert.ToInt32(x)))
            {
                var proc = new Processor(power);
                freePQ.Enqueue(proc, proc.Power);
            }

            ulong result = 0;
            for (int i = 0; i < tasksCount; i++)
            {
                var td = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();
                int time = td[0];
                int duration = td[1];

                while(busyPQ.Count > 0 && busyPQ.Peek().FinishTime <= time)
                {
                    var proc = busyPQ.Dequeue();
                    proc.FinishTime = 0;
                    freePQ.Enqueue (proc, proc.Power);
                }

                if (freePQ.Count == 0)
                    continue;

                var processor = freePQ.Dequeue();
                result += (ulong)processor.Power * (ulong)duration;
                processor.FinishTime = time + duration;
                busyPQ.Enqueue(processor, processor.FinishTime);
            }

            Console.WriteLine(result);
        }

        private class Processor
        {
            public int Power { get; }

            public int FinishTime { get; set; }

            public Processor(int power)
            {
                Power = power;
            }
        }
    }
}
