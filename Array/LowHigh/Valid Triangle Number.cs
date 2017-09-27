/*
611. Valid Triangle Number
*
Given an array consists of non-negative integers, your task is to count the number of triplets chosen from the array that can make triangles if we take them as side lengths of a triangle.

Example 1:
Input: [2,2,3,4]
Output: 3
Explanation:
Valid combinations are: 
2,3,4 (using the first 2)
2,3,4 (using the second 2)
2,2,3
Note:
The length of the given array won't exceed 1000.
The integers in the given array are in the range of [0, 1000].
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int TriangleNumber(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int count = 0;

            // the sum of two short side should be bigger than the long side
            for (int i = n - 1; i >= 2; i--)
            {
                int l = 0;
                int r = i - 1;
                while (l < r)
                {
                    if (nums[l] + nums[r] > nums[i])
                    {
                        // choose [l->r-1] and r
                        count += r - l;
                        r--;
                    }
                    else
                    {
                        l++;
                    }
                }
            }

            return count;
        }
    }
}
