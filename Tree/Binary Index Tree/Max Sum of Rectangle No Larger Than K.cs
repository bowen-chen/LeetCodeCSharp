/*
363. Max Sum of Rectangle No Larger Than K
Given a non-empty 2D matrix matrix and an integer k, find the max sum of a rectangle in the matrix such that its sum is no larger than k.

Example:
Given matrix = [
  [1,  0, 1],
  [0, -2, 3]
]
k = 2
The answer is 2. Because the sum of rectangle [[0, 1], [-2, 3]] is 2 and 2 is the max number no larger than k (k = 2).

Note:
The rectangle inside the matrix must have an area > 0.
What if the number of rows is much larger than the number of columns?
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int MaxSumSubmatrix(int[,] matrix, int k)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if (m == 0 || n == 0) return 0;
            int res = int.MinValue;
            int[,] sum = new int[m, n];
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    int t = matrix[i, j];
                    if (i > 0) t += sum[i - 1, j];
                    if (j > 0) t += sum[i, j - 1];
                    if (i > 0 && j > 0) t -= sum[i - 1, j - 1];
                    sum[i, j] = t;

                    // Traverse all recetangle ending with i,j
                    for (int r = 0; r <= i; ++r)
                    {
                        for (int c = 0; c <= j; ++c)
                        {
                            int d = sum[i, j];
                            if (r > 0) d -= sum[r - 1, j];
                            if (c > 0) d -= sum[i, c - 1];
                            if (r > 0 && c > 0) d += sum[r - 1, c - 1];
                            if (d <= k) res = Math.Max(res, d);
                        }
                    }
                }
            }
            return res;
        }

        public int MaxSumSubmatrix2(int[,] matrix, int k)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if (m == 0 || n == 0)
            {
                return 0;
            }

            int res = int.MinValue;
            for (int left = 0; left < n; ++left)
            {
                // sum[row] is sum of sum[row, left->right]
                int[] sum = new int[m];
                for (int right = left; right < n; ++right)
                {
                    for (int row = 0; row < m; ++row)
                    {
                        sum[row] += matrix[row, right];
                    }

                    int curSum = 0;
                    int curMax = int.MinValue;
                    var s = new SortedList<int, int>
                    {
                        {0, 0}
                    };

                    foreach (int a in sum)
                    {
                        curSum += a;
                        var it = FindLowerBound(s, curSum - k);
                        if (it != s.Count)
                        {
                            curMax = Math.Max(curMax, curSum - s[s.Keys[it]]);
                        }

                        if (!s.ContainsKey(curSum))
                        {
                            s.Add(curSum, curSum);
                        }
                    }

                    res = Math.Max(res, curMax);
                }
            }

            return res;
        }

        private int FindLowerBound(SortedList<int, int> sortedList, int target)
        {
            // find the first number not (less than target)
            int low = 0;
            int high = sortedList.Count - 1;
            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                if (sortedList[sortedList.Keys[mid]] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return low;
        }
    }
}
