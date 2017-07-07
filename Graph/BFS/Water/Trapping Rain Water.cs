/*
42	Trapping Rain Water
hard
Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

For example, 
Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.

The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped. Thanks Marcos for contributing this image!
*/

namespace Demo
{
    public partial class Solution
    {
        public int Trap(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int res = 0;
            int waterLevel = 0;
            while (left <= right)
            {
                if (height[left] <= height[right])
                {
                    // raise the water level to height[left]
                    waterLevel = height[left];
                    while (left <= right && height[left] <= waterLevel)
                    {
                        res += waterLevel - height[left];
                        left++;
                    }
                }
                else
                {
                    // raise the water level to height[right]
                    waterLevel = height[right];
                    while (left <= right && height[right] <= waterLevel)
                    {
                        res += waterLevel - height[right];
                        right--;
                    }
                }
            }
            return res;
        }
    }
}
