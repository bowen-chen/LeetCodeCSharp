/*
Your task is to calculate a^b mod 1337 where a is a positive integer and b is an extremely large positive integer given in the form of an array.

Example1:

a = 2
b = [3]

Result: 8
Example2:

a = 2
b = [1,0]

Result: 1024
*/

namespace Demo
{
    public partial class Solution
    {
        // (a^b)%c = ((a%c)^b) %c
        // (a*b)%c = ((a%c)*(b%c))%c
        public int SuperPow(int a, int[] b)
        {
            int res = 1;
            foreach (int i in b)
            {
                res = (SuperPow(res, 10)%1337)*(SuperPow(a%1337, i)%1337)%1337;
            }
            return res;
        }

        private int SuperPow(int x, int n)
        {
            if (n == 0) return 1;
            if (n == 1) return x;
            return (SuperPow(x*x%1337, n/2)%1337)*(SuperPow(x, n%2)%1337)%1337;
        }
    }
}
