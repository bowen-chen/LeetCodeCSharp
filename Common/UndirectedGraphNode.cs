using System.Collections.Generic;

namespace Demo
{
    // Definition for undirected graph.
    public class UndirectedGraphNode
    {
        public int label;
        public IList<UndirectedGraphNode> neighbors;

        public UndirectedGraphNode(int x)
        {
            label = x;
            neighbors = new List<UndirectedGraphNode>();
        }
    };
}
