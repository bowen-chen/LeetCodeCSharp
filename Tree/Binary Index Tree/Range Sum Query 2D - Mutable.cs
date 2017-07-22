/*
308 Range Sum Query 2D - Mutable
hard, 2D binary index tree
Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).

Range Sum Query 2D
The above rectangle (with the red border) is defined by (row1, col1) = (2, 1) and (row2, col2) = (4, 3), which contains sum = 8.

Example:
Given matrix = [
      [3, 0, 1, 4, 2],
      [5, 6, 3, 2, 1],
      [1, 2, 0, 1, 5],
      [4, 1, 0, 1, 7],
      [1, 0, 3, 0, 5]
    ]

sumRegion(2, 1, 4, 3) -> 8
update(3, 2, 2)
sumRegion(2, 1, 4, 3) -> 10
Note:
    The matrix is only modifiable by the update function.
    You may assume the number of calls to update and sumRegion function is distributed evenly.
    You may assume that row1 ≤ row2 and col1 ≤ col2.

*/

namespace Demo
{
    public class NumMatrix2
    {
        private readonly int[,] tree;
        private readonly int[,] nums;
        private readonly int m;
        private readonly int n;

        public NumMatrix2(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return;
            }

            m = matrix.GetLength(0);
            n = matrix.GetLength(1);
            tree = new int[m + 1, n + 1];
            nums = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Update(i, j, matrix[i, j]);
                }
            }
        }


        public void Update(int row, int col, int val)
        {
            if (m == 0 || n == 0) return;
            int delta = val - nums[row, col];
            nums[row, col] = val;
            for (int i = row + 1; i <= m; i += i & (-i))
            {
                for (int j = col + 1; j <= n; j += j & (-j))
                {
                    tree[i, j] += delta;
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            if (m == 0 || n == 0)
            {
                return 0;
            }

            return Sum(row2, col2) + Sum(row1 - 1, col1 - 1) - Sum(row1 - 1, col2) - Sum(row2, col1 - 1);
        }

        public int Sum(int row, int col)
        {
            int sum = 0;
            for (int i = row + 1; i >= 1; i -= i & (-i))
            {
                for (int j = col + 1; j >= 1; j -= j & (-j))
                {
                    sum += tree[i, j];
                }
            }

            return sum;
        }
    }

    // time should be O(log(m) * log(n))
}
