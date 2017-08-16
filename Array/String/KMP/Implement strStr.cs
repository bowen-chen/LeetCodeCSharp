/*
28	Implement strStr()
revisit
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

        public int Kmp(string s, string p)
        {
            int[] next = new int[p.Length];
            next[0] = -1;
            int i = 0;
            int j = -1;
            while (i < p.Length - 1)
            {
                // p[j] is prefix，p[i] is post fix  
                // if j == -1, means p[0] != p[i], then next[i+1] = 0, i++
                // if p[j] = p[i], then next[i+1] = j+1; i++, j++
                if (j == -1 || p[j] == p[i])
                {
                    next[++i] = ++j;
                }
                else
                {
                    j = next[j];
                }
            }

            i = 0;
            j = 0;
            while (i < s.Length && j < p.Length)
            {
                // if j = -1, means s[i] != p[0], then i++, j=0
                // if S[i] == P[j], then match the next one, i++, j++ 
                if (j == -1 || s[i] == p[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    // if not match, jump to j, since s[...i-1] match pre[0...next[j]-1]
                    j = next[j];
                }
            }

            if (j == p.Length)
            {
                return i - j;
            }

            return -1;
        }
    }
}
