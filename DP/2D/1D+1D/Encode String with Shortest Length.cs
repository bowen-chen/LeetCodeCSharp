/*
471	Encode String with Shortest Length $
hard
Encode String with Shortest Length
Given a non-empty string, encode the string such that its encoded length is the shortest.

The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times.

Note:
k will be a positive integer and encoded string will not be empty or have extra space.
You may assume that the input string contains only lowercase English letters. The string's length is at most 160.
If an encoding process does not make the string shorter, then do not encode it. If there are several solutions, return any of them is fine.
Example 1:

Input: "aaa"
Output: "aaa"
Explanation: There is no way to encode it such that it is shorter than the input string, so we do not encode it.
Example 2:

Input: "aaaaa"
Output: "5[a]"
Explanation: "5[a]" is shorter than "aaaaa" by 1 character.
Example 3:

Input: "aaaaaaaaaa"
Output: "10[a]"
Explanation: "a9[a]" or "9[a]a" are also valid solutions, both of them have the same length = 5, which is the same as "10[a]".
Example 4:

Input: "aabcaabcd"
Output: "2[aabc]d"
Explanation: "aabc" occurs twice, so one answer can be "2[aabc]d".
Example 5:

Input: "abbbabbbcabbbabbbc"
Output: "2[2[abbb]c]"
Explanation: "abbbabbbc" occurs twice, but "abbbabbbc" can also be encoded to "2[abbb]c", so one answer can be "2[2[abbb]c]".
*/

namespace Demo
{
    public partial class Solution
    {
        public string Encode(string s)
        {
            int n = s.Length;

            // dp[i,j] the min encode from s[i->j] 
            var dp = new string[n,n];
            for (int step = 1; step <= n; step++)
            {
                for (int i = 0; i + step - 1 < n; i++)
                {
                    int j = i + step - 1;

                    // try encode the whole string
                    // T= P1P2P3
                    // TT = P1P2P3P1P2P3
                    // Match  P1P2P3P1P2P3
                    // P1=P2=P3
                    string temp = s.Substring(i, step);
                    var pos = (temp + temp).IndexOf(temp, 1);
                    if (pos >= temp.Length)
                    {
                        dp[i, j] = temp;
                    }
                    else
                    {
                        // pos is matched pattern length
                        dp[i, j] = (temp.Length/pos) + '[' + dp[i, i + pos - 1] + ']';
                    }
                    
                    // break on k and encode each strings s[i,k] s[k+1, j]
                    for (int k = i; k < j; k++)
                    {
                        string left = dp[i,k];
                        string right = dp[k + 1,j];
                        if (left.Length + right.Length < dp[i,j].Length)
                        {
                            dp[i,j] = left + right;
                        }
                    }
                }
            }

            return dp[0, n - 1];
        }
    }
}
