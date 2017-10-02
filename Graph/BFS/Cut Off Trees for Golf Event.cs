/*
675. Cut Off Trees for Golf Event
You are asked to cut off trees in a forest for a golf event. The forest is represented as a non-negative 2D map, in this map:

0 represents the obstacle can't be reached.
1 represents the ground can be walked through.
The place with number bigger than 1 represents a tree can be walked through, and this positive number represents the tree's height.
You are asked to cut off all the trees in this forest in the order of tree's height - always cut off the tree with lowest height first. And after cutting, the original place has the tree will become a grass (value 1).

You will start from the point (0, 0) and you should output the minimum steps you need to walk to cut off all the trees. If you can't cut off all the trees, output -1 in that situation.

You are guaranteed that no two trees have the same height and there is at least one tree needs to be cut off.

Example 1:
Input: 
[
 [1,2,3],
 [0,0,4],
 [7,6,5]
]
Output: 6
Example 2:
Input: 
[
 [1,2,3],
 [0,0,0],
 [7,6,5]
]
Output: -1
Example 3:
Input: 
[
 [2,3,4],
 [0,0,5],
 [8,7,6]
]
Output: 6
Explanation: You started from the point (0,0) and you can cut off the tree in (0,0) directly without walking.
Hint: size of the given matrix will not exceed 50x50.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int CutOffTree(IList<IList<int>> forest)
        {
            if (forest == null || forest.Count == 0)
            {
                return 0;
            }

            int m = forest.Count;
            int n = forest[0].Count;
            var trees = new List<int[]>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (forest[i][j] > 1)
                    {
                        trees.Add(new[] {i, j, forest[i][j]});
                    }
                }
            }

            var start = new []{0,0};
            int sum = 0;
            foreach(var tree in trees.OrderBy(t=>t[2]))
            {
                int step = MinStep(forest, start, tree);
                if (step < 0)
                {
                    return -1;
                }

                sum += step;
                start[0] = tree[0];
                start[1] = tree[1];
            }

            return sum;
        }

        private int MinStep(IList<IList<int>> forest, int[] start, int[] tree)
        {
            int m = forest.Count;
            int n = forest[0].Count;

            int step = 0;
            var visited = new bool[m, n];
            var queue = new Queue<int[]>();
            visited[start[0], start[1]] = true;
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int[] curr = queue.Dequeue();
                    if (curr[0] == tree[0] && curr[1] == tree[1])
                    {
                        return step;
                    }

                    foreach (var d in new[] {new[] {0, 1}, new[] {1, 0}, new[] {-1, 0}, new[] {0, -1}})
                    {
                        int nr = curr[0] + d[0];
                        int nc = curr[1] + d[1];
                        if (nr < 0 || nr >= m || nc < 0 || nc >= n || forest[nr][nc] == 0 || visited[nr, nc])
                        {
                            continue;
                        }
                        visited[nr, nc] = true;
                        queue.Enqueue(new[] {nr, nc});
                    }
                }
                step++;
            }

            return -1;
        }
    }
}
