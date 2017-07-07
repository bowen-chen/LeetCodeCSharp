/*
85	Maximal Rectangle
hard
Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing all ones and return its area.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaximalRectangle(char[,] matrix)
        {
            int n = matrix.GetLength(1), maxA = 0;
            int[] h = new int[n];
            int[] l = new int[n];
            int[] r = new int[n];

            for (int i = 0; i < n; i++)
            {
                r[i] = n;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == '1') // compute height (can do this from either side)
                    {
                        h[j]++;
                    }
                    else
                    {
                        h[j] = 0;
                    }
                }
                
                int curLeft = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == '1') // compute left (from left to right)
                    {
                        l[j] = Math.Max(l[j], curLeft);
                    }
                    else
                    {
                        l[j] = 0;
                        curLeft = j + 1;
                    }
                }


                int curRight = n;
                // compute right (from right to left)
                for (int j = n - 1; j >= 0; j--)
                {
                    if (matrix[i, j] == '1')
                    {
                        r[j] = Math.Min(r[j], curRight);
                    }
                    else
                    {
                        r[j] = n;
                        curRight = j;
                    }
                }

                // compute the area of rectangle (can do this from either side)
                for (int j = 0; j < n; j++)
                {
                    maxA = Math.Max(maxA, (r[j] - l[j])*h[j]);
                }
            }
            return maxA;
        }
    }
}