/*
576. Out of Boundary Paths
*
There is an m by n grid with a ball. Given the start coordinate (i,j) of the ball, you can move the ball to adjacent cell or cross the grid boundary in four directions (up, down, left, right). However, you can at most move N times. Find out the number of paths to move the ball out of grid boundary. The answer may be very large, return it after mod 109 + 7.

Example 1:
Input:m = 2, n = 2, N = 2, i = 0, j = 0
Output: 6
Explanation:

Example 2:
Input:m = 1, n = 3, N = 3, i = 0, j = 1
Output: 12
Explanation:

Note:
Once you move the ball out of boundary, you cannot move it back.
The length and height of the grid is in range [1,50].
N is in range [0,50].
*/

namespace Demo
{
    public partial class Solution
    {
        public int FindPaths(int m, int n, int N, int i, int j)
        {
            if (N <= 0) return 0;
            const int mod = 1000000007;
            var dp = new long[m, n, N + 1]; // init value dp[m,n,0]
            for (int step = 1; step <= N; step++)
            {
                for (int row = 0; row < m; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        dp[row, col, step] = (
                            (row == 0 ? 1 : dp[row - 1, col, step - 1]) /*move up*/ +
                            (row == m - 1 ? 1 : dp[row + 1, col, step - 1]) /*move down*/ +
                            (col == 0 ? 1 : dp[row, col - 1, step - 1]) /*move left*/+
                            (col == n - 1 ? 1 : dp[row, col + 1, step - 1]))%mod /*move right*/;
                    }
                }
            }

            return (int)dp[i,j,N];
        }

        public int FindPaths2(int m, int n, int N, int i, int j)
        {
            if (N <= 0)
            {
                return 0;
            }

            const int mod = 1000000007;
            var dp = new long[m, n];
            for (int step = 1; step <= N; step++)
            {
                var dp2 = new long[m, n];
                for (int row = 0; row < m; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        dp2[row, col] = (
                            (row == 0 ? 1 : dp[row - 1, col]) /*move up*/+
                            (row == m - 1 ? 1 : dp[row + 1, col]) /*move down*/+
                            (col == 0 ? 1 : dp[row, col - 1]) /*move left*/+
                            (col == n - 1 ? 1 : dp[row, col + 1]))%mod /*move right*/;
                    }
                }

                dp = dp2;
            }

            return (int)dp[i, j];
        }
    }
}
