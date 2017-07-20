/*
465	Optimal Account Balancing
A group of friends went on holiday and sometimes lent each other money. For example, Alice paid for Bill's lunch for 10.ThenlaterChrisgaveAlice10.ThenlaterChrisgaveAlice5 for a taxi ride. We can model each transaction as a tuple (x, y, z) which means person x gave person y $z. Assuming Alice, Bill, and Chris are person 0, 1, and 2 respectively (0, 1, 2 are the person's ID), the transactions can be represented as [[0, 1, 10], [2, 0, 5]].

Given a list of transactions between a group of people, return the minimum number of transactions required to settle the debt.

Note:

A transaction will be given as a tuple (x, y, z). Note that x ≠ y and z > 0.
Person's IDs may not be linear, e.g. we could have the persons 0, 1, 2 or we could also have the persons 0, 2, 6.
 

Example 1:

Input:
[[0,1,10], [2,0,5]]

Output:
2

Explanation:
Person #0 gave person #1 $10.
Person #2 gave person #0 $5.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
   public partial class Solution
    {
        public int MinTransfers(int[,] transactions)
        {
            var m = new Dictionary<int, int>();
            for (int i = 0; i < transactions.GetLength(0); i++)
            {
                if (!m.ContainsKey(transactions[i, 0]))
                {
                    m[transactions[i, 0]] = 0;
                }

                m[transactions[i, 0]] -= transactions[i, 2];
                if (!m.ContainsKey(transactions[i, 1]))
                {
                    m[transactions[i, 1]] = 0;
                }

                m[transactions[i, 1]] += transactions[i, 2];
            }

            return MinTransfers(m.Values.ToArray(), 0, 0);
        }
        private int MinTransfers(int[] accnt, int start, int txNumber)
        {
            if (start >= accnt.Length)
            {
                return txNumber;
            }

            int res = int.MaxValue;
            if (accnt[start] == 0)
            {
                res = MinTransfers(accnt, start + 1, txNumber);
            }
            else
            {
                for (int i = start + 1; i < accnt.Length; ++i)
                {
                    if ((accnt[i] < 0 && accnt[start] > 0) || (accnt[i] > 0 && accnt[start] < 0))
                    {
                        accnt[i] += accnt[start];
                        res = Math.Min(res, MinTransfers(accnt, start + 1, txNumber + 1));
                        accnt[i] -= accnt[start];
                    }
                }
            }

            return res;
        }
    };
}
