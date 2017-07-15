/*
119	Pascal's Triangle II
easy, math
Pascal's Triangle II
Given an index k, return the kth row of the Pascal's triangle.

For example, given k = 3,
Return [1,3,3,1].

Note:
Could you optimize your algorithm to use only O(k) extra space?
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> GetRow(int rowIndex)
        {
            List<int> row = new List<int>();
            for (int i = 0; i < rowIndex; i++)
            {
                row.Insert(0, 1);
                for (int j = 1; j < row.Count - 1; j++)
                {
                    row[j] = row[j] + row[j + 1];
                }
            }

            return row;
        }
    }
}
