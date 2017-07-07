/*
223	Rectangle Area
hard, math
Find the total area covered by two rectilinear rectangles in a 2D plane.

Each rectangle is defined by its bottom left corner and top right corner as shown in the figure.

Rectangle Area
Assume that the total area is never beyond the maximum possible value of int.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            int x = Math.Min(G, C) > Math.Max(E, A) ? (Math.Min(G, C) - Math.Max(E, A)) : 0;
            int y = Math.Min(D, H) > Math.Max(B, F) ? (Math.Min(D, H) - Math.Max(B, F)) : 0;
            return (D - B)*(C - A) + (G - E)*(H - F) - x*y;
        }
    }
}
