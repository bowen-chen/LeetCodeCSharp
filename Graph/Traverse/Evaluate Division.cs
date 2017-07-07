/*
399. Evaluate Division
Equations are given in the format A / B = k, where A and B are variables represented as strings, and k is a real number (floating point number). Given some queries, return the answers. If the answer does not exist, return -1.0.

Example:
Given a / b = 2.0, b / c = 3.0. 
queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? . 
return [6.0, 0.5, -1.0, 1.0, -1.0 ].

The input is: vector<pair<string, string>> equations, vector<double>& values, vector<pair<string, string>> queries , where equations.size() == values.size(), and the values are positive. This represents the equations. Return vector<double>.

According to the example above:

equations = [ ["a", "b"], ["b", "c"] ],
values = [2.0, 3.0],
queries = [ ["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"] ]. 
The input is always valid. You may assume that evaluating the queries will result in no division by zero and there is no contradiction.

a/b b/c d/c
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public double[] CalcEquation(string[,] equations, double[] values, string[,] queries)
        {
            var res = new double[queries.GetLength(0)];
            for (int i = 0; i < queries.GetLength(0); i++)
            {
                if (queries[i, 0] != queries[i, 1])
                {
                    res[i] = CalcEquation(equations, values, queries, i);
                }
                else
                {
                    bool found = false;
                    foreach (var q in equations)
                    {
                        if (q == queries[i, 0])
                        {
                            found = true;
                            res[i] = 1.0f;
                        }
                    }

                    if (!found)
                    {
                        res[i] = -1.0f;
                    }
                }
            }

            return res;
        }

        private double CalcEquation(string[,] equations, double[] values, string[,] queries, int i)
        {
            var visited = new HashSet<string> {queries[i, 0]};
            var q = new Queue<Tuple<string, double>>();
            q.Enqueue(Tuple.Create(queries[i, 0], 1.0d));
            while (q.Count != 0)
            {
                var c = q.Dequeue();
                for (int j = 0; j < equations.GetLength(0); j++)
                {
                    if (equations[j, 0] == c.Item1 && !visited.Contains(equations[j, 1]))
                    {
                        if (equations[j, 1] == queries[i, 1])
                        {
                            return c.Item2*values[j];
                        }

                        visited.Add(equations[j, 1]);
                        q.Enqueue(Tuple.Create(equations[j, 1], c.Item2*values[j]));
                    }
                    else if (equations[j, 1] == c.Item1 && !visited.Contains(equations[j, 0]))
                    {
                        if (equations[j, 0] == queries[i, 1])
                        {
                            return c.Item2/values[j];
                        }

                        visited.Add(equations[j, 0]);
                        q.Enqueue(Tuple.Create(equations[j, 0], c.Item2/values[j]));
                    }
                }
            }

            return -1.0d;
        }
    }
}
