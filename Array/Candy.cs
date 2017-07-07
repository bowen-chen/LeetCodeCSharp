/*
135	Candy
hard, math
There are N children standing in a line. Each child is assigned a rating value.

You are giving candies to these children subjected to the following requirements:

Each child must have at least one candy.
Children with a higher rating get more candies than their neighbors.
What is the minimum candies you must give?
*/

using System;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int Candy(int[] ratings)
        {
            if (ratings == null)
            {
                return 0;
            }

            int[] candy = new int[ratings.Length];
            candy[0] = 1;

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    candy[i] = candy[i - 1] + 1;
                }
                else
                {
                    candy[i] = 1;
                }
            }

            for (int i = ratings.Length - 1; i > 0; i--)
            {
                if (ratings[i - 1] > ratings[i])
                {
                    candy[i - 1] = Math.Max(candy[i] + 1, candy[i - 1]);
                }
            }

            return candy.Sum();
        }
    }
}
