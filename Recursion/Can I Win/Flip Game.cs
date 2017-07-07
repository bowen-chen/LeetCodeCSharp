/*
293	Flip Game $
easy
You are playing the following Flip Game with your friend: Given a string that contains only these two characters: + and -, you and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move and therefore the other person will be the winner.

Write a function to compute all possible states of the string after one valid move.

For example, given s = "++++", after one move, it may become one of the following states:

[
  "--++",
  "+--+",
  "++--"
]
*/

using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public List<string> GeneratePossibleNextMoves(string s)
        {
            var moves = new List<string>();
            if (s.Length < 2)
            {
                return moves;
            }
            int n = s.Length;
            var sb = new StringBuilder(s);
            for (int i = 0; i < n - 1; i++)
            {
                if (sb[i] == '+' && sb[i + 1] == '+')
                {
                    sb[i] = sb[i + 1] = '-';
                    moves.Add(sb.ToString());
                    sb[i] = sb[i + 1] = '+';
                }
            }
            return moves;
        }
    }
}
