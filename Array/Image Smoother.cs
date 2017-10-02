/*
661. Image Smoother
Given a 2D integer matrix M representing the gray scale of an image, you need to design a smoother to make the gray scale of each cell becomes the average gray scale (rounding down) of all the 8 surrounding cells and itself. If a cell has less than 8 surrounding cells, then use as many as you can.

Example 1:
Input:
[[1,1,1],
 [1,0,1],
 [1,1,1]]
Output:
[[0, 0, 0],
 [0, 0, 0],
 [0, 0, 0]]
Explanation:
For the point (0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
For the point (0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
For the point (1,1): floor(8/9) = floor(0.88888889) = 0
Note:
The value in the given matrix is in the range of [0, 255].
The length and width of the given matrix are in the range of [1, 150].
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int[,] ImageSmoother(int[,] M)
        {
            int m = M.GetLength(0);
            int n = M.GetLength(1);
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    int count = 0;
                    int sum = 0;
                    for (int i2 = Math.Max(i - 1, 0); i2 <= Math.Min(i + 1, m - 1); ++i2)
                    {
                        for (int j2 = Math.Max(j - 1, 0); j2 <= Math.Min(j + 1, n - 1); ++j2)
                        {
                            sum += M[i2, j2] & 0xFF;
                            count++;
                        }
                    }

                    M[i, j] |= (sum / count) << 8;
                }
            }

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    M[i, j] >>= 8;
                }
            }

            return M;
        }
    }
}
