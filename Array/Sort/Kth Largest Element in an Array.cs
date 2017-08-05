/*
215	Kth Largest Element in an Array
medium, quick sort
Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.

For example,
Given [3,2,1,5,6,4] and k = 2, return 5.

Note: 
You may assume k is always valid, 1 ≤ k ≤ array's length.
*/

namespace Demo
{
    public partial class Solution
    {
        public void Test_FindKthLargest()
        {
            FindKthLargest(new[] {-1, 2, 0}, 1);
            FindKthLargest(new[] {3, 3, 3}, 1);
        }

        public int FindKthLargest(int[] nums, int k)
        {
            k = nums.Length - k;
            int lo = 0;
            int hi = nums.Length - 1;
            while (lo < hi)
            {
                int j = Partition(nums, lo, hi);
                if (j < k)
                {
                    lo = j + 1;
                }
                else if (j > k)
                {
                    hi = j - 1;
                }
                else
                {
                    break;
                }
            }

            return nums[k];
        }

        private int Partition(int[] a, int lo, int hi)
        {
            int p = a[lo];
            while (lo < hi)
            {
                while (lo < hi && a[hi] >= p)
                {
                    hi--;
                }

                a[lo] = a[hi];

                while (lo < hi && a[lo] <= p)
                {
                    lo++;
                }

                a[hi] = a[lo];
            }

            a[lo] = p;
            return lo;
        }
    }
}
