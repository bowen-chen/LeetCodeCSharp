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
            if (strs == null || strs.Length == 0) return "";
            string pre = strs[0];
            int i = 1;
            while (i < strs.Length)
            {
                while (strs[i].IndexOf(pre) != 0)
                {
                    pre = pre.Substring(0, pre.Length - 1);
                }
                i++;
            }
            return pre;
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || c != strs[j][i])
                    {
                        return sb.ToString();
                    }
                }
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
