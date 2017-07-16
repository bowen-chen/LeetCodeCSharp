/*
89	Gray Code
medium, math
The gray code is a binary numeral system where two successive values differ in only one bit.

Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. A gray code sequence must begin with 0.

For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:

00 - 0
01 - 1
11 - 3
10 - 2
Note:
For a given n, a gray code sequence is not uniquely defined.

For example, [0,2,3,1] is also a valid gray code sequence according to the above definition.

For now, the judge is able to judge based on one instance of gray code sequence. Sorry about that.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> GrayCode(int n)
        {
            if (n == 0)
            {
                return new List<int> {0};
            }

            var ret = GrayCode(n - 1);
            int nbit = 1 << n-1;
            for (int i = ret.Count - 1; i >= 0; i--)
            {
                ret.Add(ret[i] + nbit);
            }

            return ret;
        }
    }
}
