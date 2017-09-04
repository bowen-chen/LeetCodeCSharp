/*
292	Nim Game 
easy, math, *
Nim Game

You are playing the following Nim Game with your friend: There is a heap of stones on the table, each time one of you take turns to remove 1 to 3 stones. The one who removes the last stone will be the winner. You will take the first turn to remove the stones.

Both of you are very clever and have optimal strategies for the game. Write a function to determine whether you can win the game given the number of stones in the heap.

For example, if there are 4 stones in the heap, then you will never win the game: no matter 1, 2, or 3 stones you remove, the last stone will always be removed by your friend.

Hint:

If there are 5 stones in the heap, could you figure out a way to remove the stones such that you will always be the winner?
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool CanWinNim(int n)
        {
            return n%4 != 0;
        }
        public bool CanWinNim2(int n)
        {
            return CanWinNim(n, new Dictionary<int, bool>());
        }

        public bool CanWinNim(int n, Dictionary<int, bool> cache)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            bool ret = false;
            if (n <= 3)
            {
                ret = true;
            }
            else
            {
                for (int i = 1; i <= 3; i++)
                {
                    ret |= !CanWinNim(n - i, cache);
                }
            }
            cache[n] = ret;
            return ret;
        }
    }
}
