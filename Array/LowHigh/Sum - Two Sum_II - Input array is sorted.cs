/*
167	Two Sum II - Input array is sorted
Sum - Two Sum II - Input array is sorted
1 based index - what's wrong with you?
*/

namespace Demo
{
    public partial class Solution
    {
        public int[] TwoSum3(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return null;
            }

            int low = 0;
            int high = numbers.Length - 1;

            while (low < high)
            {
                int x = numbers[low] + numbers[high];
                if (x < target)
                {
                    low++ ;
                }
                else if (x > target)
                {
                    high--;
                }
                else
                {
                    return new int[] { low + 1, high + 1 };
                }
            }

            return null;
        }
    }
}
