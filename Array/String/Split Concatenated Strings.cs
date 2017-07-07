/*
555	Split Concatenated Strings
Given a list of strings, you could assemble these strings together into a loop. Among all the possible loops, you need to find the lexicographically biggest string after cutting and making one breakpoint of the loop, which will make a looped string into a regular one.

So, to find the lexicographically biggest string, you need to experience two phases:

Assemble all the strings into a loop, where you can reverse some strings or not and connect them in the same order as given.
Cut and make one breakpoint in any place of the loop, which will make a looped string into a regular string starting from the character at the cutting point.
And your job is to find the lexicographically biggest one among all the regular strings.

Example:

Input: "abc", "xyz"
Output: "zyxcba"
Explanation: You can get the looped string "-abcxyz-", "-abczyx-", "-cbaxyz-", "-cbazyx-", 
where '-' represents the looped status. 
The answer string came from the third looped one, 
where you could cut from the middle and get "zyxcba".
Note:

The input strings will only contain lowercase letters.
The total length of all the strings will not over 1000.
*/
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public string SplitLoopedString(string[] strs)
        {
            for (int i = 0; i < strs.Length; i++)
            {
                var reverse = new string(strs[i].Reverse().ToArray());
                strs[i] = strs[i].CompareTo(reverse)>=0 ? strs[i] : reverse;
            }

            string ans = "";
            for (int i = 0; i < strs.Length; i++)
            {
                string left = i == 0 ? "" : string.Join("", strs.Take(i - 1));
                string right = i == strs.Length-1 ? "" : string.Join("", strs.Skip(i+1));
                var s = strs[i];
                var rs = new string(strs[i].Reverse().ToArray());
                for (int j = 0; j <= strs.Length; j++)
                {
                    var ns = s.Substring(0, j)+right + left+s.Substring(j, s.Length-j);
                    ans = ns.CompareTo(ans) >= 0 ? ns : ans;

                    var nrs = rs.Substring(0, j) + right + left + rs.Substring(j, rs.Length - j);
                    ans = nrs.CompareTo(ans) >= 0 ? ns : ans;
                }
            }

            return ans;
        }
    }
}
