/*
247	Strobogrammatic Number II $
A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).

Find all strobogrammatic numbers that are of length = n.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public List<string> FindStrobogrammatic(int n)
        {
            return FindStrobogrammatic(n, n).ToList();
        }

        IEnumerable<string> FindStrobogrammatic(int n, int m)
        {
            if (n == 0)
            {
                yield return "";
            }
            else if (n == 1)
            {
                yield return "0";
                yield return "1";
                yield return "8";
            }
            else
            {
                foreach (string s in FindStrobogrammatic(n - 2, m))
                {
                    if (n != m)
                    {
                        yield return "0" + s + "0";
                    }

                    yield return "1" + s + "1";
                    yield return "6" + s + "9";
                    yield return "8" + s + "8";
                    yield return "9" + s + "6";
                }
            }
        }

        public List<string> FindStrobogrammatic2(int n)
        {
            var one = new List<string> { "0", "1", "8" };
            var two = new List<string> { "" };
            var r = n % 2 == 1 ? one : two;
            for (int i = n/2; i >0; i --)
            {
                var newList = new List<string>();
                foreach (string str in r)
                {
                    if (i != 0)
                    {
                        newList.Add("0" + str + "0");
                    }
                    newList.Add("1" + str + "1");
                    newList.Add("6" + str + "9");
                    newList.Add("8" + str + "8");
                    newList.Add("9" + str + "6");
                }
                r = newList;
            }
            return r;
        }
    }
}
