/*
191	Number of 1 Bits
easy, bit, *
Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).

For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3.
*/

namespace Demo
{
    public partial class Solution
    {
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n = n & (n - 1);
            }

            return count;
        }

        public int HammingWeight2(uint n)
        {
            //0101
            n = (n & 0x55555555) + (n >> 1 & 0x55555555); // put count of each  2 bits into those  2 bits 
            //0011
            n = (n & 0x33333333) + (n >> 2 & 0x33333333); // put count of each  4 bits into those  4 bits
            //00001111 
            n = (n & 0x0F0F0F0F) + (n >> 4 & 0x0F0F0F0F); // put count of each  8 bits into those  8 bits
            //0000000011111111 
            n = (n & 0x00FF00FF) + (n >> 8 & 0x00FF00FF); // put count of each 16 bits into those 16 bits
            //00000000000000001111111111111111 
            n = (n & 0x0000FFFF) + (n >> 16 & 0x0000FFFF); // put count of each 32 bits into those 32 bits 
            return (int)n;
        }
    }
}
