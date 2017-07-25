/*
639. Decode Ways II
A message containing letters from A-Z is being encoded to numbers using the following mapping way:

'A' -> 1
'B' -> 2
...
'Z' -> 26
Beyond that, now the encoded string can also contain the character '*', which can be treated as one of the numbers from 1 to 9.

Given the encoded message containing digits and the character '*', return the total number of ways to decode it.

Also, since the answer may be very large, you should return the output mod 109 + 7.

Example 1:
Input: "*"
Output: 9
Explanation: The encoded message can be decoded to the string: "A", "B", "C", "D", "E", "F", "G", "H", "I".
Example 2:
Input: "1*"
Output: 9 + 9 = 18
Note:
The length of the input string will fit in range [1, 105].
The input string will only contain the character '*' and digits '0' - '9'.
*/

namespace Demo
{
    public partial class Solution
    {
        public int NumDecodings21(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int p2 = 1;
            int p1 = PossibleNumber(s[0]);
            if (s.Length == 1)
            {
                return p1;
            }

            int p = 0;
            for (int i = 1; i < s.Length; i++)
            {
                p = p2*PossibleNumber(s[i - 1], s[i]) + p1*PossibleNumber(s[i]);
                p2 = p1;
                p1 = p;
            }

            return p;
        }

        private int PossibleNumber(char c1)
        {
            return c1 == '0' ? 0 : c1 == '*' ? 9 : 1;
        }

        private int PossibleNumber(char c1, char c2)
        {
            if (c1 == '*')
            {
                if (c2=='*')
                {
                    // 11-19 21-26
                    return 15;
                }
                if (c2 >= '0' && c2 <= '6')
                {
                    // 1X, 2X
                    return 2;
                }

                // 1X
                return 1;
            }

            if (c1 == '1')
            {
                if (c2 == '*')
                {
                    // 11-19
                    return 9;
                }

                // 1X
                return 1;
            }

            if (c1 == '2')
            {
                if (c2 == '*')
                {
                    // 21-26
                    return 6;
                }
                if (c2 >= '0' && c2 <= '6')
                {
                    // 2X
                    return 1;
                }
            }

            return 0;
        }
    }
}
