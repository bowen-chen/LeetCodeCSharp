/*
275. H-Index II
easy, binary search
H-Index II

Follow up for H-Index: What if the citations array is sorted in ascending order? Could you optimize your algorithm?

citations[h] = N - h

1, 2, 3, 10, 11 = 3
1, 2, 10, 10, 10, 11 = 4

Hint:

Expected runtime complexity is in O(log n) and the input is sorted.
*/

namespace Demo
{
    public partial class Solution
    {
        public int HIndex2(int[] citations)
        {
            if (citations == null)
            {
                return 0;
            }

            int low = 0;
            int high = citations.Length - 1;
            // find the first low does not meet citations[mid] < citations.Length - mid
            while (low <= high)
            {
                var mid = low + (high - low)/2;
                if (citations[mid] < citations.Length - mid)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return citations.Length - low;
        }
    }
}
