/*
351 Android Unlock Patterns
medium
Given an Android 3x3 key lock screen and two integers m and n, where 1 ≤ m ≤ n ≤ 9, count the total number of unlock patterns of the Android lock screen, which consist of minimum of m keys and maximum n keys.

Rules for a valid pattern:

Each pattern must connect at least m keys and at most n keys.
All the keys must be distinct.
If the line connecting two consecutive keys in the pattern passes through any other keys, the other keys must have previously selected in the pattern. No jumps through non selected key is allowed.
The order of keys used matters.
 



Explanation:

| 1 | 2 | 3 |
| 4 | 5 | 6 |
| 7 | 8 | 9 |
 
Invalid move: 4 - 1 - 3 - 6 
Line 1 - 3 passes through key 2 which had not been selected in the pattern.

Invalid move: 4 - 1 - 9 - 2
Line 1 - 9 passes through key 5 which had not been selected in the pattern.

Valid move: 2 - 4 - 1 - 3 - 6
Line 1 - 3 is valid because it passes through key 2, which had been selected in the pattern

Valid move: 6 - 5 - 4 - 1 - 9 - 2
Line 1 - 9 is valid because it passes through key 5, which had been selected in the pattern.

Example:
Given m = 1, n = 1, return 9.
*/

namespace Demo
{
    public partial class Solution
    {
        public int NumberOfPatterns(int m, int n)
        {
            int res = 0;
            res += NumberOfPatterns(0, 0, 0, m, n, 0)*4;
            res += NumberOfPatterns(0, 1, 0, m, n, 0)*4;
            res += NumberOfPatterns(1, 1, 0, m, n, 0);
            return res;
        }

        private int NumberOfPatterns(int i, int j, int len, int m, int n, int visited)
        {
            int index = j + i*3;
            visited |= 1 << index;
            len++;
            int res = 0;
            if (len >= m)
            {
                res++;
            }

            if (len == n)
            {
                return res;
            }

            for (int next = 0; next <= 8; next++)
            {
                if ((visited & (1 << next)) == 0)
                {
                    int nexti = next / 3;
                    int nextj = next % 3;
                    int I = i + nexti, J = j + nextj;

                    // (1, 0) (2, 1) no middle point
                    if (I % 2 == 1 || J % 2 == 1 || (visited & (1 << (I / 2 * 3 + J / 2))) != 0)
                    {
                        res += NumberOfPatterns(nexti, nextj, len, m, n, visited);
                    }
                }
            }

            return res;
        }
    }
}
