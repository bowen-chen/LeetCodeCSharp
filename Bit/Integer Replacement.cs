﻿/*
397	Integer Replacement
Given a positive integer n and you can do operations as follow:

If n is even, replace n with n/2.
If n is odd, you can replace n with either n + 1 or n - 1.
What is the minimum number of replacements needed for n to become 1?

Example 1:

Input:
8

Output:
3

Explanation:
8 -> 4 -> 2 -> 1

Example 2:

Input:
7

Output:
4

Explanation:
7 -> 8 -> 4 -> 2 -> 1
or
7 -> 6 -> 3 -> 2 -> 1

0b1bcdefg0 / 2= 0babcdefg
0b1bcdef01 -> 0babcdef00 -> 0babcdef0 -> 0babcdef
0b1bcdef11 -> 0b1bcdeg00 -> 0b1bcdeg -> 0b1bcde(f+1)

*/

namespace Demo
{
    public partial class Solution
    {
        public int IntegerReplacement(int n)
        {
            if (n == int.MaxValue)
            {
                return 32; //n = 2^31-1;
            }

            int count = 0;
            while (n > 1)
            {
                if (n%2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    // n+1 = 2k+2 -> k+1
                    // n-1 = 2k -> K
                    // choose even number from k, k+1
                    if ((n + 1)%4 == 0 && (n - 1 != 2))
                    {
                        n++;
                    }
                    else
                    {
                        n--;
                    }
                }

                count++;
            }
            return count;
        }
    }
}
