/*
238	Product of Array Except Self
medium, math
Product of Array Except Self

Given an array of n integers where n > 1, nums, return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

Solve it without division and in O(n).

For example, given [1,2,3,4], return [24,12,8,6].

Follow up:
Could you solve it with constant space complexity? (Note: The output array does not count as extra space for the purpose of space complexity analysis.)
*/

namespace Demo
{
    public partial class Solution
    {
        public void Test_ProductExceptSelf()
        {
            ProductExceptSelf(new []{0, 0}).Print();
            ProductExceptSelf(new[] { 1, 0 }).Print();
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            if (nums == null)
            {
                return null;
            }

            var ret = new int[nums.Length];
            if (ret.Length != 0)
            {
                ret[0] = 1;
                for (int i = 1; i < nums.Length; i++)
                {
                    ret[i] = nums[i-1]*ret[i - 1];
                }

                int right = nums[nums.Length-1];
                for (int i = nums.Length -2; i >=0; i--)
                {
                    ret[i] = ret[i] * right;
                    right *= nums[i];
                }
            }
            return ret;
        }
    }
}
