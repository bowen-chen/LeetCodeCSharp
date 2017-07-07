/*
346 Moving Average from Data Stream
easy
Given a stream of integers and a window size, calculate the moving average of all integers in the sliding window.

For example,
MovingAverage m = new MovingAverage(3);
m.next(1) = 1
m.next(10) = (1 + 10) / 2
m.next(3) = (1 + 10 + 3) / 3
m.next(5) = (10 + 3 + 5) / 3
*/

using System.Collections.Generic;

namespace Demo
{
    public class MovingAverage
    {
        public MovingAverage(int size)
        {
            this.size = size;
            sum = 0;
        }

        public double Next(int val)
        {
            if (q.Count >= size)
            {
                sum -= q.Dequeue();
            }
            q.Enqueue(val);
            sum += val;
            return sum / q.Count;
        }

        private readonly Queue<int> q = new Queue<int>();
        private readonly int size;
        private double sum;
    };
}
