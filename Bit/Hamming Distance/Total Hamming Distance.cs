/*
477. Total Hamming Distance
*
The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

Now your job is to find the total Hamming distance between all pairs of the given numbers.

Example:
Input: 4, 14, 2

Output: 6

Explanation: In binary representation, the 4 is 0100, 14 is 1110, and 2 is 0010 (just
showing the four bits relevant in this case). So the answer will be:
HammingDistance(4, 14) + HammingDistance(4, 2) + HammingDistance(14, 2) = 2 + 2 + 2 = 6.
Note:
Elements of the given array are in the range of 0 to 10^9
Length of the array will not exceed 10^4.
*/

namespace Demo
{
    public partial class Solution
    {
        public int TotalHammingDistance(int[] nums)
        {
            int res = 0, n = nums.Length;
            for (int i = 0; i < 32; ++i)
            {
                int ones = 0;
                int mask = 1 << i;
                foreach (int num in nums)
                {
                    if ((num & mask) != 0)
                    {
                        ++ones;
                    }
                }

                // numbers has 1 X numbers don't have 1
                res += ones*(n - ones);
            }

            return res;
        }
    }
}
