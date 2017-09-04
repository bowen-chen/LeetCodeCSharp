/*
301	Remove Invalid Parentheses
medium, *
Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.

Note: The input string may contain letters other than the parentheses ( and ).

Examples:
"()())()" -> ["()()()", "(())()"]
"(a)())()" -> ["(a)()()", "(a())()"]
")(" -> [""]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> RemoveInvalidParentheses(string s)
        {
            var ret = new List<string>();
            HashSet<string> visited = new HashSet<string>();
            Queue<string> q = new Queue<string>();
            q.Enqueue(s);
            q.Enqueue(null);
            visited.Add(s);
            while (q.Count > 0)
            {
                var ss = q.Dequeue();
                if (ss == null)
                {
                    // !!! all valid string should be on same level
                    if (ret.Count > 0)
                    {
                        break;
                    }

                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                    }
                }
                else if (IsValidParentheses(ss))
                {
                    ret.Add(ss);
                }
                else
                {
                    for (int i = 0; i < ss.Length; i++)
                    {
                        if (ss[i] == '(' || ss[i] == ')')
                        {
                            var sss = ss.Remove(i, 1);
                            if (!visited.Contains(sss))
                            {
                                q.Enqueue(sss);
                                visited.Add(sss);
                            }
                        }
                    }
                }
            }

            return ret;
        }

        private bool IsValidParentheses(string s)
        {
            int count = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    count++;
                }
                else if(c==')')
                {
                    if (--count < 0)
                    {
                        return false;
                    }
                }
            }

            return count == 0;
        }
    }
}
