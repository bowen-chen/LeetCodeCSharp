/*
321	Create Maximum Number
hard, revisit
Given two arrays of length m and n with digits 0-9 representing two numbers. Create the maximum number of length k <= m + n from digits of the two. The relative order of the digits from the same array must be preserved. Return an array of the k digits. You should try to optimize your time and space complexity.

Example 1:
nums1 = [3, 4, 6, 5]
nums2 = [9, 1, 2, 5, 8, 3]
k = 5
return [9, 8, 6, 5, 3]

Example 2:
nums1 = [6, 7]
nums2 = [6, 0, 4]
k = 5
return [6, 7, 6, 0, 4]

Example 3:
nums1 = [3, 9]
nums2 = [8, 9]
k = 3
return [9, 8, 9]
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int[] res = null;

            // take i from nums1
            for (int i = Math.Max(0, k - n); i <= Math.Min(k, m); ++i)
            {
                var temp = MergeVector(MaxVector(nums1, i), MaxVector(nums2, k - i));
                if (CompareVector(res, 0, temp, 0)<0)
                {
                    res = temp;
                }
            }
            return res;
        }

        private int CompareVector(int[] nums1, int s1, int[] nums2, int s2)
        {
            if (nums1 == null)
            {
                return -1;
            }

            if (nums2 == null)
            {
                return 1;
            }
            
            // When nums1 is 1,2,3 and nums2 is 1,2,3,0
            // we should choose from nums1
            for (int i= 0;i < nums1.Length + nums2.Length - s1 - s2;i++)
            {
                int a = i + s1 < nums1.Length ? nums1[i + s1] : nums2[i + s1 - nums1.Length + s2];
                int b = i + s2 < nums2.Length ? nums2[i + s2] : nums1[i + s2 - nums2.Length + s1];

                if (a > b)
                {
                    return 1;
                }

                if (a < b)
                {
                    return -1;
                }
            }

            return 0;
        }

        private int[] MaxVector(int[] nums, int k)
        {
            int drop = nums.Length - k;
            var res = new List<int>();
            foreach (int num in nums)
            {
                while (drop !=0 && res.Count != 0 && res[res.Count-1] < num)
                {
                    res.RemoveAt(res.Count-1);
                    --drop;
                }
                res.Add(num);
            }
            while (drop != 0 && res.Count != 0)
            {
                res.RemoveAt(res.Count - 1);
                --drop;
            }
            return res.ToArray();
        }

        int[] MergeVector(int[] nums1, int[] nums2)
        {
            var res = new List<int>();
            int i = 0;
            int j = 0;
            while (i<nums1.Length || j <nums2.Length)
            {
                if (i == nums1.Length)
                {
                    res.Add(nums2[j++]);
                }
                else if(j == nums2.Length)
                {
                    res.Add(nums1[i++]);
                }
                else
                {
                    if (CompareVector(nums1, i, nums2, j)>0)
                    {
                        res.Add(nums1[i++]);
                    }
                    else
                    {
                        res.Add(nums2[j++]);
                    }
                }
            }
            return res.ToArray();
        }
    }
}
