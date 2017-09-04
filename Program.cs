using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine(new Solution().CountRangeSum(new [] {-2,5,-1}, -2, 2));
            Trie t = new Trie();
            t.Insert("app");
            t.Insert("apple");
            t.Insert("beer");
            t.Insert("add");
            t.Insert("jam");
            t.Insert("rental");
            Console.WriteLine(t.Search("apps"));
            Console.WriteLine(t.Search("app"));
            Console.WriteLine(t.Search("ab"));
        }
    }
}
