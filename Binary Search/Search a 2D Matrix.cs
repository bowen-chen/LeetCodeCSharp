/*
74. Search a 2D Matrix
easy, low/high
Search a 2D Matrix

Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

Integers in each row are sorted from left to right.
The first integer of each row is greater than the last integer of the previous row.
For example,

Consider the following matrix:

[
  [1,   3,  5,  7],
  [10, 11, 16, 20],
  [23, 30, 34, 50]
]
Given target = 3, return true.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int l = 0, h = m*n - 1;
            while (l <= h)
            {
                int mid = l + (h - l)/2;
                int cur = matrix[mid/m, mid%m];
                if (cur == target)
                {
                    return true;
                }

                if (cur < target)
                {
                    l = mid + 1;
                }
                else
                {
                    h = mid - 1;
                }
            }
            return false;
        }
    }
}
