/*
324	Wiggle Sort II
hard
Given an unsorted array nums, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]....

Example:
(1) Given nums = [1, 5, 1, 1, 6, 4], one possible answer is [1, 4, 1, 5, 1, 6]. 
(2) Given nums = [1, 3, 2, 2, 3, 1], one possible answer is [2, 3, 1, 3, 1, 2].

Note:
You may assume all input has valid answer.

Follow Up:
Can you do it in O(n) time and/or in-place with O(1) extra space?
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_WiggleSort()
        {
            WiggleSort(new [] {1, 5, 1, 1, 6, 4});
            WiggleSort(new[] {1});
        }

        /// <summary>
        /// Original Indices: (12)   0  1  2  3  4  5  6  7  8  9 10 11
        /// Mapped Indices:    13    1  3  5  7  9 11  0  2  4  6  8 10
        /// Original Indices: (11)   0  1  2  3  4  5  6  7  8  9 10
        /// Mapped Indices:    11    1  3  5  7  9  0  2  4  6  8 10
        /// Original Indices: (6)    0  1  2  3  4  5
        /// Mapped Indices:    7     1  3  5  0  2  4
        /// </summary>
        private int WiggleSortIndex(int idx, int n)
        {
            // (n|1) round up to nearest old
            return (2 * idx + 1) % (n | 1);
        }

        public void WiggleSort(int[] nums)
        {
            if (nums==null||nums.Length ==0)
            {
                return;
            }

            int n = nums.Length;
            int m = n/2 + 1;

            // Step 1: Find the median
            int median = FindKthLargest(nums, m);

            // bigger half, put them into 1 3 5 7 9
            // smaller half, put them into 0 2 4 6 9 10
            // Step 2: Tripartie partition within O(n)-time & O(1)-space.
            int first = 0, mid = 0, last = n - 1;
            while (mid <= last)
            {
                int mappedMid = WiggleSortIndex(mid, n);
                int mappedFirst = WiggleSortIndex(first, n);
                int mappedLast = WiggleSortIndex(last, n);
                if (nums[mappedMid] > median)
                {
                    int tmp = nums[mappedFirst];
                    nums[mappedFirst] = nums[mappedMid];
                    nums[mappedMid] = tmp;
                    first++;
                    mid++;
                }
                else if (nums[mappedMid] < median)
                {
                    int tmp = nums[mappedLast];
                    nums[mappedLast] = nums[mappedMid];
                    nums[mappedMid] = tmp;
                    last--;
                }
                else
                {
                    mid++;
                }
            }
        }
    }
}
