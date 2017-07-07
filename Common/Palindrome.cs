namespace Demo
{
    public partial class Solution
    {
        private bool[,] BuildPalindromeDP3(string s)
        {
            bool[,] dp = new bool[s.Length, s.Length];

            for (int len = 1; len <= s.Length; len++)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    int j = i + len - 1;
                    if (j < s.Length)
                    {
                        if (len == 1)
                        {
                            dp[i, j] = true;
                        }
                        else if (len == 2)
                        {
                            dp[i, j] = s[i] == s[j];
                        }
                        else
                        {
                            dp[i, j] = s[i] == s[j] && dp[i + 1, j - 1];
                        }
                    }
                }
            }

            return dp;
        }

        private bool[,] BuildPalindromeDP(string s)
        {
            bool[,] dp = new bool[s.Length, s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    dp[i, j] = IsPalindrome(s, i, j);
                }
            }
            return dp;
        }

        static private bool IsPalindrome(string s, int i, int j)
        {
            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
    }
}
