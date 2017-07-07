/*
59	Spiral Matrix II
easy
Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

For example,
Given the following matrix:

[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
You should return [1,2,3,6,9,8,7,4,5].
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void SpiralOrder_Test()
        {
            int[,] m = new int[3,3];
            int c = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m[i,j] = c++;
                }
            }

            Console.WriteLine(string.Join(", ", SpiralOrder(m)));
        }

        public IList<int> SpiralOrder(int[,] matrix)
        {
            List<int> ret = new List<int>();
            if (matrix == null)
            {
                return ret;
            }
            if (matrix.Length == 0)
            {
                return ret;
            }
            int x = 0;
            int y = 0;
            int minx = 0;
            int miny = 0;
            int maxx = matrix.GetLength(0) - 1;
            int maxy = matrix.GetLength(1) - 1;
            int total = matrix.GetLength(0) * matrix.GetLength(1);
            int dir = 0;
            for (int i = 0; i < total; i++)
            {
                ret.Add(matrix[x, y]);
                switch (dir)
                {
                    case 0: // left
                        if (y < maxy)
                        {
                            y++;
                            break;
                        }
                        minx++;
                        x++;
                        dir = 1;
                        break;
                    case 1:
                        if (x < maxx)
                        {
                            x++;
                            break;
                        }
                        y--;
                        maxy--;
                        dir = 2;
                        break;
                    case 2:
                        if (y > miny)
                        {
                            y--;
                            break;
                        }
                        x--;
                        maxx--;
                        dir = 3;
                        break;
                    case 3:
                        if (x > minx)
                        {
                            x--;
                            break;
                        }
                        y++;
                        miny++;
                        dir = 0;
                        break;
                }
            }
            return ret;
        }
    }
}
