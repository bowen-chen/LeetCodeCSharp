/*
14	Longest Common Prefix
easy
Write a function to find the longest common prefix string amongst an array of strings.
*/

using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string LongestCommonPrefix2(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            for (int i = 0; i < strs[0].Length; i++)
            {
                var c = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || c != strs[j][i])
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }

            return strs[0];
        }
    }
}
