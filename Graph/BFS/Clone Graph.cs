/*
133	Clone Graph
easy, graph
Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors.


OJ's undirected graph serialization:
Nodes are labeled uniquely.

We use # as a separator for each node, and , as a separator for node label and each neighbor of the node.
As an example, consider the serialized graph {0,1,2#1,2#2,2}.

The graph has a total of three nodes, and therefore contains three parts as separated by #.

First node is labeled as 0. Connect node 0 to both nodes 1 and 2.
Second node is labeled as 1. Connect node 1 to node 2.
Third node is labeled as 2. Connect node 2 to node 2 (itself), thus forming a self-cycle.
Visually, the graph looks like the following:

       1
      / \
     /   \
    0 --- 2
         / \
         \_/
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null)
            {
                return null;
            }

            Dictionary<int, UndirectedGraphNode> m = new Dictionary<int, UndirectedGraphNode>();

            UndirectedGraphNode ret = new UndirectedGraphNode(node.label);
            m.Add(ret.label, ret);
            Queue<UndirectedGraphNode> q = new Queue<UndirectedGraphNode>();
            q.Enqueue(node);

            while (q.Count != 0)
            {
                UndirectedGraphNode n = q.Dequeue();
                UndirectedGraphNode nc = m[n.label];
                foreach (var neighor in n.neighbors)
                {
                    if (!m.ContainsKey(neighor.label))
                    {
                        UndirectedGraphNode c = new UndirectedGraphNode(neighor.label);
                        m.Add(c.label, c);
                        q.Enqueue(neighor);
                        nc.neighbors.Add(c);
                    }
                    else
                    {
                        nc.neighbors.Add(m[neighor.label]);
                    }
                }
            }

            return ret;
        }
    }
}
