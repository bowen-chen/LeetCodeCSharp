/*
93	Restore IP Addresses
easy, dp, *
Given a string containing only digits, restore it by returning all possible valid IP address combinations.

For example:
Given "25525511135",

return ["255.255.11.135", "255.255.111.35"]. (Order does not matter)
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public void Test_RestoreIpAddresses()
        {
            RestoreIpAddresses("000000");
        }

        public IList<string> RestoreIpAddresses(string s)
        {
            var dp = new List<string>[s.Length + 1, 4];
            dp[0, 0] = new List<string>();
            dp[0, 1] = new List<string>();
            dp[0, 2] = new List<string>();
            dp[0, 3] = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                dp[i + 1, 0] = new List<string>();
                dp[i + 1, 1] = new List<string>();
                dp[i + 1, 2] = new List<string>();
                dp[i + 1, 3] = new List<string>();
                for (int j = i; j >= 0 && j >= i - 2; j--)
                {
                    var tmp = s.Substring(j, i - j + 1);
                    if (tmp.Length == 1 || (!tmp.StartsWith("0") && int.Parse(tmp) <= 255))
                    {
                        tmp += ".";

                        // if it is at beginning of the string
                        if (j == 0)
                        {
                            dp[i + 1, 0].Add(tmp);
                        }

                        dp[i + 1, 1].AddRange(dp[j, 0].Select(p => p + tmp));
                        dp[i + 1, 2].AddRange(dp[j, 1].Select(p => p + tmp));
                        dp[i + 1, 3].AddRange(dp[j, 2].Select(p => p + tmp));
                    }
                }
            }

            return dp[s.Length, 3].Select(p => p.TrimEnd('.')).ToList();
        }

        public IList<string> RestoreIpAddresses2(string s)
        {
            var res = new List<string>();
            RestoreIpAddresses2(s, 0, 4, "", res);
            return res;
        }

        private void RestoreIpAddresses2(string s, int i, int k, string cur, IList<string> res)
        {
            if (k == 0)
            {
                if (i == s.Length)
                {
                    res.Add(cur.TrimEnd('.'));
                }

                return;
            }

            for (int j = 1; j <= 3; ++j)
            {
                var tmp = s.Substring(i, j);
                if (tmp.Length == 1 || (!tmp.StartsWith("0") && int.Parse(tmp) <= 255))
                {
                    RestoreIpAddresses2(s, i + j, k - 1, cur + tmp + ".", res);
                }
            }
        }
    }
}
