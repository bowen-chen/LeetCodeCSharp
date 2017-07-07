/*
453. Minimum Moves to Equal Array Elements
Given a non-empty integer array of size n, find the minimum number of moves required to make all array elements equal, where a move is incrementing n - 1 elements by 1.

Example:

Input:
[1,2,3]

Output:
3

Explanation:
Only three moves are needed (remember each move increments two elements):

[1,2,3]  =>  [2,3,3]  =>  [3,4,3]  =>  [4,4,4]
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int MinMoves(int[] nums)
        {
            // increase n-1 number by 1, mean cut some number by 1
            // we need cut all number to be min
            int min = int.MaxValue;
            int sum = 0;
            foreach (int num in nums)
            {
                min = Math.Min(min, num);
                sum += num;
            }

            return sum - min * nums.Length;
        }
    }
}
