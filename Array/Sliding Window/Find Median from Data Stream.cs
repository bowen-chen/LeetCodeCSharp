/*
295	Find Median from Data Stream
easy
Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value. So the median is the mean of the two middle value.

Examples: 
[2,3,4] , the median is 3

[2,3], the median is (2 + 3) / 2 = 2.5

Design a data structure that supports the following two operations:

void addNum(int num) - Add a integer number from the data stream to the data structure.
double findMedian() - Return the median of all elements so far.
For example:

add(1)
add(2)
findMedian() -> 1.5
add(3) 
findMedian() -> 2
*/
using Demo.Common;

namespace Demo
{
    public partial class Solution
    {
        public void Test_MedianFinder()
        {
            var mf = new MedianFinder();
            mf.AddNum(-1);
            mf.AddNum(-2);
            mf.AddNum(-3);
        }
    }

    public class MedianFinder
    {
        // small.count >= large.count
        private readonly PriorityQueue<double> small = new PriorityQueue<double>();
        private readonly PriorityQueue<double> large = new PriorityQueue<double>();

        // Adds a num into the data structure.
        public void AddNum(double num)
        {
            large.Push(-num);
            small.Push(-large.Pop());

            // keep the small as n/2 or n/2 +1
            if (large.Count <= small.Count - 2)
            {
                large.Push(-small.Pop());
            }
        }

        // return the median of current data stream
        public double FindMedian()
        {
            return small.Count > large.Count
               ? small.Top()
               : (-large.Top() + small.Top()) / 2.0;
        }
    }
}
