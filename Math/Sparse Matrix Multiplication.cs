/*
311	Sparse Matrix Multiplication $
Problem Description:

Given two sparse matrices A and B, return the result of AB.

You may assume that A's column number is equal to B's row number.

Example:

A = [
  [ 1, 0, 0],
  [-1, 0, 3]
]

B = [
  [ 7, 0, 0 ],
  [ 0, 0, 0 ],
  [ 0, 0, 1 ]
]


     |  1 0 0 |   | 7 0 0 |   |  7 0 0 |
AB = | -1 0 3 | x | 0 0 0 | = | -7 0 3 |
                  | 0 0 1 |
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        // AxB x BxC = AxC
        public int[,] Multiply(int[,] A, int[,] B)
        {
            int m = A.GetLength(0), n = A.GetLength(1), nB = B.GetLength(1);
            int[,] C = new int[m, nB];

            for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (A[i, k] != 0)
                    {
                        for (int j = 0; j < nB; j++)
                        {
                            if (B[k, j] != 0)
                            {
                                C[i, j] += A[i, k]*B[k, j];
                            }
                        }
                    }
                }
            }
            return C;
        }

        public int[,] Multiply2(int[,] A, int[,] B)
        {
            int mA = A.GetLength(0);
            int nA = A.GetLength(1);
            int nB = B.GetLength(1);
            int[,] res = new int[mA, nB];
            var v = new List<int[]>[mA];
            for (int i = 0; i < mA; ++i)
            {
                v[i] = new List<int[]>();
                for (int j = 0; j < nA; ++j)
                {
                    if (A[i, j] != 0)
                    {
                        v[i].Add(new[] {j, A[i, j]});
                    }
                }
            }
            for (int i = 0; i < mA; ++i)
            {
                foreach (var k in v[i])
                {
                    int col = k[0];
                    int val = k[1];
                    for (int j = 0; j < nB; ++j)
                    {
                        res[i, j] += val*B[col, j];
                    }
                }
            }
            return res;
        }
    }
}
