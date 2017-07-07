/*
54	Spiral Matrix
easy
Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

For example,
Given n = 3,

You should return the following matrix:
[
 [ 1, 2, 3 ],
 [ 8, 9, 4 ],
 [ 7, 6, 5 ]
]
*/

namespace Demo
{
    public partial class Solution
    {
        public void Test_GenerateMatrix()
        {
            GenerateMatrix(9).Print();
        }
        public int[,] GenerateMatrix(int n)
        {
            int[,] ret = new int[n,n];
            int x = 0;
            int y = 0;
            int minx = 0;
            int miny = 0;
            int maxx = n - 1;
            int maxy = n - 1;
            int dir = 0;
            for (int i = 1; i <= n * n; i++)
            {
                ret[x, y] = i;
                switch (dir)
                {
                    case 0: // left
                        if (y < maxy)
                        {
                            y++;
                            break;
                        }
                        x++;
                        minx++;
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
