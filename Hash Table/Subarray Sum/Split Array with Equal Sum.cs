/*
548	Split Array with Equal Sum
Given an array with n integers, you need to find if there are triplets (i, j, k) which satisfies following conditions:

0 < i, i + 1 < j, j + 1 < k < n - 1
Sum of subarrays (0, i - 1), (i + 1, j - 1), (j + 1, k - 1) and (k + 1, n - 1) should be equal.
where we define that subarray (L, R) represents a slice of the original array starting from the element indexed L to the element indexed R.

Example:
Input: [1,2,1,2,1,2,1]
Output: True
Explanation:
i = 1, j = 3, k = 5. 
sum(0, i - 1) = sum(0, 0) = 1
sum(i + 1, j - 1) = sum(2, 2) = 1
sum(j + 1, k - 1) = sum(4, 4) = 1
sum(k + 1, n - 1) = sum(6, 6) = 1
Note:

1 <= n <= 2000.
Elements in the given array will be in range [-1,000,000, 1,000,000].
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool SplitArray(int[] nums)
        {
            if (nums == null && nums.Length < 7)
            {
                return false;
            }

            int n = nums.Length;
            int[] sums = new int[n];
            sums[0] = nums[0];
            for (int i = 1; i < n; ++i)
            {
                sums[i] = sums[i - 1] + nums[i];
            }

            for (int j = 3; j < n - 3; ++j)
            {
                // split on j
                var s = new HashSet<int>();
                for (int i = 1; i < j - 1; ++i)
                {
                    int s1 = sums[i - 1];
                    int s2 = sums[j - 1] - sums[i];
                    if (s1 == s2)
                    {
                        s.Add(sums[i - 1]);
                    }
                }
                for (int k = j + 1; k < n - 1; ++k)
                {
                    int s3 = sums[k - 1] - sums[j];
                    int s4 = sums[n - 1] - sums[k];
                    if (s3 == s4 && s.Contains(s3))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    };
}
