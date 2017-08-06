/*
600. Non-negative Integers without Consecutive Ones
hard
Given a positive integer n, find the number of non-negative integers less than or equal to n, whose binary representations do NOT contain consecutive ones.

Example 1:
Input: 5
Output: 5
Explanation: 
Here are the non-negative integers <= 5 with their corresponding binary representations:
0 : 0
1 : 1
2 : 10
3 : 11
4 : 100
5 : 101
Among them, only integer 3 disobeys the rule (two consecutive ones) and the other 5 satisfy the rule. 
Note: 1 <= n <= 109
*/

namespace Demo
{
    public partial class Solution
    {
        public int FindIntegers(int num)
        {
            // the number of integer ending with zero
            var zero = new int[32];
            
            // the number of integer ending with one
            var one = new int[32];

            // the number of integer
            var m = new int[32];
            zero[0] = 1;
            one[0] = 1;
            m[0] = 2;
            for (int i = 1; i < 32; ++i)
            {
                zero[i] = zero[i - 1] + one[i - 1]; // =m[i-1]
                one[i] = zero[i - 1]; // =m[i-2]
                m[i] = zero[i] + one[i]; // = m[i-1] + m[i-2]
            }

            int pre = 0;
            int res = 0;

            // 10101100
            // 0xxxxxxx
            // 100xxxxx
            // 10101xxx
            // 101011xx
            // check each bit
            for(int k =31; k>=0;k--)
            {
                if ((num & (1 << k)) != 0)
                {
                    // make k as 0
                    res += m[k-1];

                    // mark k as 1
                    if (pre == 1)
                    {
                        return res;
                    }

                    pre = 1;
                }
                else
                {
                    pre = 0;
                }
            }

            // there is no two 1 in the num add itself
            return res + 1;
        }

        public int FindIntegers2(int num)
        {
            var m = new int[32];
            m[0] = 1;
            m[1] = 2;
            for (int i = 2; i < 32; ++i)
            {
                m[i] = m[i-2] + m[i-1];
            }

            int pre = 0;
            int res = 0;
            for (int k = 31; k >= 0; k--)
            {
                if ((num & (1 << k)) != 0)
                {
                    // make k as 0
                    res += m[k];

                    // mark k as 1
                    if (pre == 1)
                    {
                        return res;
                    }

                    pre = 1;
                }
                else
                {
                    pre = 0;
                }
            }

            // there is no two 1 in the num as it self
            return res + 1;
        }
    }
}
