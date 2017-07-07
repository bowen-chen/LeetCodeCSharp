/*
150	Evaluate Reverse Polish Notation	
easy,stack
Evaluate Reverse Polish Notation

Evaluate the value of an arithmetic expression in Reverse Polish Notation.

Valid operators are +, -, *, /. Each operand may be an integer or another expression.

Some examples:
  ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
  ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> s = new Stack<int>();
            foreach (string t in tokens)
            {
                switch (t)
                {
                    case "+":
                        s.Push(s.Pop() + s.Pop());
                        break;
                    case "-":
                        int t2 = s.Pop();
                        int t1 = s.Pop();
                        s.Push(t1 - t2);
                        break;
                    case "*":
                        s.Push(s.Pop() * s.Pop());
                        break;
                    case "/":
                        t2 = s.Pop();
                        t1 = s.Pop();
                        s.Push(t1 / t2);
                        break;
                    default:
                        s.Push(int.Parse(t));
                        break;
                }
            }
            return s.Pop();
        }
    }
}
