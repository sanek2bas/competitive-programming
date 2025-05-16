namespace TopInterview150.Array_String
{
    public static class GasStation
    {
        /// <summary>
        /// There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].
        /// You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next(i + 1)th station.
        /// You begin the journey with an empty tank at one of the gas stations.
        /// Given two integer arrays gas and cost, return the starting gas station's index if you can travel around 
        /// the circuit once in the clockwise direction, otherwise return -1. If there exists a solution, it is guaranteed to be unique
        /// </summary>
        public static int Execute(int[] gas, int[] cost)
        {
            if (gas.Sum() - cost.Sum() < 0)
                return -1;
            int sum = 0;
            int answer = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                sum += gas[i] - cost[i];
                if (sum < 0)
                {
                    sum = 0;
                    answer = i + 1;
                }
            }
            return answer;
        }

        public static IEnumerable<(int[] gas, int[] cost, int answer)> GetTests()
        {
            yield return (
                new int[] { 1, 2, 3, 4, 5 }, 
                new int[] { 3, 4, 5, 1, 2 },
                3);
            yield return (
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 3 },
                -1);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}
