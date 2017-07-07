/*
216	Combination Sum III
easy, recursion
Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

Ensure that numbers within the set are sorted in ascending order.


Example 1:

Input: k = 3, n = 7

Output:

[[1,2,4]]

Example 2:

Input: k = 3, n = 9

Output:

[[1,2,6], [1,3,5], [2,3,4]]
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void Test_CombinationSum3()
        {
            CombinationSum3(3, 7);
        }

        public IList<IList<int>> CombinationSum32(int k, int n)
        {
            var ret = new List<IList<int>>();
            var cur = new List<int>();
            CombinationSum32(ret, cur, 1, k, n);
            return ret;
        }

        public void CombinationSum32(IList<IList<int>> ret, IList<int> cur, int i, int k, int n)
        {
            if (n <= 0 || k <= 0 || i>=10)
            {
                if (n == 0 && k == 0)
                {
                    ret.Add(new List<int>(cur));
                }
                return;
            }


            cur.Add(i);
            CombinationSum32(ret, cur, i + 1, k - 1, n - i);
            cur.RemoveAt(cur.Count - 1);


            CombinationSum32(ret, cur, i + 1, k, n);
        }


        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var ret = new List<IList<int>>();
            var cur = new List<int>();
            CombinationSum3(ret, cur, k, n);
            return ret;
        }

        public void CombinationSum3(IList<IList<int>> ret, IList<int> cur, int k, int n)
        {
            if (n <= 0 || k <= 0)
            {
                if (n == 0 && k == 0)
                {
                    ret.Add(new List<int>(cur));
                }
                return;
            }

            for (int i = cur.Count == 0 ? 1 : cur[cur.Count - 1] + 1; i <= 9; i++)
            {
                cur.Add(i);
                CombinationSum3(ret, cur, k - 1, n - i);
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }
}
