/*
76	Minimum Window Substring
medium, window
Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

For example,
S = "ADOBECODEBANC"
T = "ABC"
Minimum window is "BANC".

Note:
If there is no such window in S that covers all characters in T, return the empty string "".

If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S.
*/

namespace Demo
{
    public partial class Solution
    {
        public void Test_MinWindow()
        {
            MinWindow("a", "a");
        }

        public string MinWindow(string s, string t)
        {
            var m = new int[128];

            // Statistic for count of char in t
            foreach (char c in t)
            {
                m[c-'A']++;
            }

            // counter represents the number of chars of t to be found in s.
            int start = 0;
            int end = 0;
            int counter = t.Length;
            int minStart = 0;
            int minLen = int.MaxValue;

            // Move end to find a valid window.
            while (end < s.Length)
            {
                // Decrease m[s[end]]. m[s[end]] will be negative.
                
                // If char in s exists in t, decrease counter
                if (--m[s[end++] - 'A'] >= 0)
                {
                    counter--;
                }

                // When we found a valid window, move start to find smaller window.
                while (counter == 0)
                {
                    if (end - start < minLen)
                    {
                        minStart = start;
                        minLen = end - start;
                    }
                    
                    // When char exists in t, increase counter.
                    if (++m[s[start++] - 'A']> 0)
                    {
                        counter++;
                    }
                }
            }

            if (minLen != int.MaxValue)
            {
                return s.Substring(minStart, minLen);
            }

            return "";
        }
    }
}
