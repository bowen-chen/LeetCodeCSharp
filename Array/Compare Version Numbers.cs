/*
165	Compare Version Numbers
easy
Compare two version numbers version1 and version2.
If version1 > version2 return 1, if version1 < version2 return -1, otherwise return 0.

You may assume that the version strings are non-empty and contain only digits and the . character.
The . character does not represent a decimal point and is used to separate number sequences.
For instance, 2.5 is not "two and a half" or "half way to version three", it is the fifth second-level revision of the second first-level revision.

Here is an example of version numbers ordering:

0.1 < 1.1 < 1.2 < 13.37
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_CompareVersion()
        {
            CompareVersion("0", "1");
            CompareVersion("01", "1");
        }

        public int CompareVersion(string version1, string version2)
        {
            string[] levels1 = version1.Split('.');
            string[] levels2 = version2.Split('.');

            int length = Math.Max(levels1.Length, levels2.Length);
            for (int i = 0; i < length; i++)
            {
                int v1 = i < levels1.Length ? int.Parse(levels1[i]) : 0;
                int v2 = i < levels2.Length ? int.Parse(levels2[i]) : 0;
                int compare = v1.CompareTo(v2);
                if (compare != 0)
                {
                    return compare;
                }
            }

            return 0;
        }
    }
}
