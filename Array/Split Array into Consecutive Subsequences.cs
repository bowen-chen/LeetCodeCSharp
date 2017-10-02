/*
659. Split Array into Consecutive Subsequences
You are given an integer array sorted in ascending order (may contain duplicates), you need to split them into several subsequences, where each subsequences consist of at least 3 consecutive integers. Return whether you can make such a split.

Example 1:
Input: [1,2,3,3,4,5]
Output: True
Explanation:
You can split them into two consecutive subsequences : 
1, 2, 3
3, 4, 5
Example 2:
Input: [1,2,3,3,4,4,5,5]
Output: True
Explanation:
You can split them into two consecutive subsequences : 
1, 2, 3, 4, 5
3, 4, 5
Example 3:
Input: [1,2,3,4,4,5]
Output: False
Note:
The length of the input is in range of [1, 10000]

*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool IsPossible(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            Dictionary<int, int> tail = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!freq.ContainsKey(num))
                {
                    freq[num] = 0;
                }

                ++freq[num];
            }
            foreach (int num in nums)
            {
                if (freq[num] == 0) /*already used*/
                {
                    continue;
                }
                else if (tail.ContainsKey(num) && tail[num] > 0) /*add it to an existing seq*/
                {
                    --tail[num];
                    ++tail[num + 1];
                }
                else if (freq.ContainsKey(num + 1) && freq[num + 1] > 0 && freq.ContainsKey(num + 2) && freq[num + 2] > 0) /*start a new seq*/
                {
                    --freq[num + 1];
                    --freq[num + 2];
                    ++tail[num + 3];
                }
                else
                {
                    return false;
                }
                --freq[num];
            }
            return true;
        }

        public bool IsPossible2(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                var q = new Queue<int>();
                int preCount = 0;
                int last = nums[i] - 1;
                while (i <= nums.Length)
                {
                    int n = (i == nums.Length || nums[i] != last + 1) ? last + 1 : nums[i];
                    int count = (i == nums.Length || nums[i] != last + 1) ? 0 : 1;
                    while (i + 1 < nums.Length && n == nums[i + 1])
                    {
                        i++;
                        count++;
                    }

                    for (int j = count; j > preCount; j--)
                    {
                        q.Enqueue(n);
                    }

                    for (int j = count; j < preCount; j++)
                    {
                        if (last - q.Dequeue() < 2)
                        {
                            return false;
                        }
                    }

                    if (count != 0)
                    {
                        last = n;
                        preCount = count;
                        i++;
                    }
                    else if (q.Count != 0)
                    {
                        return false;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return true;
        }
    }
}
