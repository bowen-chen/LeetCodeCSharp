/*
498	Diagonal Traverse
Given a matrix of M x N elements (M rows, N columns), return all elements of the matrix in diagonal order as shown in the below image.

Example:
Input:
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
Output:  [1,2,4,7,5,3,6,8,9]
Explanation:

Note:
The total number of elements of the given matrix will not exceed 10,000.

*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int[] FindDiagonalOrder(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return new int[0];
            }

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int k = 0;
            var res = new int[m*n];
            for (int i = 0; i < m + n - 1; ++i)
            {
                int low = Math.Max(0, i - (n - 1));
                int high = Math.Min(i, m - 1);
                if (i%2 == 0)
                {
                    for (int j = high; j >= low; --j)
                    {
                        res[k++] = matrix[j, i - j];
                    }
                }
                else
                {
                    for (int j = low; j <= high; ++j)
                    {
                        res[k++] = matrix[j, i - j];
                    }
                }
            }
            return res;
        }
    }
}
