/*
4	Median of Two Sorted Arrays
hard
Median of Two Sorted Arrays
There are two sorted arrays nums1 and nums2 of size m and n respectively. Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length, n = nums2.Length;
            if (m < n)
            {
                // we will cut nums2, so nums2 should be shorter array.
                return FindMedianSortedArrays(nums2, nums1);
            }

            if (n == 0)
            {
                return (nums1[(m - 1) / 2] + nums1[m / 2]) / 2.0;
            }

            // nums2 is shorter, we always cut the shorter one
            // for an array with length n, there are 2*n+1 place to cut
            // /a/b/c/d/
            // for even array length, cut in the middle a,b/c,d, L=b R=c L+R/2
            // for odd array length, cut in the middle number, a,b,(c/c),d,e, L=c r=c L+R/2
            // l = cut-1 /2
            // r = cut / 2
            // we try find where to cut in nums2
            int left = 0, right = 2 * n;
            while (left <= right)
            {
                // we cut in the mid of nums2
                int mid2 = (left + right) / 2;

                // calc the cut in the nums1, nums2 suppose to cut at n, the diff should be cut in nums1
                int mid1 = m + (mid2 - n);

                double L1 = mid1 == 0 ? double.MinValue : nums1[(mid1 - 1) / 2];
                double R1 = mid1 == m * 2 ? double.MaxValue : nums1[mid1 / 2];
                double L2 = mid2 == 0 ? double.MinValue : nums2[(mid2 - 1) / 2];
                double R2 = mid2 == n * 2 ? double.MaxValue : nums2[mid2 / 2];

                // we expected l1<=r2 and l2<=r1
                if (L1 > R2)
                {
                    left = mid2 + 1;
                }
                else if (L2 > R1)
                {
                    right = mid2 - 1;
                }
                else
                {
                    return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2;
                }
            }

            return -1;
        }

        private int Getkth(int[] s, int s1, int l1, int[] l, int s2, int l2, int k)
        {
            // let l1 <= l2
            if (l1 > l2)
            {
                return Getkth(l, s2, l2, s, s1, l1, k);
            }

            if (l1 == 0)
            {
                return l[k - 1 + s2];
            }

            if (k == 1)
            {
                return Math.Min(s[s1], l[s2]);
            }

            // l1 < l2
            int i = Math.Min(l1, k/2), j = Math.Min(l2, k/2);
            if (s[s1 + i - 1] > l[s2 + j - 1])
            {
                return Getkth(s, s1, l1, l, s2 + j, l2 - j, k - j);
            }
            else
            {
                return Getkth(s, s1 + i, l1 - i, l, s2, l2, k - i);
            }
        }

        public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int l = (m + n + 1) >> 1;
            int r = (m + n + 2) >> 1;
            if (l != r)
            {
                return (Getkth(nums1, 0, m, nums2, 0, n, l) + Getkth(nums1, 0, m, nums2, 0, n, r))/2.0;
            }
            return Getkth(nums1, 0, m, nums2, 0, n, l);
        }
    }
}
