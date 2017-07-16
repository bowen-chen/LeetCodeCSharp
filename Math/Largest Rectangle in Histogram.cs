/*
84	Largest Rectangle in Histogram
hard
Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.


Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].


The largest rectangle is shown in the shaded area, which has area = 10 unit.

For example,
Given heights = [2,1,5,6,2,3],
return 10.
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int LargestRectangleArea(int[] height)
        {
            // keep index in stack
            // height[inex] is ascending order
            Stack<int> stack = new Stack<int>();
            int max_area = 0;

            for (int i = 0; i <= height.Length; ++i)
            {
                int height_bound = (i == height.Length) ? 0 : height[i];
                while (stack.Count != 0)
                {
                    int h = height[stack.Peek()];

                    // height_bound will be the max height
                    if (h < height_bound)
                    {
                        break;
                    }

                    stack.Pop();

                    // at the end, the area with the height of the minimal element.
                    int leftIndex = stack.Count == 0 ? -1 : stack.Peek();

                    // calc max area at height h
                    max_area = Math.Max(max_area, h * ((i - 1) - leftIndex));
                }

                stack.Push(i);
            }

            return max_area;
        }
    }
}
