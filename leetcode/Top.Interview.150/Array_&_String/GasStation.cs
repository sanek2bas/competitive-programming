namespace Top.Interview._150.Array___String;

public class GasStation
{
    /// <summary>
    /// # 134
    /// https://leetcode.com/problems/gas-station/description/
    /// There are n gas stations along a circular route, 
    /// where the amount of gas at the ith station is gas[i].
    /// You have a car with an unlimited gas tank and it costs cost[i]
    /// of gas to travel from the ith station to its next(i + 1)th station.
    /// You begin the journey with an empty tank at one of the gas stations.
    /// Given two integer arrays gas and cost, return the starting gas
    /// station's index if you can travel around 
    /// the circuit once in the clockwise direction, otherwise return -1. 
    /// If there exists a solution, it is guaranteed to be unique
    /// </summary>
    public int Execute(int[] gas, int[] cost)
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
}