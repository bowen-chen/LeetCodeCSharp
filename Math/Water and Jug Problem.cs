/*
365. Water and Jug Problem
You are given two jugs with capacities x and y litres. There is an infinite amount of water supply available. You need to determine whether it is possible to measure exactly z litres using these two jugs.

If z liters of water is measurable, you must have z liters of water contained within one or both buckets by the end.

Operations allowed:

Fill any of the jugs completely with water.
Empty any of the jugs.
Pour water from one jug into another till the other jug is completely full or the first jug itself is empty.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        // z = m * x + n * y
        public bool CanMeasureWater(int x, int y, int z)
        {
            return z == 0 || (x + y >= z && z%gcd(x, y) == 0);
        }

        private int gcd(int x, int y)
        {
            return y == 0 ? x : gcd(y, x%y);
        }

        public bool CanMeasureWater2(int x, int y, int z)
        {
            if (x + y < z) return false;

            if (x > y)
            {
                int tmp = x;
                x = y;
                y = tmp;
            }

            var states = new Queue<JugState>();
            var visited = new HashSet<JugState>();

            // initial state
            var init = new JugState(0, 0);
            states.Enqueue(init);
            visited.Add(init);

            while (states.Count != 0)
            {
                JugState curr = states.Dequeue();

                // fill jug1
                var temp = new List<JugState>();
                temp.Add(new JugState(x, curr.b)); // fill jug 1
                temp.Add(new JugState(0, curr.b)); // empty jug1
                temp.Add(new JugState(curr.a, y)); // fill jug 2
                temp.Add(new JugState(curr.a, 0)); // empty jug2
                temp.Add(new JugState(Math.Min(curr.a + curr.b, x),
                    curr.a + curr.b < x ? 0 : curr.b - (x - curr.a))); // pour all water from jug2 to jug1 x
                temp.Add(new JugState(curr.a + curr.b < y ? 0 : curr.a - (y - curr.b),
                    Math.Min(curr.a + curr.b, y))); // pour all water from jug1 to jug2 y

                foreach (JugState tmp in temp)
                {
                    if (visited.Contains(tmp)) continue;

                    if (curr.a + curr.b == z) return true;
                    states.Enqueue(tmp);
                    visited.Add(tmp);
                }
            }
            return false;
        }


        private class JugState
        {
            public int a, b;

            public JugState(int a, int b)
            {
                this.a = a;
                this.b = b;
            }

            public override int GetHashCode()
            {
                return 31*a + b;
            }

            public override bool Equals(object obj)
            {
                JugState other = (JugState) obj;
                return this.a == other.a && this.b == other.b;
            }
        }
    }
}
