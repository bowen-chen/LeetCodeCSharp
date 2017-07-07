/*
379 Design Phone Directory
Design a Phone Directory which supports the following operations:

get: Provide a number which is not assigned to anyone.
check: Check if a number is available or not.
release: Recycle or release a number.
Example:

// Init a phone directory containing a total of 3 numbers: 0, 1, and 2.
PhoneDirectory directory = new PhoneDirectory(3);

// It can return any available phone number. Here we assume it returns 0.
directory.get();

// Assume it returns 1.
directory.get();

// The number 2 is available, so return true.
directory.check(2);

// It returns 2, the only number that is left.
directory.get();

// The number 2 is no longer available, so return false.
directory.check(2);

// Release number 2 back to the pool.
directory.release(2);

// Number 2 is available again, return true.
directory.check(2);
*/

using System.Collections.Generic;

namespace Demo
{
    public class PhoneDirectory
    {
        private readonly int _max;
        private readonly HashSet<int> _used = new HashSet<int>();
        private readonly Queue<int> _released = new Queue<int>();

        private int _next;

        /** Initialize your data structure here
            @param maxNumbers - The maximum numbers that can be stored in the phone directory. */
        public PhoneDirectory(int maxNumbers)
        {
            _next = 0;
            _max = maxNumbers - 1;
        }

        /** Provide a number which is not assigned to anyone.
            @return - Return an available number. Return -1 if none is available. */
        public int Get()
        {
            if (_released.Count > 0)
            {
                int ret = _released.Dequeue();
                _used.Add(ret);
                return ret;
            }

            if (_next <= _max)
            {
                int ret = _next++;
                _used.Add(ret);
                return ret;
            }

            return -1;
        }

        /** Check if a number is available or not. */
        public bool Check(int number)
        {
            return !_used.Contains(number) && number <= _max;
        }

        /** Recycle or release a number. */
        public void Release(int number)
        {
            if (_used.Contains(number))
            {
                _used.Remove(number);
                _released.Enqueue(number);
            }
        }
    }
}
