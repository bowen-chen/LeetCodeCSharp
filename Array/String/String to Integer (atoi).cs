/*
8. String to Integer (atoi)
easy, state machine
Implement atoi to convert a string to an integer.

Hint: Carefully consider all possible input cases.
If you want a challenge, please do not see below and ask yourself what are the possible input cases.

Notes: It is intended for this problem to be specified vaguely (ie, no given input specs).
You are responsible to gather all the input requirements up front. 
*/

using System;

namespace Demo.MyAtoi
{
    public class Solution
    {
        public void Test()
        {
            string input = "-1";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "1";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "0";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "+-2";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = " 00222";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = " 00222aa";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "11111111111111111";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "-11111111111111111";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "2147483647";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "-2147483648";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "2147483648";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "-2147483649";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "abc";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
            input = "10522545459";
            Console.WriteLine("{0} -> {1}", input, MyAtoi(input));
        }

        private enum S1Status
        {
            Start,
            Sign,
            Int,
            Done
        }

        public int MyAtoi(string str)
        {
            bool positive = true;
            int ret = 0;
            S1Status status = S1Status.Start;
            for (int i = 0; i < str.Length && status != S1Status.Done; i++)
            {
                char c = str[i];
                switch (status)
                {
                    case S1Status.Start:
                        if (c == ' ')
                        {
                            continue;
                        }
                        if (c == '-' || c == '+')
                        {
                            status = S1Status.Sign;
                            positive = c == '+';
                        }
                        else if (c >= '0' && c <= '9')
                        {
                            status = S1Status.Int;
                            ret = ret * 10 + c - '0';
                        }
                        else
                        {
                            return 0;
                        }
                        break;
                    case S1Status.Sign:
                        if (c >= '0' && c <= '9')
                        {
                            status = S1Status.Int;
                            ret = ret * 10 + c - '0';
                        }
                        else
                        {
                            return 0;
                        }
                        break;
                    case S1Status.Int:
                        if (c >= '0' && c <= '9')
                        {
                            int carry = c - '0';
                            long temp = (int.MaxValue - carry) / 10;
                            if (temp >= ret)
                            {
                                ret = ret * 10 + carry;
                            }
                            else
                            {
                                ret = positive ? int.MaxValue: int.MinValue;
                                status = S1Status.Done;
                            }
                        }
                        else
                        {
                            status = S1Status.Done;
                        }
                        break;
                }
            }
            return positive ? ret : -ret;
        }
    }
}
