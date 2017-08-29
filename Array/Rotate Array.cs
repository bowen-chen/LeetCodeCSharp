/*
189	Rotate Array
easy
Rotate an array of n elements to the right by k steps.

For example, with n = 7 and k = 3, the array [1,2,3,4,5,6,7] is rotated to [5,6,7,1,2,3,4].

Note:
Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.

[show hint]

Hint:
Could you do it in-place with O(1) extra space?
Related problem: Reverse Words in a String II
*/

namespace Demo
{
    public partial class Solution
    {
        public void Test_Rotate()
        {
            Rotate(new [] {1}, 1);
        }

        public void Rotate(int[] nums, int k)
        {
            int n = nums.Length;
            if (n == 0 || k <= 0 || k%n == 0)
            {
                return;
            }

            int start = 0;
            int i = 0;
            int pre = nums[i];
            int cnt = 0;
            while (cnt++ < n)
            {
                i = (i + k)%n;
                int t = nums[i];
                nums[i] = pre;
                if (i == start)
                {
                    ++start;
                    ++i;
                    pre = nums[i];
                }
                else
                {
                    pre = t;
                }
            }
        }
    }
}