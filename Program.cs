using System;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(new Solution().FindDuplicateSubtrees(new TreeNode(0) {right = new TreeNode(0)}));
        }
    }
}
