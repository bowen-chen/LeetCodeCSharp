/*
13	Roman to Integer
medium, math
Roman to Integer

Given a roman numeral, convert it to an integer.

Input is guaranteed to be within the range from 1 to 3999.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int RomanToInt(string s)
        {
            var dic = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            int sum = dic[s[s.Length - 1]];
            for (int i = s.Length - 2; i >= 0; --i)
            {
                if (dic[s[i]] < dic[s[i + 1]])
                {
                    sum -= dic[s[i]];
                }
                else
                {
                    sum += dic[s[i]];
                }
            }

            return sum;
        }

        public int RomanToInt2(string s)
        {
            int ret = 0;
            char c, c1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (i == s.Length - 1)
                {
                    c = s[i];
                    if (c == 'I')
                    {
                        ret += 1;
                    }
                    else if (c == 'V')
                    {
                        ret += 5;
                    }
                    else if (c == 'X')
                    {
                        ret += 10;
                    }
                    else if (c == 'L')
                    {
                        ret += 50;
                    }
                    else if (c == 'C')
                    {
                        ret += 100;
                    }
                    else if (c == 'D')
                    {
                        ret += 500;
                    }
                    else if (c == 'M')
                    {
                        ret += 1000;
                    }
                    continue;
                }

                c = s[i];
                c1 = s[i + 1];
                if (c == 'I')
                {
                    if (c1 == 'V' || c1 == 'X')
                    {
                        ret -= 1;
                    }
                    else
                    {
                        ret += 1;
                    }
                }
                else if (c == 'V')
                {
                    ret += 5;
                }
                else if (c == 'X')
                {
                    if (c1 == 'L' || c1 == 'C')
                    {
                        ret -= 10;
                    }
                    else
                    {
                        ret += 10;
                    }
                }
                else if (c == 'L')
                {

                    ret += 50;

                }
                else if (c == 'C')
                {
                    if (c1 == 'D' || c1 == 'M')
                    {
                        ret -= 100;
                    }
                    else
                    {
                        ret += 100;
                    }
                }
                else if (c == 'D')
                {

                    ret += 500;

                }
                else if (c == 'M')
                {
                    ret += 1000;
                }
            }

            return ret;
        }
    }
}
