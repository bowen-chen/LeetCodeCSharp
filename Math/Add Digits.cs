/*
easy, math
Add Digits

Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.

For example:

Given num = 38, the process is like: 3 + 8 = 11, 1 + 1 = 2. Since 2 has only one digit, return it.

Follow up:
Could you do it without any loop/recursion in O(1) runtime?

Hint:

A naive implementation of the above process is trivial. Could you come up with other methods?
What are all the possible results?
How do they occur, periodically or randomly?
You may find this Wikipedia article useful.
*/

namespace Demo
{
    public partial class Solution
    {
        public int AddDigits(int num)
        {
            while (num >= 10)
            {
                int n = 0;
                while (num > 0)
                {
                    n += num % 10;
                    num /= 10;
                }

                num = n;
            }

            return num;
        }

        //For base b (decimal case b = 10), the digit root of an integer is:
        //dr(n) = 0 if n == 0
        //dr(n) = (b-1) if n != 0 and n % (b-1) == 0
        //dr(n) = n %(b-1) if n % (b-1) != 0
        public int AddDigits_2(int num)
        {
            if (num == 0)
            {
                return 0;
            }

            var mod = num % 9;
            return mod == 0 ? 9 : mod;
        }
    }
}
