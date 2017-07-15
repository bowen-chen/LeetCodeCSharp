/*
118	Pascal's Triangle
easy, math
Pascal's Triangle

Given numRows, generate the first numRows of Pascal's triangle.

For example, given numRows = 5,
Return

[
     [1],
    [1,1],
   [1,2,1],
  [1,3,3,1],
 [1,4,6,4,1]
]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> allrows = new List<IList<int>>();
            List<int> row = new List<int>();
            for (int i = 0; i < numRows; i++)
            {
                row.Insert(0, 1);
                for (int j = 1; j < row.Count - 1; j++)
                {
                    row[j] = row[j] + row[j + 1];
                }

                allrows.Add(new List<int>(row));
            }

            return allrows;
        }
    }
}
