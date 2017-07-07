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
            if ((n == 0) || (k <= 0))
            {
                return;
            }

            int cntRotated = 0;
            int start = 0;
            int curr = 0;
            // Keep rotating the elements until we have rotated n 
            // different elements.
            while (cntRotated < n)
            {
                do
                {
                    int tmp = nums[(curr + k)%n];
                    nums[(curr + k)%n] = nums[curr];
                    nums[curr] = tmp;
                    curr = (curr + k)%n;
                    cntRotated++;
                } while (curr != start);
                // Stop rotating the elements when we finish one cycle, 
                // i.e., we return to start.

                // Move to next element to start a new cycle.
                start++;
                curr = start;
            }
        }

        public void Rotate2(int[] nums, int k)
        {
            int n = nums.Length;
            if (n == 0 || k <= 0 || k%n == 0)
            {
                return;
            }

            int start = 0;
            int i = 0;
            int cur = nums[i];
            int cnt = 0;
            while (cnt++ < n)
            {
                i = (i + k)%n;
                int t = nums[i];
                nums[i] = cur;
                if (i == start)
                {
                    ++start;
                    ++i;
                    cur = nums[i];
                }
                else
                {
                    cur = t;
                }
            }
        }
    }
}