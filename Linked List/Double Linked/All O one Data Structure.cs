/*
432. All O`one Data Structure
Implement a data structure supporting the following operations:

Inc(Key) - Inserts a new key with value 1. Or increments an existing key by 1. Key is guaranteed to be a non-empty string.
Dec(Key) - If Key's value is 1, remove it from the data structure. Otherwise decrements an existing key by 1. If the key does not exist, this function does nothing. Key is guaranteed to be a non-empty string.
GetMaxKey() - Returns one of the keys with maximal value. If no element exists, return an empty string "".
GetMinKey() - Returns one of the keys with minimal value. If no element exists, return an empty string "".
Challenge: Perform all these in O(1) time complexity.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class AllOne
    {
        // maintain a doubly linked list of Buckets
        private readonly Bucket _head;

        // for accessing a specific Bucket among the Bucket list in O(1) time
        private readonly Dictionary<int, Bucket> _countBucketMap = new Dictionary<int, Bucket>();

        // keep track of count of keys
        private readonly Dictionary<string, int> _keyCountMap = new Dictionary<string, int>();

        // each Bucket contains all the keys with the same count
        private class Bucket
        {
            public HashSet<string> KeySet { get; }

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
            _head.Pre = _head;
            _head.Next = _head;
        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {   
            if (!_keyCountMap.ContainsKey(key))
            {
                _keyCountMap[key] = 0;
            }

            int count = ++_keyCountMap[key];

            // add to count bucket
            Bucket fromBucket = count == 1 ? _head : _countBucketMap[count - 1];
            Bucket toBucket;
            if (!_countBucketMap.ContainsKey(count))
            {
                toBucket = new Bucket();
                toBucket.Pre = fromBucket;
                toBucket.Next = fromBucket.Next;
                fromBucket.Next.Pre = toBucket;
                fromBucket.Next = toBucket;
                _countBucketMap[count] = toBucket;
            }
            else
            {
                toBucket = _countBucketMap[count];
            }

            toBucket.KeySet.Add(key);

            // remove from count - 1 frombucket
            if (fromBucket != _head)
            {
                fromBucket.KeySet.Remove(key);
                if (fromBucket.KeySet.Count == 0)
                {
                    _countBucketMap.Remove(count - 1);
                    fromBucket.Next.Pre = fromBucket.Pre;
                    fromBucket.Pre.Next = fromBucket.Next;
                }
            }
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (_keyCountMap.ContainsKey(key))
            {
                int count = --_keyCountMap[key];
                if (count == 0)
                {
                    _keyCountMap.Remove(key);
                }

                // add to count bucket
                Bucket fromBucket = _countBucketMap[count + 1];
                Bucket toBucket;
                if (!_countBucketMap.ContainsKey(count))
                {
                    if (count != 0)
                    {
                        toBucket = new Bucket();
                        toBucket.Next = fromBucket;
                        toBucket.Pre = fromBucket.Pre;
                        fromBucket.Pre.Next = toBucket;
                        fromBucket.Pre = toBucket;
                        _countBucketMap[count] = toBucket;
                    }
                    else
                    {
                        toBucket = _head;
                    }
                }
                else
                {
                    toBucket = _countBucketMap[count];
                }

                toBucket.KeySet.Add(key);

                // remove from count + 1 bucket
                fromBucket.KeySet.Remove(key);
                if (fromBucket.KeySet.Count == 0)
                {
                    _countBucketMap.Remove(count + 1);
                    fromBucket.Next.Pre = fromBucket.Pre;
                    fromBucket.Pre.Next = fromBucket.Next;
                }
            }
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            return _head.Pre == _head ? "" : _head.Pre.KeySet.First();
        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
            return _head.Next == _head ? "" : _head.Next.KeySet.First();
        }

        public void Print()
        {
            var p = _head.Next;
            while (p != _head)
            {
                Console.Write(string.Join(", ", p.KeySet)+"->");
                p = p.Next;
            }

            Console.WriteLine();
        }

        static void Test()
        {
            var allone = new AllOne();
            allone.Inc("a");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
            allone.Inc("a");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
            allone.Inc("a");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
            allone.Inc("b");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
            allone.Inc("b");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
            allone.Dec("a");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
            allone.Dec("a");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
            allone.Dec("a");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
            allone.Dec("b");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
            allone.Dec("b");
            Console.WriteLine(allone.GetMaxKey());
            Console.WriteLine(allone.GetMinKey());
            allone.Print();
        }
    }
}
