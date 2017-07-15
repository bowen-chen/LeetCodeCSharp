/*
531	Lonely Pixel I   
Given a picture consisting of black and white pixels, find the number of black lonely pixels.

The picture is represented by a 2D char array consisting of 'B' and 'W', which means black and white pixels respectively.

A black lonely pixel is character 'B' that located at a specific position where the same row and same column don't have any other black pixels.

Example:

Input: 
[['W', 'W', 'B'],
 ['W', 'B', 'W'],
 ['B', 'W', 'W']]

Output: 3
Explanation: All the three 'B's are black lonely pixels.
 

Note:

The range of width and height of the input 2D array is [1,500].
*/

namespace Demo
{
    public partial class Solution
    {
        public int FindLonelyPixel(char[,]picture)
        {
            if (picture == null || picture.GetLength(0) == 0 || picture.GetLength(1) == 0)
            {
                return 0;
            }

            int m = picture.GetLength(0);
            int n = picture.GetLength(1);
            int res = 0;
            var row = new int[m];
            var col = new int[n];
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (picture[i, j] == 'B')
                    {
                        ++row[i];
                        ++col[j];
                    }
                }
            }

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (picture[i, j] == 'B' && row[i] == 1 && col[j] == 1)
                    {
                        ++res;
                    }
                }
            }

            return res;
        }
    };
}
