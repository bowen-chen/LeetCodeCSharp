/*
52	N-Queens II
medium, recursion
Follow up for N-Queens problem.

Now, instead outputting board configurations, return the total number of distinct solutions.
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        /**
         * don't need to actually place the queen,
         * instead, for each row, try to place without violation on
         * col/ diagonal1/ diagnol2.
         * trick: to detect whether 2 positions sit on the same diagnol:
         * if delta(col, row) equals, same diagnol1;
         * if sum(col, row) equals, same diagnal2.
         */

        public int TotalNQueens(int n)
        {
            int count = 0;
            TotalNQueens(ref count, 0, n, new HashSet<int>(), new HashSet<int>(), new HashSet<int>());
            return count;
        }
        /**    | | |                / / /             \ \ \
          *    O O O               O O O               O O O
          *    | | |              / / / /             \ \ \ \
          *    O O O             0 O O O               O O O -2
          *    | | |              / / / /             \ \ \ \ 
          *    O O O             1 O O O               O O O -1
          *    | | |              / / /                 \ \ \
          *    0 1 2             2 3 4                   2 1 0
          *    row               row + col               row - col
          *   3 columns        5 45° diagonals     5 135° diagonals    (when n is 3)
          */
        private void TotalNQueens(ref int count, int row, int n, HashSet<int> occupiedCols, HashSet<int> occupiedDiag1s, HashSet<int> occupiedDiag2s)
        {
            // we can now place a queen here
            if (row == n)
            {
                count++;
                return;
            }

            for (int col = 0; col < n; col++)
            {
                int diag1 = row - col;
                int diag2 = row + col;
                if (!occupiedCols.Contains(col) && !occupiedDiag1s.Contains(diag1) && !occupiedDiag2s.Contains(diag2))
                {
                    occupiedCols.Add(col);
                    occupiedDiag1s.Add(diag1);
                    occupiedDiag2s.Add(diag2);
                    TotalNQueens(ref count, row + 1, n, occupiedCols, occupiedDiag1s, occupiedDiag2s);
                    occupiedCols.Remove(col);
                    occupiedDiag1s.Remove(diag1);
                    occupiedDiag2s.Remove(diag2);
                }
            }
        }
    }
}
