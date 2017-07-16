/*
29	Divide Two Integers
medium math
Divide two integers without using multiplication, division and mod operator. 

If it is overflow, return MAX_INT. 
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void DivideTest()
        {
            Console.WriteLine("{0}/{1}={2}", 10, 3, Divide(10, 3));
            Console.WriteLine("{0}/{1}={2}", 10, 2, Divide(10, 2));
            Console.WriteLine("{0}/{1}={2}", 5, 2, Divide(5, 2));
            Console.WriteLine("{0}/{1}={2}", 8, 2, Divide(8, 2));
            Console.WriteLine("{0}/{1}={2}", 8, 1, Divide(8, 1));
            Console.WriteLine("{0}/{1}={2}", 9, 1, Divide(9, 1));
            Console.WriteLine("{0}/{1}={2}", 10, 10, Divide(10, 10));
            Console.WriteLine("{0}/{1}={2}", int.MaxValue, 1, Divide(int.MaxValue, 1));
            Console.WriteLine("{0}/{1}={2}", int.MinValue, 1, Divide(int.MinValue, 1));
            Console.WriteLine("{0}/{1}={2}", int.MaxValue, int.MaxValue, Divide(int.MaxValue, int.MaxValue));
            Console.WriteLine("{0}/{1}={2}", int.MaxValue, int.MinValue, Divide(int.MaxValue, int.MinValue));
            Console.WriteLine("{0}/{1}={2}", int.MinValue, int.MaxValue, Divide(int.MinValue, int.MaxValue));
            Console.WriteLine("{0}/{1}={2}", int.MinValue, int.MinValue, Divide(int.MinValue, int.MinValue));
        }

        public int Divide(int dividend, int divisor)
        {
            //Reduce the problem to positive long integer to make it easier.
            //Use long to avoid integer overflow cases.
            int sign = 1;
            if ((dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0))
            {
                sign = -1;
            }

            long ldividend = Math.Abs((long)dividend);
            long ldivisor = Math.Abs((long)divisor);

            //Take care the edge cases.
            if (ldivisor == 0)
            {
                return int.MaxValue;
            }

            if ((ldividend == 0) || (ldividend < ldivisor))
            {
                return 0;
            }

            long lans = ldivide(ldividend, ldivisor);

            int ret;
            if (lans > int.MaxValue)
            {
                //Handle overflow.
                ret = (sign == 1) ? int.MaxValue : int.MinValue;
            }
            else
            {
                ret = (int)(sign * lans);
            }
            return ret;
        }

        private long ldivide(long ldividend, long ldivisor)
        {
            // Recursion exit condition
            if (ldividend < ldivisor)
            {
                return 0;
            }

            //  Find the largest multiple so that (divisor * multiple <= dividend), 
            //  whereas we are moving with stride 1, 2, 4, 8, 16...2^n for performance reason.
            //  Think this as a binary search.
            long sum = ldivisor;
            long multiple = 1;
            while ((sum + sum) <= ldividend)
            {
                sum += sum;
                multiple += multiple;
            }

            //Look for additional value for the multiple from the reminder (dividend - sum) recursively.
            return multiple + ldivide(ldividend - sum, ldivisor);
        }
    }
}