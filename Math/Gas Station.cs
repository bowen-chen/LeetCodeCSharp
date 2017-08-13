/*
134	Gas Station
math
There are N gas stations along a circular route, where the amount of gas at station i is gas[i].

You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station (i+1). You begin the journey with an empty tank at one of the gas stations.

Return the starting gas station's index if you can travel around the circuit once, otherwise return -1.

Note:
The solution is guaranteed to be unique.
*/

namespace Demo
{
    public partial class Solution
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            // total is the total gas in short
            int total = 0;

            int start = 0;
            int tank = 0;

            //if car fails at 'start', record the next station
            for (int i = 0; i < gas.Length; i++)
            {
                tank = tank + gas[i] - cost[i];
                if (tank < 0)
                {
                    start = i + 1;
                    total += tank;
                    tank = 0;
                }
            }

            return (total + tank < 0) ? -1 : start;
        }
    }
}
