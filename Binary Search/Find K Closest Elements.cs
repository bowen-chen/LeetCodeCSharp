/*
658. Find K Closest Elements
Given a sorted array, two integers k and x, find the k closest elements to x in the array. The result should also be sorted in ascending order. If there is a tie, the smaller elements are always preferred.

Example 1:
Input: [1,2,3,4,5], k=4, x=3
Output: [1,2,3,4]
Example 2:
Input: [1,2,3,4,5], k=4, x=-1
Output: [1,2,3,4]
Note:
The value k is positive and will always be smaller than the length of the sorted array.
Length of the given array is positive and will not exceed 10^4
Absolute value of elements in the array and x will not exceed 10^4
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> FindClosestElements(IList<int> arr, int k, int x)
        {
            int i = FindFirstNumberNotLessThanX(arr, x);
            int j = i - 1;
            var ret = new List<int>();
            for (; k > 0 && (i <= arr.Count-1 || j >= 0); k--)
            {
                int idis = i <= arr.Count-1 ? arr[i] - x : int.MaxValue;
                int jdis = j >= 0 ? x - arr[j] : int.MaxValue;
                if (idis < jdis)
                {
                    ret.Add(arr[i++]);
                }
                else
                {
                    ret.Insert(0, arr[j--]);
                }
            }

            return ret;
        }

        private int FindFirstNumberNotLessThanX(IList<int> arr, int x)
        {
            int low = 0;
            int high = arr.Count - 1;
            while (low <= high)
            {
                int mid = low + (high - low)/2;
                if (arr[mid] < x)
                {
                    low += 1;
                }
                else
                {
                    high -= 1;
                }
            }

            return low;
        }
    }
}
