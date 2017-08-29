/*
152. Maximum Product Subarray
easy, dp
Find the contiguous subarray within an array (containing at least one number) which has the largest product.

For example, given the array [2,3,-2,4],
the contiguous subarray [2,3] has the largest product = 6.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaxProduct(int[] nums)
        {
            int max = nums[0], min = nums[0], maxAns = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int mx = max, mn = min;
                max = Math.Max(Math.Max(nums[i], mx * nums[i]), mn * nums[i]);
                min = Math.Min(Math.Min(nums[i], mx * nums[i]), mn * nums[i]);
                maxAns = Math.Max(max, maxAns);
            }
            return maxAns;
        }

        public int MaxProduct2(int[] nums)
        {
            int[] p = new int[nums.Length];
            int[] n = new int[nums.Length];
            p[0] = nums[0] > 0 ? nums[0] : 0;
            n[0] = nums[0] < 0 ? nums[0] : 0;
            int res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    p[i] = p[i - 1] > 0 ? p[i - 1]*nums[i] : nums[i];
                    n[i] = n[i - 1] < 0 ? n[i - 1]*nums[i] : 0;
                }
                else if (nums[i] < 0)
                {
                    p[i] = n[i - 1] < 0 ? n[i - 1]*nums[i] : 0;
                    n[i] = p[i - 1] > 0 ? p[i - 1]*nums[i] : nums[i];
                }

                res = Math.Max(res, p[i]);
            }

            return res;
        }

        public int MaxProduct3(int[] nums)
        {
            int p = nums[0] > 0 ? nums[0] : 0;
            int n = nums[0] < 0 ? nums[0] : 0;
            int res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int prep = p;
                int pren = n;
                if (nums[i] > 0)
                {
                    p = prep > 0 ? prep * nums[i] : nums[i];
                    n = pren < 0 ? pren * nums[i] : 0;
                }
                else if (nums[i] < 0)
                {
                    p = pren < 0 ? pren * nums[i] : 0;
                    n = prep > 0 ? prep * nums[i] : nums[i];
                }
                else // nums[i] = 0;
                {
                    p = 0;
                    n = 0;
                }

                if (p > res)
                {
                    res = p;
                }
            }

            return res;
        }
    }
}
