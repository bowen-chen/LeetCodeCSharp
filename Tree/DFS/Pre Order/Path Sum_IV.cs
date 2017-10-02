/*
666	Path Sum IV
If the depth of a tree is smaller than 5, then this tree can be represented by a list of three-digits integers.

For each integer in this list:

The hundreds digit represents the depth D of this node, 1 <= D <= 4.
The tens digit represents the position P of this node in the level it belongs to, 1 <= P <= 8. The position is the same as that in a full binary tree.
The units digit represents the value V of this node, 0 <= V <= 9.
 

Given a list of ascending three-digits integers representing a binary with the depth smaller than 5. You need to return the sum of all paths from the root towards the leaves.

Example 1:

Input: [113, 215, 221]
Output: 12
Explanation: 
The tree that the list represents is:
    3
   / \
  5   1

The path sum is (3 + 5) + (3 + 1) = 12.
 

Example 2:

Input: [113, 221]
Output: 4
Explanation: 
The tree that the list represents is: 
    3
     \
      1

The path sum is (3 + 1) = 4.

*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int PathSum(int[] nums)
        {
            if (nums == null || nums.Length ==0)
            {
                return 0;
            }

            var m = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                m[num / 10] = num % 10;
            }

            return PathSum(m, nums[0] / 10, 0);
        }

        public int PathSum(Dictionary<int, int> m, int cur, int sum)
        {
            if (!m.ContainsKey(cur))
            {
                return 0;
            }

            int level = cur / 10, pos = cur % 10;
            int left = (level + 1) * 10 + 2 * pos - 1;
            int right = left + 1;
            sum += m[cur];
            if (!m.ContainsKey(left) && !m.ContainsKey(right))
            {
                return sum;
            }

            return PathSum(m, left, sum) + PathSum(m, right, sum);
        }
    }
}
