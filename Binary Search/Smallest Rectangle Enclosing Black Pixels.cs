/*
302	Smallest Rectangle Enclosing Black Pixels
An image is represented by a binary matrix with 0 as a white pixel and 1 as a black pixel. The black pixels are connected, i.e., there is only one black region. Pixels are connected horizontally and vertically. Given the location (x, y) of one of the black pixels, return the area of the smallest (axis-aligned) rectangle that encloses all black pixels.
For example, given the following image:
[
  "0010",
  "0110",
  "0100"
]
and x = 0, y = 2, Return 6.
*/

namespace Demo
{
    public partial class Solution
    {
        public int MinArea(char[,] image, int x, int y)
        {
            int left = SearchLeft(image, y);
            int right = SearchRight(image, y);
            int top = SearchTop(image, x);
            int bottom = SearchBottom(image, x);
            return (right - left + 1) * (bottom - top + 1);
        }

        public int SearchLeft(char[,] image, int right)
        {
            int l = 0, r = right;
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (!FindBlack(image, m, false)) l = m + 1;
                else r = m - 1;
            }
            return l;
        }

        public int SearchRight(char[,] image, int left)
        {
            int l = left, r = image.GetLength(0) - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (!FindBlack(image, m, false)) r = m - 1;
                else l = m + 1;
            }
            return r;
        }

        public int SearchTop(char[,] image, int bottom)
        {
            int l = 0, r = bottom;
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (!FindBlack(image, m, true)) l = m + 1;
                else r = m - 1;
            }
            return l;
        }

        public int SearchBottom(char[,] image, int top)
        {
            int l = top, r = image.GetLength(0) - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (!FindBlack(image, m, true)) r = m - 1;
                else l = m + 1;
            }
            return r;
        }

        public bool FindBlack(char[,] image, int cur, bool row)
        {
            if (row)
            {
                int n = image.GetLength(1);
                for (int i = 0; i < n; i++)
                {
                    if (image[cur, i] == '1')
                        return true;
                }
                return false;
            }
            else
            {
                int m = image.GetLength(0);
                for (int j = 0; j < m; j++)
                {
                    if (image[j, cur] == '1')
                        return true;
                }
                return false;
            }
        }
    }
}
