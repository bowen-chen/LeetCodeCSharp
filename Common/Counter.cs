using System;
using System.Threading;

namespace Demo.Common
{
    public class Counter
    {
        private int curIndex=0;
        private long curTime;
        private int windowsSize = 60;
        private int[] data;
        private int total = 0;

        public Counter ()
        {
            data = new int[windowsSize];
        }

        public void Increment()
        {
            Ensure(true);
        }

        public int Total
        {
            get
            {
                Ensure(false);
                return total;
            }
        }

        private void Ensure(bool increment)
        {
            long nowTime = DateTime.Now.Ticks/10000000;
            int index = (int)(nowTime % windowsSize);
            if (nowTime > curTime)
            {
                lock (data)
                {
                    while (index != curIndex)
                    {
                        curIndex = ++curIndex % windowsSize;
                        Interlocked.Add(ref total, -data[curIndex]);
                        data[curIndex] = 0;
                    }
                    
                    curTime = nowTime;
                }
            }

            if (increment)
            {
                Interlocked.Increment(ref data[index]);
                Interlocked.Increment(ref total);
            }
        }
    }
}
