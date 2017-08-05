﻿/*
605. Can Place Flowers
Suppose you have a long flowerbed in which some of the plots are planted and some are not. However, flowers cannot be planted in adjacent plots - they would compete for water and both would die.

Given a flowerbed (represented as an array containing 0 and 1, where 0 means empty and 1 means not empty), and a number n, return if n new flowers can be planted in it without violating the no-adjacent-flowers rule.

Example 1:
Input: flowerbed = [1,0,0,0,1], n = 1
Output: True
Example 2:
Input: flowerbed = [1,0,0,0,1], n = 2
Output: False
Note:
The input array won't violate no-adjacent-flowers rule.
The input array size is in the range of [1, 20000].
n is a non-negative integer which won't exceed the input array size.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            for (int i = 0; i < flowerbed.Length; ++i)
            {
                if (n == 0)
                {
                    return true;
                }

                if (flowerbed[i] == 0)
                {
                    int next = (i == flowerbed.Length - 1 ? 0 : flowerbed[i + 1]);
                    int pre = (i == 0 ? 0 : flowerbed[i - 1]);
                    if (next + pre == 0)
                    {
                        flowerbed[i] = 1;
                        --n;
                    }
                }
            }
            return n <= 0;
        }

        public bool CanPlaceFlowers2(int[] flowerbed, int n)
        {
            // number of zero
            var acc = 1;
            var count = 0;
            foreach (var i in flowerbed)
            {
                if (i == 0)
                {
                    if (++acc == 3)
                    {
                        count++;
                        acc = 1;
                    }
                }
                else
                {
                    acc = 0;
                }
            }

            if (acc == 2)
            {
                ++count;
            }

            return count >= n;
        }
    }
}
