/*
282	Expression Add Operators
easy, recursive, *
Expression Add Operators

Given a string that contains only digits 0-9 and a target value, return all possibilities to add binary operators (not unary) +, -, or * between the digits so they evaluate to the target value.

Examples: 
"123", 6 -> ["1+2+3", "1*2*3"] 
"232", 8 -> ["2*3+2", "2+3*2"]
"105", 5 -> ["1*0+5","10-5"]
"00", 0 -> ["0+0", "0-0", "0*0"]
"3456237490", 9191 -> []
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> AddOperators(string num, int target)
        {
            var ret = new List<string>();
            if (string.IsNullOrEmpty(num))
            {
                return ret;
            }

            AddOperators(ret, num, target, 0, 0, 0, "");
            return ret;
        }

        private void AddOperators(IList<string> ret, string num, int target, int index, long result, long carrier, string currentString)
        {
            if (index == num.Length)
            {
                if (result + carrier == target)
                {
                    ret.Add(currentString);
                }

                return;
            }

            for (int i = index; i < num.Length; i++)
            {
                var temp = num.Substring(index, i - index + 1);
                long cur = long.Parse(temp);
                if (index == 0)
                {
                    AddOperators(ret, num, target, i + 1, 0, cur, temp);
                }
                else
                {
                    AddOperators(ret, num, target, i + 1, result + carrier, cur, currentString + "+" + temp);
                    AddOperators(ret, num, target, i + 1, result + carrier, -cur, currentString + "-" + temp);
                    AddOperators(ret, num, target, i + 1, result, carrier * cur, currentString + "*" + temp);
                }

                // start with 0
                if (cur == 0)
                {
                    break;
                }
            }
        }
    }
}
