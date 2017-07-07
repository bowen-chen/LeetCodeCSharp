/*
263	Ugly Number
easy, math
Ugly Number

Write a program to check whether a given number is an ugly number.

Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. For example, 6, 8 are ugly while 14 is not ugly since it includes another prime factor 7.

Note that 1 is typically treated as an ugly number.
*/

namespace Demo
{
    public partial class Solution
    {
        public void Test_IsUgly()
        {
            IsUgly(1);
        }

        public bool IsUgly(int num)
        {
            if (num <= 0)
            {
                return false;
            }

            foreach (var i in new[] {2, 3, 5})
            {
                while (num%i == 0)
                {
                    num = num/i;
                }
            }

            return num == 1;
        }
    }
}
