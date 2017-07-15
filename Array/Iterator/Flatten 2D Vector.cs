/*
251	Flatten 2D Vector
easy
Implement an iterator to flatten a 2d vector.

For example,
Given 2d vector =

[
  [1,2],
  [3],
  [4,5,6]
]
By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1, 2, 3, 4, 5, 6].
*/
using System.Collections.Generic;

namespace Demo
{
    public class Vector2D
    {
        private int row;
        private int col;
        private readonly List<List<int>> data;

        public Vector2D(List<List<int>> vec2d)
        {
            data = vec2d;
        }

        public int Next()
        {
            return data[row][col++];
        }

        public bool HasNext()
        {
            while (row < data.Count && data[row].Count >= col)
            {
                row++;
                col = 0;
            }

            return row < data.Count;
        }
    }
}
