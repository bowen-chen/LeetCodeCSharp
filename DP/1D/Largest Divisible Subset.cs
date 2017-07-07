/*
368	Largest Divisible Subset
Given a set of distinct positive integers, find the largest subset such that every pair (Si, Sj) of elements in this subset satisfies: Si % Sj = 0 or Sj % Si = 0.

If there are multiple solutions, return any subset is fine.

Example 1:

nums: [1,2,3]

Result: [1,2] (of course, [1,3] will also be ok)
Example 2:

nums: [1,2,4,8]

Result: [1,2,4,8]
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            nums = nums.OrderBy(n => n).ToArray();
            var dp = new int[nums.Length];
            var parent = new int[nums.Length];
            int mx = 0, mx_idx = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                // j started with i, so dp[i] is always started with 1
                for (int j = i; j >= 0; j--)
                {
                    if (nums[i]%nums[j] == 0 && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                        parent[i] = j;
                        if (mx < dp[i])
                        {
                            mx = dp[i];
                            mx_idx = i;
                        }
                    }
                }
            }
            
            var res = new List<int>();
            for (int i = 0; i < mx; ++i)
            {
                res.Add(nums[mx_idx]);
                mx_idx = parent[mx_idx];
            }
            
            return res;
        }
    }
}
