/*
378. Kth Smallest Element in a Sorted Matrix
Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.

Note that it is the kth smallest element in the sorted order, not the kth distinct element.

Example:

matrix = [
   [ 1,  5,  9],
   [10, 11, 13],
   [12, 13, 15]
],
k = 8,

return 13.
Note: 
You may assume k is always valid, 1 ≤ k ≤ n2.
*/

namespace Demo
{
    public partial class Solution
    {
        public int KthSmallest(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            // find first low doesn't meet condition (number than matrix(low)<k)
            // we need use "doesn't meet condition search", since matrix could have dup number
            // so there may not be a low meet condition (number than matrix(low)==k-1)
            int low = matrix[0, 0];
            int high = matrix[n - 1, m - 1];
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int temp = SearchLowerThanX(matrix, mid);
                if (temp < k)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid-1;
                }
            }

            return low;
        }

        private int SearchLowerThanX(int[,] matrix, int x)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            // search from left bottom corner
            int i = n - 1, j = 0, cnt = 0;
            while (i >= 0 && j < m)
            {
                // move to column left
                if (matrix[i, j] <= x)
                {
                    j++;
                    cnt += (i + 1);
                }
                else
                {
                    i--;
                }
            }

            return cnt;
        }
    }
}
