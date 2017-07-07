/*
231	Power of Two
easy, math
Power of Two

Given an integer, write a function to determine if it is a power of two.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsPowerOfTwo(int n)
        {
            if (n <= 0)
            {
                return false;
            }

            // only one 1 in the bits
            return (n & (n - 1)) == 0;
        }
    }
}
