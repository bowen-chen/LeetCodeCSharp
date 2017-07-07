/*
466 Count The Repetitions
Define S = [s,n] as the string S which consists of n connected strings s. For example, ["abc", 3] ="abcabcabc".

On the other hand, we define that string s1 can be obtained from string s2 if we can remove some characters from s2 such that it becomes s1. For example, “abc” can be obtained from “abdbec” based on our definition, but it can not be obtained from “acbbe”.

You are given two non-empty strings s1 and s2 (each at most 100 characters long) and two integers 0 ≤ n1 ≤ 106 and 1 ≤ n2 ≤ 106. Now consider the strings S1 and S2, where S1=[s1,n1] and S2=[s2,n2]. Find the maximum integer M such that [S2,M] can be obtained from S1.

Example:

Input:
s1="acb", n1=4
s2="ab", n2=2

Return:
2
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
        {
            int l1 = s1.Length;
            int l2 = s2.Length;
            var m = new List<int>();
            int i = 0;
            int jj = 0;
            while (i < n1)
            {
                int[] m2 = new int[l1];
                for (int ii = 0; ii < l1; ii++)
                {
                    if (s1[ii] == s2[jj%l2])
                    {
                        jj++;
                    }

                    m2[ii] = jj;
                }

                if (m.Count != 0)
                {
                    bool ignore = false;
                    for (int ii = 0; ii < l1; ii++)
                    {
                        if ((m2[ii]%l2) <= m[ii])
                        {
                            ignore = true;
                            break;
                        }
                    }

                    if (ignore)
                    {
                        break;
                    }
                }

                m.AddRange(m2);
                i++;
            }

            Console.WriteLine(string.Join(" , ", m));
            return 0;
            //if (i >= n1*l1)
            //{
            //    return j%(l2*n2);
            //}

            //return ((n1%(i%l1))*(j%l2))%n2;
        }
    }
}
