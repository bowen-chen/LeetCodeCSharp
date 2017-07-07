namespace Demo
{
    public class UnionFind
    {
        private readonly int[] parent;

        public UnionFind(int size)
        {
            parent = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
            }
            Count = size;
        }

        public bool Union(int m, int n)
        {
            int src = Find(m);
            int dst = Find(n);
            //union
            if (src != dst)
            {
                parent[src] = dst;
                Count--;
                return true;
            }

            return false;
        }

        public int Find(int x)
        {
            while (x != parent[x])
            {
                parent[x] = parent[parent[x]];
                x = parent[x];
            }
            return x;
        }

        public int Count { get; set; }
    }
}
