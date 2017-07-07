/*
432. All O`one Data Structure
Implement a data structure supporting the following operations:

Inc(Key) - Inserts a new key with value 1. Or increments an existing key by 1. Key is guaranteed to be a non-empty string.
Dec(Key) - If Key's value is 1, remove it from the data structure. Otherwise decrements an existing key by 1. If the key does not exist, this function does nothing. Key is guaranteed to be a non-empty string.
GetMaxKey() - Returns one of the keys with maximal value. If no element exists, return an empty string "".
GetMinKey() - Returns one of the keys with minimal value. If no element exists, return an empty string "".
Challenge: Perform all these in O(1) time complexity.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class AllOne
    {
        // maintain a doubly linked list of Buckets
        private Bucket _head;
        private Bucket _tail;
        // for accessing a specific Bucket among the Bucket list in O(1) time
        private readonly Dictionary<int, Bucket> _countBucketMap = new Dictionary<int, Bucket>();
        // keep track of count of keys
        private readonly Dictionary<string, int> _keyCountMap = new Dictionary<string, int>();

        // each Bucket contains all the keys with the same count
        private class Bucket
        {
            public HashSet<string> KeySet { get;set; }
            public Bucket Next { get; set; }
            public Bucket Pre { get; set; }

            public Bucket()
            {
                KeySet = new HashSet<string>(); ;
            }
        }

        /** Initialize your data structure here. */
        public AllOne()
        {
            _head = new Bucket();
            _tail = _head;
            _head.Pre = _head;
            _tail.Next = _tail;
        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {   
            if (!_keyCountMap.ContainsKey(key))
            {
                _keyCountMap[key]=0;
            }

            _keyCountMap[key] ++;
            int count = _keyCountMap[key];
            ChangeKey(key, count-1, count);
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (_keyCountMap.ContainsKey(key))
            {
                _keyCountMap[key]--;
                int count = _keyCountMap[key];
                if (count == 0)
                {
                    _keyCountMap.Remove(key);
                }

                ChangeKey(key, count + 1, count);
            }
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            return _tail == _head ? "" : _tail.KeySet.First();
        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
            return _head == _tail ? "" : _head.KeySet.First();
        }

        // helper function to make change on given key according to offset
        private void ChangeKey(string key, int from, int to)
        {
            Bucket fromBucket;
            if (_countBucketMap.ContainsKey(from))
            {
                fromBucket = _countBucketMap[from];
                fromBucket.KeySet.Remove(key);
                if (fromBucket.KeySet.Count == 0)
                {
                    fromBucket.Next.Pre = fromBucket.Pre;
                    fromBucket.Pre.Next = fromBucket.Pre;
                    _countBucketMap.Remove(0);
                }
            }
            else
            {
                fromBucket = _head;
            }

            Bucket toBucket;
            if (!_countBucketMap.ContainsKey(to))
            {
                toBucket = new Bucket();
                toBucket.Pre = _head;
                toBucket.Next = fromBucket.Next;
                fromBucket.Next.Pre = toBucket;
                fromBucket.Next = toBucket;
                _countBucketMap[to] = toBucket;
            }
            else
            {
                toBucket = _countBucketMap[to];
            }
            toBucket.KeySet.Add(key);
        }
    }
}
