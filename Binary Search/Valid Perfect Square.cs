/*
367. Valid Perfect Square
*
Given a positive integer num, write a function which returns True if num is a perfect square else False.

Note: Do not use any built-in library function such as sqrt.

Example 1:

Input: 16
Returns: True
Example 2:

Input: 14
Returns: False

*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsPerfectSquare(int num)
        {
            int low = 1;
            int high = num;
            while (low <= high)
            {
                int mid = low + (high - low)/2;
                long t = (long) mid*mid;
                if (t < num)
                {
                    low = mid + 1;
                }
                else if (t > num)
                {
                    high = mid - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
