/*
312	Burst Balloons
medium, dp
Given n balloons, indexed from 0 to n-1. Each balloon is painted with a number on it represented by array nums. You are asked to burst all the balloons. If the you burst balloon i you will get nums[left] * nums[i] * nums[right] coins. Here left and right are adjacent indices of i. After the burst, the left and right then becomes adjacent.

Find the maximum coins you can collect by bursting the balloons wisely.

Note: 
(1) You may imagine nums[-1] = nums[n] = 1. They are not real therefore you can not burst them.
(2) 0 ≤ n ≤ 500, 0 ≤ nums[i] ≤ 100

Example:

Given [3, 1, 5, 8]

Return 167

    nums = [3,1,5,8] --> [3,5,8] -->   [3,8]   -->  [8]  --> []
   coins =  3*1*5      +  3*5*8    +  1*3*8      + 1*8*1   = 167
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int MaxCoins2(int[] iNums)
        {
            // new array, add 1 on begin and end
            int[] nums = new int[iNums.Length + 2];
            int n = 1;
            foreach (int x in iNums)
            {
                nums[n++] = x;
            }
            nums[0] = nums[n++] = 1;

            // dp[i,j] best score from i to j, not include i, j
            int[,] dp = new int[n, n];

            // init value dp[i, j = i+1] = 0, not balloon in rang of (i, i+1)
            // k is distance
            for (int k = 2; k < n; k++)
            {
                for (int left = 0; left < n - k; left++)
                {
                    int right = left + k;
                    for (int i = left + 1; i < right; ++i)
                    {
                        dp[left, right] = Math.Max(dp[left, right],
                            nums[left] * nums[i] * nums[right] + dp[left, i] + dp[i, right]);
                    }
                }
            }

            return dp[0, n - 1];
        }

        public void Test_MaxCoins()
        {
            Console.WriteLine(MaxCoins(new[] {3, 1, 5, 8}));
        }

        public int MaxCoins(int[] nums)
        {
            return MaxCoins(nums, new Dictionary<string, int>());
        }

        public int MaxCoins(int[] nums, Dictionary<string, int> dic)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            string key = string.Join(",", nums.Select(n => n.ToString()));
            if (dic.ContainsKey(key))
            {
                return dic[key];
            }

            int max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int ret = nums[i];
                if (i - 1 >= 0)
                {
                    ret *= nums[i - 1];
                }
                if (i + 1 <= nums.Length - 1)
                {
                    ret *= nums[i + 1];
                }
                var list = nums.ToList();
                list.RemoveAt(i);
                max = Math.Max(ret + MaxCoins(list.ToArray()), max);
            }
            dic[key] = max;
            return max;
        }

        public int MaxCoins3(int[] iNums)
        {
            int[] nums = new int[iNums.Length + 2];
            int n = 1;
            foreach (int x in iNums)
            {
                if (x > 0)
                {
                    nums[n++] = x;
                }
            }
            nums[0] = nums[n++] = 1;


            int[,] memo = new int[n, n];
            return MaxCoins3(memo, nums, 0, n - 1);
        }

        public int MaxCoins3(int[,] memo, int[] nums, int left, int right)
        {
            if (left + 1 == right) return 0;
            if (memo[left, right] > 0) return memo[left, right];
            int ans = 0;
            for (int i = left + 1; i < right; ++i)
            {
                ans = Math.Max(ans,
                    nums[left]*nums[i]*nums[right] + MaxCoins3(memo, nums, left, i) + MaxCoins3(memo, nums, i, right));
            }
            memo[left, right] = ans;
            return ans;
        }
    }
}
