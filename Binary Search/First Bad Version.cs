/*
278. First Bad Version
easy, low high
First Bad Version

You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.

Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

You are given an API bool isBadVersion(version) which will return whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.
*/

using System;

namespace Demo
{
    /* The isBadVersion API is defined in the parent class VersionControl.
          bool IsBadVersion(int version); */

    public partial class Solution
    {
        public void Test_FirstBadVersion()
        {
            Console.WriteLine(FirstBadVersion(2126753390));
        }

        private bool IsBadVersion(long version)
        {
            return version >= 1702766719;
        }

        public int FirstBadVersion(int n)
        {
            int low = 1;
            int high = n;

            // find the first version which doesn't meet condition good.
            while (low <= high)
            {
                // (low + high)/2; overflow
                // mid could be equals low
                int mid = low + (high - low) / 2;
                if (!IsBadVersion(mid))
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return low;
        }
    }
}
