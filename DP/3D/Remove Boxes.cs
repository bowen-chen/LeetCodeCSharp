/*
546. Remove Boxes
*
Given several boxes with different colors represented by different positive numbers. 
You may experience several rounds to remove b oxes until there is no box left. Each time you can choose some continuous boxes with the same color (composed of k boxes, k >= 1), remove them and get k*k points.
Find the maximum points you can get.

Example 1:
Input:

[1, 3, 2, 2, 2, 3, 4, 3, 1]
Output:
23
Explanation:
[1, 3, 2, 2, 2, 3, 4, 3, 1] 
----> [1, 3, 3, 4, 3, 1] (3*3=9 points) 
----> [1, 3, 3, 3, 1] (1*1=1 points) 
----> [1, 1] (3*3=9 points) 
----> [] (2*2=4 points)
Note: The number of boxes n would not exceed 100.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int RemoveBoxes(int[] boxes)
        {
            int n = boxes.Length;
            // dp[i, j, k] max points from boxes[i, j] when there are k boxes at left side as same boxes[i]
            var dp = new int[n, n, n];
            return RemoveBoxes(boxes, 0, n - 1, 0, dp);
        }

        private int RemoveBoxes(int[] boxes, int i, int j, int k, int[,,] dp)
        {
            if (j < i)
            {
                return 0;
            }

            if (dp[i, j, k] > 0)
            {
                return dp[i, j, k];
            }

            //remove boxes[i]
            int res = (1 + k)*(1 + k) + RemoveBoxes(boxes, i + 1, j, 0, dp);
            for (int m = i + 1; m <= j; ++m)
            {
                // Join boxes[i] and boxes[m]
                if (boxes[m] == boxes[i])
                {
                    res = Math.Max(
                        res,
                        // box[i+1] != box[i] + box[m] == box[i]
                        RemoveBoxes(boxes, i + 1, m - 1, 0, dp) + RemoveBoxes(boxes, m, j, k + 1, dp));
                }
            }

            return dp[i, j, k] = res;
        }

        public int RemoveBoxes2(int[] boxes)
        {
            int n = boxes.Length;

            // dp[i, j, k] max points from boxes[i, j] when there are k boxes at left side as same boxes[i]
            // init value dp[i,i,x] = x+1*x+1
            var dp = new int[n, n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int k = 0; k <= i; ++k)
                {
                    dp[i, i, k] = (1 + k)*(1 + k);
                }
            }

            // t is range length - 1
            for (int t = 1; t < n; ++t)
            {
                // i is start of range
                for (int i = 0; i + t < n; ++i)
                {
                    // j is end of range
                    int j = i + t;

                    // k is number of same number at left of boxes[i]
                    // the max is i, which all numbers are same of boxes[i] 
                    for (int k = 0; k <= i; ++k)
                    {
                        // choose boxes[i]
                        int res = (1 + k)*(1 + k) + dp[i + 1, j, 0];

                        // find a boxes[m] = boxes[i], erase boxes[i+1,m-1] to join boxes[m] and boxes[i]
                        for (int m = i + 1; m <= j; ++m)
                        {
                            if (boxes[m] == boxes[i])
                            {
                                res = Math.Max(res, dp[i + 1, m - 1, 0] + dp[m, j, k + 1]);
                            }
                        }

                        dp[i, j, k] = res;
                    }
                }
            }

            return n == 0 ? 0 : dp[0, n - 1, 0];
        }
    }
}
