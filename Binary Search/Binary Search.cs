using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_Search()
        {
            Console.WriteLine(Search2(new[] {1, 2, 3, 4}, i => i <= 2));
            Console.WriteLine(Search2(new[] {1, 2, 3, 4}, i => i <= 0));
            Console.WriteLine(Search2(new[] {1, 2, 3, 4}, i => i <= 5));
        }

        // first i meet codition
        public int Search1<T>(T[] num, Func<T, int> condition)
        {
            int low = 0;
            int high = num.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low)/2;
                if (condition(num[mid]) < 0)
                {
                    low = mid + 1;
                }
                else if (condition(num[mid]) > 0)
                {
                    high = mid - 1;
                }
                else // condition(num[mid]) == 0
                {
                    return low;
                }
            }

            return -1;
        }

        // first i does not meet codition
        public int Search2<T>(T[] num, Func<T, bool> condition)
        {
            int low = 0;
            int high = num.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (condition(num[mid]))  // mid meet condition
                {
                    low = mid + 1;
                }
                else // mid does not meet condition
                {
                    high = mid -1;
                }
            }
            return low;
        }
    }
}
