/*
488. Zuma Game
Think about Zuma Game. You have a row of balls on the table, colored red(R), yellow(Y), blue(B), green(G), and white(W). You also have several balls in your hand.

Each time, you may choose a ball in your hand, and insert it into the row (including the leftmost place and rightmost place). Then, if there is a group of 3 or more balls in the same color touching, remove these balls. Keep doing this until no more balls can be removed.

Find the minimal balls you have to insert to remove all the balls on the table. If you cannot remove all the balls, output -1.

Examples:

Input: "WRRBBW", "RB"
Output: -1
Explanation: WRRBBW -> WRR[R]BBW -> WBBW -> WBB[B]W -> WW

Input: "WWRRBBWW", "WRBRW"
Output: 2
Explanation: WWRRBBWW -> WWRR[R]BBWW -> WWBBWW -> WWBB[B]WW -> WWWW -> empty

Input:"G", "GGGGG"
Output: 2
Explanation: G -> G[G] -> GG[G] -> empty 

Input: "RBYYBBRRB", "YRBGB"
Output: 3
Explanation: RBYYBBRRB -> RBYY[Y]BBRRB -> RBBBRRB -> RRRB -> B -> B[B] -> BB[B] -> empty 

Note:
You may assume that the initial row of balls on the table won’t have any 3 or more consecutive balls with the same color.
The number of balls on the table won't exceed 20, and the string represents these balls is called "board" in the input.
The number of balls in your hand won't exceed 5, and the string represents these balls is called "hand" in the input.
Both input strings will be non-empty and only contain characters 'R','Y','B','G','W'.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int FindMinStep(string board, string hand)
        {
            var m =  new int[26];
            foreach (char c in hand)
            {
                m[c-'A'] ++;
            }

            var res = FindMinStep(board, m);
            return res == int.MaxValue ? -1 : res;
        }

        public int FindMinStep(string board, int[] hand)
        {
            if (board.Length == 0)
            {
                return 0;
            }
            
            int res = int.MaxValue;
            for (int i = 0, j = 1; j <= board.Length; ++j)
            {
                if (j < board.Length && board[i] == board[j])
                {
                    continue;
                }

                int need = 3 - (j - i);
                if (hand[board[i] - 'A'] >= need)
                {

                    hand[board[i] - 'A'] -= need;
                    string newBoard = board.Substring(0, i) + board.Substring(j);
                    newBoard = RemoveConsecutive(newBoard);
                    int steps = FindMinStep(newBoard, hand);
                    if (steps != int.MaxValue)
                    {
                        res = Math.Min(res, steps + need);
                    }

                    hand[board[i] - 'A'] += need;
                }

                i = j;
            }

            return res;
        }
        private string RemoveConsecutive(string board)
        {
            for (int i = 0, j = 1; j <= board.Length; ++j)
            {
                if (j < board.Length && board[i] == board[j])
                {
                    continue;
                }

                if (j - i >= 3)
                {
                    return RemoveConsecutive(board.Substring(0, i) + (j < board.Length ? board.Substring(j) : ""));
                }

                i = j;
            }

            return board;
        }
    }
}
