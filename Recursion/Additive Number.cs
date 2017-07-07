/*
306	Additive Number
easy, Recursion
Additive number is a string whose digits can form additive sequence.

A valid additive sequence should contain at least three numbers. Except for the first two numbers, each subsequent number in the sequence must be the sum of the preceding two.

For example:
"112358" is an additive number because the digits can form an additive sequence: 1, 1, 2, 3, 5, 8.

1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
"199100199" is also an additive number, the additive sequence is: 1, 99, 100, 199.
1 + 99 = 100, 99 + 100 = 199
Note: Numbers in the additive sequence cannot have leading zeros, so sequence 1, 2, 03 or 1, 02, 3 is invalid.

Given a string containing only digits '0'-'9', write a function to determine if it's an additive number.

Follow up:
How would you handle overflow for very large input integers?
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_IsAdditiveNumber()
        {
            Console.WriteLine(IsAdditiveNumber("199100199"));
            Console.WriteLine(IsAdditiveNumber("12012122436"));
            Console.WriteLine(IsAdditiveNumber("121474836472147483648"));
        }

        public bool IsAdditiveNumber2(string num)
        {
            int n = num.Length;
            // i first number length
            for (int i = 1; i <= n / 2; i++)
            {
                if (num[0] == '0' && i > 1)
                {
                    return false;
                }
                long x1 = long.Parse(num.Substring(0, i));
                // second number length
                for (int j = 1; Math.Max(j, i) <= n - i - j; j++)
                {
                    if (num[i] == '0' && j > 1)
                    {
                        break;
                    }
                    long x2 = long.Parse(num.Substring(i, i + j));
                    if (IsValid(x1, x2, num.Substring(i + j)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsValid(long x1, long x2, string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                return true;
            }
            long temp = x2;
            x2 = x2 + x1;
            x1 = temp;
            string sum = x2.ToString();
            return num.StartsWith(sum) && IsValid(x1, x2, num.Substring(sum.Length));
        }

        public bool IsAdditiveNumber(string num)
        {
            for (int i = 1; i <= num.Length; i++)
            {
                string substring = num.Substring(num.Length - i, i);
                if (substring.Length == 1 || !substring.StartsWith("0"))
                {
                    long sum;
                    try
                    {
                        sum = long.Parse(substring);
                    }
                    catch (OverflowException)
                    {
                        break;
                    }
                    if (IsAdditiveNumber(num.Substring(0, num.Length - substring.Length), -1, sum))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsAdditiveNumber(string num, long second, long sum)
        {
            if (second == -1)
            {
                for (int i = 1; i <= num.Length; i++)
                {
                    string substring = num.Substring(num.Length - i, i);
                    if (substring.Length == 1 || !substring.StartsWith("0"))
                    {
                        try
                        {
                            second = long.Parse(substring);
                        }
                        catch (OverflowException)
                        {
                            break;
                        }
                        if (IsAdditiveNumber(num.Substring(0, num.Length - substring.Length), second, sum))
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i <= num.Length; i++)
                {
                    string substring = num.Substring(num.Length - i, i);
                    if (substring.Length == 1 || !substring.StartsWith("0"))
                    {
                        long first;
                        try
                        {
                            first = long.Parse(substring);
                        }
                        catch (OverflowException)
                        {
                            break;
                        }
                        if (first + second == sum)
                        {
                            if (i == num.Length)
                            {
                                return true;
                            }
                            if (IsAdditiveNumber(num.Substring(0, num.Length - substring.Length), first, second))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
