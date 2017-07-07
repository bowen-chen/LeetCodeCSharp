/*
48	Rotate Image
medium, math
You are given an n x n 2D matrix representing an image.

Rotate the image by 90 degrees (clockwise).

Follow up:
Could you do this in-place?

00, 01 11, 10
00,02,22,20|01,12,21,10

xxxx.
.xx..
..x..
.....
.....
*/

namespace Demo
{
    public partial class Solution
    {
        public void Rotate(int[,] matrix)
        {
            int n = matrix.GetUpperBound(0) + 1;
            for (int i = 0; i < n / 2; i++)
            {
                // n-(i+i)+i-1
                for (int j = i; j < n - i - 1; j++)
                {
                    // i,j
                    // j,n-i-1
                    // n-i-1, n-j-1
                    // n-j-1,i
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[n - j - 1, i];
                    matrix[n - j - 1, i] = matrix[n - i - 1, n - j - 1];
                    matrix[n - i - 1, n - j - 1] = matrix[j, n - i - 1];
                    matrix[j, n - i - 1] = temp;
                }
            }
        }

        /*
         * clockwise rotate
         * first reverse up to down, then swap the symmetry 
         * 1 2 3     7 8 9     7 4 1
         * 4 5 6  => 4 5 6  => 8 5 2
         * 7 8 9     1 2 3     9 6 3
        */
        //public void Rotate(vector<vector<int>> &matrix)
        //{
        //    reverse(matrix.begin(), matrix.end());
        //    for (int i = 0; i < matrix.size(); ++i)
        //    {
        //        for (int j = i + 1; j < matrix[i].size(); ++j)
        //            swap(matrix[i][j], matrix[j][i]);
        //    }
        //}

        /*
         * anticlockwise rotate
         * first reverse left to right, then swap the symmetry
         * 1 2 3     3 2 1     3 6 9
         * 4 5 6  => 6 5 4  => 2 5 8
         * 7 8 9     9 8 7     1 4 7
        */
        //public void anti_rotate(vector<vector<int>> &matrix)
        //{
        //    for (auto vi : matrix) reverse(vi.begin(), vi.end());
        //    for (int i = 0; i < matrix.size(); ++i)
        //    {
        //        for (int j = i + 1; j < matrix[i].size(); ++j)
        //            swap(matrix[i][j], matrix[j][i]);
        //    }
        //}
    }
}
