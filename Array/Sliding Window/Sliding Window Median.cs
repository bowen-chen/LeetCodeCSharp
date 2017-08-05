/*
480. Sliding Window Median
Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value. So the median is the mean of the two middle value.

Examples: 
[2,3,4] , the median is 3

[2,3], the median is (2 + 3) / 2 = 2.5

Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position. Your job is to output the median array for each window in the original array.

For example,
Given nums = [1,3,-1,-3,5,3,6,7], and k = 3.

Window position                Median
---------------               -----
[1  3  -1] -3  5  3  6  7       1
 1 [3  -1  -3] 5  3  6  7       -1
 1  3 [-1  -3  5] 3  6  7       -1
 1  3  -1 [-3  5  3] 6  7       3
 1  3  -1  -3 [5  3  6] 7       5
 1  3  -1  -3  5 [3  6  7]      6
Therefore, return the median sliding window as [1,-1,-1,3,5,6].

Note: 
You may assume k is always valid, ie: 1 ≤ k ≤ input array's size for non-empty array.
*/
using System.Collections.Generic;
using Demo.Common;

namespace Demo
{
    public partial class Solution
    {
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            var medians = new List<double>();
            var removed = new Dictionary<int, int>();
            var big = new PriorityQueue<int>(nums.Length, Comparer<int>.Create((a, b) => b.CompareTo(a)));
            var small = new PriorityQueue<int>(nums.Length);
            
            for (int i = 0; i < k; i++)
            {
                small.Push(nums[i]);
            }

            // small contains n/2 or n/2 +1, big contains n/2
            for (int count = k/2; count > 0; --count)
            {
                big.Push(small.Pop());
            }

            medians.Add(k%2 == 1 ? small.Top() : ((double) small.Top() + big.Top())/2);

            for (int i=k; i < nums.Length; i++)
            {
                int m = nums[i - k];
                int n = nums[i];
                int balance = 0;

                // What happens to the number m that is moving out of the window
                if (m <= small.Top())
                {
                    --balance;
                }
                else
                {
                    ++balance;
                }


                if (removed.ContainsKey(m))
                {
                    removed[m]++;
                }
                else
                {
                    removed[m] = 1;
                }

                // Remove numbers that should be discarded at the top of the two heaps
                while (small.Count > 0 && removed.ContainsKey(small.Top()))
                {
                    if (--removed[small.Top()] == 0)
                    {
                        removed.Remove(small.Top());
                    }

                    small.Pop();
                }

                while (big.Count > 0 && removed.ContainsKey(big.Top()))
                {
                    if (--removed[big.Top()] == 0)
                    {
                        removed.Remove(big.Top());
                    }

                    big.Pop();
                }

                // Insert the new number n that enters the window, after balanced
                if (small.Count != 0 && n <= small.Top())
                {
                    ++balance;
                    small.Push(n);
                }
                else
                {
                    --balance;
                    big.Push(n);
                }

                // Rebalance the bottom and top heaps
                if (balance < 0)
                {
                    small.Push(big.Pop());
                }
                else if (balance > 0)
                {
                    big.Push(small.Pop());
                }

                if (balance != 0)
                {
                    // Remove numbers that should be discarded at the top of the two heaps, after balanced
                    while (small.Count > 0 && removed.ContainsKey(small.Top()))
                    {
                        if (--removed[small.Top()] == 0)
                        {
                            removed.Remove(small.Top());
                        }

                        small.Pop();
                    }

                    while (big.Count > 0 && removed.ContainsKey(big.Top()))
                    {
                        if (--removed[big.Top()] == 0)
                        {
                            removed.Remove(big.Top());
                        }

                        big.Pop();
                    }
                }

                medians.Add(k%2 == 1 ? small.Top() : ((double) small.Top() + big.Top())/2);
            }

            return medians.ToArray();
        }
    }
}
