/*
412	Fizz Buzz
easy, *
Write a program that outputs the string representation of numbers from 1 to n.

But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”. For numbers which are multiples of both three and five output “FizzBuzz”.

Example:

n = 15,

Return:
[
    "1",
    "2",
    "Fizz",
    "4",
    "Buzz",
    "Fizz",
    "7",
    "8",
    "Fizz",
    "Buzz",
    "11",
    "Fizz",
    "13",
    "14",
    "FizzBuzz"
]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> FizzBuzz(int n)
        {
            var res = new List<string>();
            for (int i = 1; i <= n; ++i)
            {
                if (i%15 == 0) res.Add("FizzBuzz");
                else if (i%3 == 0) res.Add("Fizz");
                else if (i%5 == 0) res.Add("Buzz");
                else res.Add(i.ToString());
            }

            return res;
        }
    }
}
