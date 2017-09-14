﻿/*
374	Guess Number Higher or Lower
easy, *
We are playing the Guess Game. The game is as follows:

I pick a number from 1 to n. You have to guess which number I picked.

Every time you guess wrong, I'll tell you whether the number is higher or lower.

You call a pre-defined API guess(int num) which returns 3 possible results (-1, 1, or 0):

-1 : My number is lower
 1 : My number is higher
 0 : Congrats! You got it!
Example:

n = 10, I pick 6.

Return 6.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        // Forward declaration of guess API.
        // @param num, your guess
        // @return -1 if my number is lower, 1 if my number is higher, otherwise return 0
        public int GuessNumber(int n, Func<int, int> guess)
        {
            int low = 1;
            int high = n;
            while (low <= high)
            {
                int mid = low + (high - low)/2;
                int t = guess(mid);
                if (t == 0)
                {
                    return mid;
                }

                if (t == 1)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return low;
        }
    }
}
