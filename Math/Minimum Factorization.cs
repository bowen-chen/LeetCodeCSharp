/*
625	Minimum Factorization
Given a positive integer a, find the smallest positive integer b whose multiplication of each digit equals to a.

If there is no answer or the answer is not fit in 32-bit signed integer, then return 0.

Example 1
Input:

48 
Output:
68
 

Example 2
Input:

15
Output:
35
*/

namespace Demo
{
    public partial class Solution
    {
        public int smallestFactorization(int a)
        {
            if (a < 10)
            {
                return a;
            }

            long res = 0, cnt = 1;
            for (int i = 9; i >= 2; --i)
            {
                while (a % i == 0)
                {
                    res += cnt * i;
                    if (res > int.MaxValue)
                    {
                        return 0;
                    }

                    a /= i;
                    cnt *= 10;
                }
            }

            return (a == 1) ?(int)res : 0;
        }
    };
}
