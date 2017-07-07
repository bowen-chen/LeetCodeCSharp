/*
486. Predict the Winner
medium
Given an array of scores that are non-negative integers. Player 1 picks one of the numbers from either end of the array followed by the player 2 and then player 1 and so on. Each time a player picks a number, that number will not be available for the next player. This continues until all the scores have been chosen. The player with the maximum score wins.

Given an array of scores, predict whether player 1 is the winner. You can assume each player plays to maximize his score.

Example 1:
Input: [1, 5, 2]
Output: False
Explanation: Initially, player 1 can choose between 1 and 2. 
If he chooses 2 (or 1), then player 2 can choose from 1 (or 2) and 5. If player 2 chooses 5, then player 1 will be left with 1 (or 2). 
So, final score of player 1 is 1 + 2 = 3, and player 2 is 5. 
Hence, player 1 will never be the winner and you need to return False.
Example 2:
Input: [1, 5, 233, 7]
Output: True
Explanation: Player 1 first chooses 1. Then player 2 have to choose between 5 and 7. No matter which number player 2 choose, player 1 can choose 233.
Finally, player 1 has more score (234) than player 2 (12), so you need to return True representing player1 can win.
Note:
1 <= length of the array <= 20.
Any scores in the given array are non-negative integers and will not exceed 10,000,000.
If the scores of both players are equal, then player 1 is still the winner.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public bool PredictTheWinner(int[] nums)
        {
            int n = nums.Length;
            var dp = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; i++)
                {
                    dp[i, j] = -1;
                }
            }
            return PredictTheWinner(nums, 0, n - 1, dp) >= 0;
        }

        // best score
        private int PredictTheWinner(int[] nums, int s, int e, int[,] dp)
        {
            if (dp[s, e] == -1)
            {
                dp[s, e] =
                    (s == e) ?
                    nums[s] :
                    Math.Max(
                        nums[s] - PredictTheWinner(nums, s + 1, e, dp),
                        nums[e] - PredictTheWinner(nums, s, e - 1, dp));
            }

            return dp[s, e];
        }

        public bool PredictTheWinner3(int[] nums)
        {
            return CanWin(nums, 0, nums.Length-1, 0, 0, 1);
        }

        public bool CanWin(int[] nums, int low, int high, int sum1, int sum2, int player)
        {
            if (low > high)
            {
                return player == 1 ? sum1 >= sum2 : sum1 < sum2;
            }

            if (player == 1)
            {
                return !CanWin(nums, low + 1, high, sum1 + nums[low], sum2, 2) ||
                       !CanWin(nums, low, high - 1, sum1 + nums[high], sum2, 2);
            }

            return !CanWin(nums, low + 1, high, sum1, sum2 + nums[low], 1) ||
                   !CanWin(nums, low, high - 1, sum1, sum2 + nums[high], 1);
        }
    }
}
