/*
190	Reverse Bits
easy, bit
Reverse bits of a given 32 bits unsigned integer.

For example, given input 43261596 (represented in binary as 00000010100101000001111010011100), return 964176192 (represented in binary as 00111001011110000010100101000000).

Follow up:
If this function is called many times, how would you optimize it?
*/

namespace Demo
{
    public partial class Solution
    {
        public uint ReverseBits(uint n)
        {
            n = (n >> 16) | (n << 16);
            // 11111111000000001111111100000000
            n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
            // 11110000111100001111000011110000
            n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
            // 11001100110011001100110011001100
            n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
            // 101010101010101010101010101010101
            n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
            return n;
        }
    }
}
