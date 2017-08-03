/*
1	Two Sum
easy
Two Sum

Given an array of integers, find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

You may assume that each input would have exactly one solution.

Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            Dictionary<int, int> m = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int expect = target - numbers[i];
                if (m.ContainsKey(expect))
                {
                    return new [] {m[expect] + 1, i + 1};
                }

                m[numbers[i]] = i;
            }

            return null;
        }
    }
}
