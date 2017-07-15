using System;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            // ["FileSystem","ls","mkdir","addContentToFile","ls","readContentFromFile"]
            // [[],["/"],["/a/b/c"],["/a/b/c/d","hello"],["/"],["/a/b/c/d"]]
            Console.WriteLine(new Solution().ReverseWords2("hello world!"));
        }
    }
}
