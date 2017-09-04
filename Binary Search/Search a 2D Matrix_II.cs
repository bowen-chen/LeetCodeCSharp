/*
240. Search a 2D Matrix II
easy, *
Search a 2D Matrix II

Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

Integers in each row are sorted in ascending from left to right.
Integers in each column are sorted in ascending from top to bottom.
For example,

Consider the following matrix:

[
  [1,   4,  7, 11, 15],
  [2,   5,  8, 12, 19],
  [3,   6,  9, 16, 22],
  [10, 13, 14, 17, 24],
  [18, 21, 23, 26, 30]
]
Given target = 5, return true.

Given target = 20, return false.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool SearchMatrix3(int[,] matrix, int target)
        {
            if (matrix == null)
            {
                return true;
            }

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int i = 0;
            int j = n-1;

            while (i<m && j >=0)
            {
                int cur = matrix[i, j];
                if (cur == target)
                {
                    return true;
                }
                if (cur > target)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return false;
        }
    }
}
