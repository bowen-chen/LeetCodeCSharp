/*
323	Number of Connected Components in an Undirected Graph
easy, uf
Given n nodes labeled from 0 to n - 1 and a list of undirected edges (each edge is a pair of nodes), write a function to find the number of connected components in an undirected graph.

Example 1:
     0          3
     |          |
     1 --- 2    4
Given n = 5 and edges = [[0, 1], [1, 2], [3, 4]], return 2.

Example 2:
     0           4
     |           |
     1 --- 2 --- 3
Given n = 5 and edges = [[0, 1], [1, 2], [2, 3], [3, 4]], return 1.

Note:
You can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0, 1] is the same as [1, 0] and thus will not appear together in edges.
*/

namespace Demo
{
    public partial class Solution
    {
        public int CountComponents(int n, int[,] edges)
        {
            UnionFind uf = new UnionFind(n);
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                uf.Union(edges[0, 0], edges[1, 1]);
            }
            return uf.Count;
        }
    }
}
