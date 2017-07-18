/*
460	LFU Cache
Design and implement a data structure for Least Frequently Used (LFU) cache. It should support the following operations: get and put.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
put(key, value) - Set or insert the value if the key is not already present. When the cache reaches its capacity, it should invalidate the least frequently used item before inserting a new item. For the purpose of this problem, when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted.

Follow up:
Could you do both operations in O(1) time complexity?

Example:

LFUCache cache = new LFUCache( 2 / capacity / );

cache.put(1, 1);
cache.put(2, 2);
cache.get(1);       // returns 1
cache.put(3, 3);    // evicts key 2
cache.get(2);       // returns -1 (not found)
cache.get(3);       // returns 3.
cache.put(4, 4);    // evicts key 1.
cache.get(1);       // returns -1 (not found)
cache.get(3);       // returns 3
cache.get(4);       // returns 4
*/

using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Demo
{
    public class LFUCache
    {
        private int _minfreq;

        // key to node
        private readonly Dictionary<int, LinkedNode> _keyToNode = new Dictionary<int, LinkedNode>();

        // freq to node head, single linked loop list
        private readonly Dictionary<int, LinkedNode> _freqToHeadNode = new Dictionary<int, LinkedNode>();

        private readonly int _capacity;

        public LFUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            var node = GetLinkedNode(key);
            return node == null ? -1 : node.Val;
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0)
            {
                return;
            }

            // update
            var node = GetLinkedNode(key);
            if (node != null)
            {
                node.Val = value;
                return;
            }

            // add
            if (_keyToNode.Count == _capacity)
            {
                var head = _freqToHeadNode[_minfreq];
                var toDelete = head.Next;
                _keyToNode.Remove(toDelete.Key);
                head.Next = toDelete.Next;
                toDelete.Next.Pre = head;

                if (head.Pre == head)
                {
                    _freqToHeadNode.Remove(_minfreq);
                }
            }

            _minfreq = 1;
            node = new LinkedNode(key, value);
            _keyToNode[key] = node;
            AddLinkedNode(node);
        }

        private LinkedNode GetLinkedNode(int key)
        {
            if (!_keyToNode.ContainsKey(key))
            {
                return null;
            }

            var node = _keyToNode[key];
            node.Pre.Next = node.Next;
            node.Next.Pre = node.Pre;
            if (_freqToHeadNode[node.Freq].Pre == _freqToHeadNode[node.Freq])
            {
                _freqToHeadNode.Remove(node.Freq);
                if (node.Freq == _minfreq)
                {
                    // _minfreq++ is always valid, since node.Freq++ below
                    _minfreq++;
                }
            }

            node.Freq++;
            AddLinkedNode(node);
            return node;
        }

        private void AddLinkedNode(LinkedNode node)
        {
            LinkedNode head;
            if (!_freqToHeadNode.ContainsKey(node.Freq))
            {
                head = new LinkedNode(0,0);
                head.Pre = head;
                head.Next = head;
                _freqToHeadNode[node.Freq] = head;
            }
            else
            {
                head = _freqToHeadNode[node.Freq];
            }

            var tail = head.Pre;
            node.Pre = tail;
            node.Next = head;
            tail.Next = node;
            head.Pre = node;
        }

        private class LinkedNode
        {
            public int Key { get; private set; }

            public int Val { get; set; }

            public int Freq { get; set; }

            public LinkedNode(int key, int data)
            {
                Key = key;
                Val = data;
                Freq = 1;
            }

            public LinkedNode Pre { get; set; }

            public LinkedNode Next { get; set; }
        }
    }

    /**
     * Your LFUCache object will be instantiated and called as such:
     * LFUCache obj = new LFUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
