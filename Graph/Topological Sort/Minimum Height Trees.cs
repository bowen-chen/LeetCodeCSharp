/*
310	Minimum Height Trees 
easy, *
For a undirected graph with tree characteristics, we can choose any node as the root. The result graph is then a rooted tree. Among all possible rooted trees, those with minimum height are called minimum height trees (MHTs). Given such a graph, write a function to find all the MHTs and return a list of their root labels.

Format
The graph contains n nodes which are labeled from 0 to n - 1. You will be given the number n and a list of undirected edges (each edge is a pair of labels).

You can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0, 1] is the same as [1, 0] and thus will not appear together in edges.

Example 1:

Given n = 4, edges = [[1, 0], [1, 2], [1, 3]]

        0
        |
        1
       / \
      2   3
return [1]

Example 2:

Given n = 6, edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]

     0  1  2
      \ | /
        3
        |
        4
        |
        5
return [3, 4]

Hint:

How many MHTs can a graph have at most?
Note:

(1) According to the definition of tree on Wikipedia: “a tree is an undirected graph in which any two vertices are connected by exactly one path. In other words, any connected graph without simple cycles is a tree.”

(2) The height of a rooted tree is the number of edges on the longest downward path between the root and a leaf.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> FindMinHeightTrees(int n, int[,] edges)
        {
            if (n == 1)
            {
                return new List<int> {0};
            }
            
            var adj = new HashSet<int>[n];
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int a = edges[i, 0];
                int b = edges[i, 1];
                if (adj[a] == null)
                {
                    adj[a] = new HashSet<int>();
                }
                if (adj[b] == null)
                {
                    adj[b] = new HashSet<int>();
                }

                adj[a].Add(b);
                adj[b].Add(a);
            }

            var q = new Queue<int>();
            for (int i = 0; i < n; ++i)
            {
                if (adj[i] == null || adj[i].Count == 1)
                {
                    q.Enqueue(i);
                }
            }

            while (n > 2)
            {
                n -= q.Count;
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var c = q.Dequeue();
                    foreach (var d in adj[c])
                    {
                        adj[d].Remove(c);
                        if (adj[d].Count == 1)
                        {
                            q.Enqueue(d);
                        }
                    }
                }
            }

            return q.ToList();
        }
    }
}
