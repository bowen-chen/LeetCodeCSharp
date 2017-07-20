/*
241	Different Ways to Add Parentheses
medium, recursive
Different Ways to Add Parentheses

Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators. The valid operators are +, - and *.


Example 1
Input: "2-1-1".

((2-1)-1) = 0
(2-(1-1)) = 2
Output: [0, 2]


Example 2
Input: "2*3-4*5"

(2*(3-(4*5))) = -34
((2*3)-(4*5)) = -14
((2*(3-4))*5) = -10
(2*((3-4)*5)) = -10
(((2*3)-4)*5) = 10
Output: [-34, -14, -10, -10, 10]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void Test_DiffWaysToCompute()
        {
            DiffWaysToCompute("0");
            DiffWaysToCompute("0+1");
        }

        public IList<int> DiffWaysToCompute(string input)
        {
            var ret = new List<int>();
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*')
                {
                    var left = DiffWaysToCompute(input.Substring(0, i));
                    var right = DiffWaysToCompute(input.Substring(i + 1));
                    foreach(int l in left)
                    {
                        foreach (int r in right)
                        {
                            if (input[i] == '+')
                            {
                                ret.Add(l + r);
                            }
                            else if (input[i] == '-')
                            {
                                ret.Add(l - r);
                            }
                            else
                            {
                                ret.Add(l * r);
                            }
                        }
                    }
                }
            }

            if (ret.Count == 0)
            {
                ret.Add(int.Parse(input));
            }

            return ret;
        }

        public IList<int> DiffWaysToCompute2(string input)
        {
            var inputs = new List<string>();
            int s = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*')
                {
                    inputs.Add(input.Substring(s, i - s));
                    inputs.Add(input.Substring(i, 1));
                    s = i + 1;
                }
            }

            inputs.Add(input.Substring(s));

            // ['0', '+', '1']
            return DiffWaysToCompute(inputs, 0, inputs.Count - 1);
        }

        private IList<int> DiffWaysToCompute(IList<string> inputs, int s, int e)
        {
            if (e - s == 0)
            {
                return new List<int> { int.Parse(inputs[s]) };
            }

            var ret = new List<int>();

            // inputs[i] is operator
            for (int i = s + 1; i <= e; i += 2)
            {
                var ret1 = DiffWaysToCompute(inputs, s, i - 1);
                var ret2 = DiffWaysToCompute(inputs, i + 1, e);
                foreach (var r1 in ret1)
                {
                    foreach (var r2 in ret2)
                    {
                        switch (inputs[i])
                        {
                            case "+":
                                ret.Add(r1 + r2);
                                break;
                            case "-":
                                ret.Add(r1 - r2);
                                break;
                            case "*":
                                ret.Add(r1 * r2);
                                break;
                        }
                    }
                }
            }
            return ret;
        }
    }
}
