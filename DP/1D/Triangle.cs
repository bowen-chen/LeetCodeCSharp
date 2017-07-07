/*
120	Triangle
easy, dp
Triangle
Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.

For example, given the following triangle
[
     [2],
    [3,4],
   [6,5,7],
  [4,1,8,3]
]
The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).

Note:
Bonus point if you are able to do this using only O(n) extra space, where n is the total number of rows in the triangle.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public void Test_MinimumTotal2()
        {
            MinimumTotal2(new List<IList<int>> {new List<int> {1}, new List<int> {2, 3}});
        }

        public int MinimumTotal3(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            var dp = triangle[triangle.Count - 1].ToArray();
            for (int i = n - 2; i >= 0; --i)
            {
                for (int j = 0; j <= i; ++j)
                {
                    dp[j] = Math.Min(dp[j], dp[j + 1]) + triangle[i][j];
                }
            }
            return dp[0];
        }

        public int MinimumTotal2(IList<IList<int>> triangle)
        {
            if (triangle.Count == 1)
            {
                return triangle[0][0];
            }
            int[,] dp = new int[triangle.Count, triangle[triangle.Count - 1].Count];
            dp[0, 0] = triangle[0][0];
            int ret = int.MaxValue;
            for (int i = 1; i < triangle.Count; i++)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + triangle[i][j];
                    }
                    else if (j == triangle[i].Count - 1)
                    {
                        dp[i, j] = dp[i - 1, j - 1] + triangle[i][j];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], dp[i - 1, j]) + triangle[i][j];
                    }

                    if (i == triangle.Count - 1)
                    {
                        ret = Math.Min(ret, dp[i, j]);
                    }
                }
            }

            return ret;
        }

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int[] dp = new int[triangle[triangle.Count - 1].Count];
            foreach (IList<int> l in triangle)
            {
                for (int i = l.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        dp[i] = dp[i] + l[i];
                    }
                    else if (i == l.Count - 1)
                    {
                        dp[i] = dp[i - 1] + l[i];
                    }
                    else
                    {
                        dp[i] = Math.Min(dp[i - 1], dp[i]) + l[i];
                    }
                }
            }

            return dp.Min();
        }
    }
}
