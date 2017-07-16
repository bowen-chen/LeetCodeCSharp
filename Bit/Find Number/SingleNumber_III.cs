/*
260	Single Number III
medium
Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once.

For example:

Given nums = [1, 2, 1, 3, 2, 5], return [3, 5].

Note:
The order of the result is not important. So in the above example, [5, 3] is also correct.
Your algorithm should run in linear runtime complexity. Could you implement it using only constant space complexity?
*/

namespace Demo
{
    public partial class Solution
    {
        public int[] SingleNumber3(int[] nums)
        {
            int aXorb = 0;  // the result of a xor b;
            foreach (int item in nums)
            {
                aXorb ^= item;
            }

            int lastBit = (aXorb & (aXorb - 1)) ^ aXorb;  // the last bit that a diffs b
            int intA = 0, intB = 0;
            foreach (int item in nums)
            {
                // based on the last bit, group the items into groupA(include a) and groupB
                if ((item & lastBit) == 0)
                {
                    intA = intA ^ item;
                }
                else
                {
                    intB = intB ^ item;
                }
            }

            return new [ ]{ intA, intB};
        }
    }
}
