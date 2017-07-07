/*
28	Implement strStr()
easy
Implement strStr().

Returns the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
*/

namespace Demo
{
    public partial class Solution
    {
        // kmp???
        public int StrStr(string haystack, string needle)
        {
            for (int i = 0; i + needle.Length - 1 < haystack.Length; i++)
            {
                // bool match = !needle.Where((t, j) => haystack[i + j] != t).Any();
                int j = 0;
                for (;j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        break;
                    }
                }
                if (j== needle.Length)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
