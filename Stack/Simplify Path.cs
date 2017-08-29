/*
71	Simplify Path
easy, *
Given an absolute path for a file (Unix-style), simplify it.

For example,
path = "/home/", => "/home"
path = "/a/./b/../../c/", => "/c"
click to show corner cases.

Corner Cases:
Did you consider the case where path = "/../"?
In this case, you should return "/".
Another corner case is the path might contain multiple slashes '/' together, such as "/home//foo/".
In this case, you should ignore redundant slashes and return "/home/foo".
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string SimplifyPath(string path)
        {
            var s = new Stack<string>();
            foreach (var token in path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries))
            {
                if (token == ".")
                {
                    continue;
                }
                if (token == "..")
                {
                    if (s.Count > 0)
                    {
                        s.Pop();
                    }
                }
                else
                {
                    s.Push(token);
                }
            }

            var sb = new StringBuilder();
            while (s.Count != 0)
            {
                sb.Insert(0, "/" + s.Pop());
            }

            if (sb.Length == 0)
            {
                sb.Append('/');
            }

            return sb.ToString();
        }
    }
}
