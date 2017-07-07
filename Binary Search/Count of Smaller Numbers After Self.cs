/*
315. Count of Smaller Numbers After Self
hard
You are given an integer array nums and you have to return a new counts array. The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].

Example:

Given nums = [5, 2, 6, 1]

To the right of 5 there are 2 smaller elements (2 and 1).
To the right of 2 there is only 1 smaller element (1).
To the right of 6 there is 1 smaller element (1).
To the right of 1 there is 0 smaller element.
Return the array [2, 1, 1, 0].
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void Test_CountSmaller()
        {
            CountSmaller(new [] {5, 2, 6, 1}).Print();
        }

        public IList<int> CountSmaller(int[] nums)
        {
            int[] ret = new int[nums.Length];
            IList<int> sortedList = new List<int>();

            // insert sort
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int count;
                if (sortedList.Count == 0)
                {
                    count = 0;
                }
                else
                {
                    int low = 0;
                    int high = sortedList.Count - 1;
                    if (sortedList[high] < nums[i])
                    {
                        count = sortedList.Count;
                    }
                    else if (sortedList[low] >= nums[i])
                    {
                        count = 0;
                    }
                    else
                    {
                        // find the first sortedlist[low] does not meet sortedList[low] < nums[i]
                        while (low <= high)
                        {
                            int mid = low + (high - low)/2;
                            if (sortedList[mid] < nums[i])
                            {
                                low = mid + 1;
                            }
                            else
                            {
                                high = mid - 1;
                            }
                        }
                        count = low;
                    }
                }
                ret[i] = count;
                sortedList.Insert(count, nums[i]);
            }
            return ret;
        }
    }
}
