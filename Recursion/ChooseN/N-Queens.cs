/*
51	N-Queens
medium, recursion
The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.

Given an integer n, return all distinct solutions to the n-queens puzzle.

Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.

For example,
There exist two distinct solutions to the 4-queens puzzle:

[
 [".Q..",  // Solution 1
  "...Q",
  "Q...",
  "..Q."],

 ["..Q.",  // Solution 2
  "Q...",
  "...Q",
  ".Q.."]
]
*/
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public void Test_SolveNQueens()
        {
            SolveNQueens(2);
            SolveNQueens(8);
        }
        public IList<IList<string>> SolveNQueens(int n)
        {
            var ret = new List<IList<string>>();
            SolveNQueens(ret, 0, n, new int[n], new HashSet<int>(), new HashSet<int>(), new HashSet<int>());
            return ret;
        }

        private void SolveNQueens(IList<IList<string>> ret, int row, int n, int[] current, HashSet<int> occupiedCols, HashSet<int> occupiedDiag1s, HashSet<int> occupiedDiag2s)
        {
            if (row == n)
            {
                var r = new List<string>();
                var init = new string('.', n);
                foreach (var i in current)
                {
                    var sb = new StringBuilder(init);
                    sb[i] = 'Q';
                    r.Add(sb.ToString());
                }
                ret.Add(r);
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
                    current[row]= col;
                    SolveNQueens(ret, row + 1, n, current, occupiedCols, occupiedDiag1s, occupiedDiag2s);
                    occupiedCols.Remove(col);
                    occupiedDiag1s.Remove(diag1);
                    occupiedDiag2s.Remove(diag2);
                }
            }
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
    }
}
