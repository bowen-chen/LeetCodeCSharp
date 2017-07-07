/*
137	Single Number II	
hard
Given an array of integers, every element appears three times except for one. Find that single one.

Note:
Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
*/

namespace Demo
{
    public partial class Solution
    {
        public int SingleNumber2(int[] nums)
        {
            //we need to implement a tree-time counter(base 3) that if a bit appears three time ,it will be zero.
            //#curent  income  ouput
            //# ab      c         ab
            //# 00      1         01
            //# 00      0         00
            //# 01      1         10
            //# 01      0         01
            //# 10      1         00
            //# 10      0         10
            // a=~abc+a~b~c;
            // b=~a~bc+~ab~c;
            int a = 0;
            int b = 0;
            foreach (int c in nums)
            {
                int nexta = (~a & b & c) | (a & ~b & ~c);
                int nextb = (~a & ~b & c) | (~a & b & ~c);
                a = nexta;
                b = nextb;
            }
            //we need find the number that is 01 => 1, 10=> 1.
            return a | b;
        }
    }
}
