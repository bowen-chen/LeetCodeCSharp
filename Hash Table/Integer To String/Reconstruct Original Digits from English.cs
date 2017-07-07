/*
423. Reconstruct Original Digits from English
easy
Given a non-empty string containing an out-of-order English representation of digits 0-9, output the digits in ascending order.

Note:
Input contains only lowercase English letters.
Input is guaranteed to be valid and can be transformed to its original digits. That means invalid inputs such as "abc" or "zerone" are not permitted.
Input length is less than 50,000.
Example 1:
Input: "owoztneoer"

Output: "012"
Example 2:
Input: "fviefuro"

Output: "45"
*/

using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string OriginalDigits(string s)
        {
            StringBuilder res = new StringBuilder();
            var counts = new int[26];
            var nums = new int[10];
            foreach (char c in s)
            {
                counts[c - 'a']++;
            }

            nums[0] = counts['z' - 'a'];
            nums[2] = counts['w' - 'a'];
            nums[4] = counts['u' - 'a'];
            nums[6] = counts['x' - 'a'];
            nums[8] = counts['g' - 'a'];
            nums[1] = counts['o' - 'a'] - nums[0] - nums[2] - nums[4];
            nums[3] = counts['h' - 'a'] - nums[8];
            nums[5] = counts['f' - 'a'] - nums[4];
            nums[7] = counts['s' - 'a'] - nums[6];
            nums[9] = counts['i' - 'a'] - nums[6] - nums[8] - nums[5];
            for (int i = 0; i < nums.Length; ++i)
            {
                for (int j = 0; j < nums[i]; ++j)
                {
                    res.Append((char)(i + '0'));
                }
            }
            return res.ToString();
        }
    }
}
