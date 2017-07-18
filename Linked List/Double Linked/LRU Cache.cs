/*
146	LRU Cache   
medium, double linked link
Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and set.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
set(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void LRUCache_Test()
        {
            LRUCache c = new LRUCache(2);

            c.Set(2, 1);
            c.Set(3, 2);
            c.Get(3);
            c.Get(2);
            c.Set(4, 3);
            c.Get(2);
            c.Get(3);
            c.Get(4);

            c.Set(2, 1);
            c.Get(2);
            c.Set(3, 2);
            c.Get(2);
            c.Get(3);

            c.Set(2, 1);
            c.Get(2);

            for (int i = 0; i < 6; i++)
            {
                c.Set(i, i);
            }
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(c.Get(i));
            }

        }
    }

    public class LRUCache
    {
        private readonly Dictionary<int, LinkedNode> _keyToNode = new Dictionary<int, LinkedNode>();
        private readonly LinkedNode _head;
        private readonly int _capacity;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _head = new LinkedNode(0, 0);
            _head.Pre= _head;
            _head.Next = _head;
        }

        public int Get(int key)
        {
            var node = GetLinkedNode(key);
            return node == null ? -1 : node.Val;
        }

        private LinkedNode GetLinkedNode(int key)
        {
            if (!_keyToNode.ContainsKey(key))
            {
                return null;
            }

            LinkedNode node = _keyToNode[key];

            // move node to head
            if (node.Pre != _head)
            {
                node.Pre.Next = node.Next;
                node.Next.Pre = node.Pre;
                node.Next = _head.Next;
                node.Pre = _head;
                _head.Next.Pre = node;
                _head.Next = node;
            }

            return node;
        }

        public void Set(int key, int value)
        {
            LinkedNode node = GetLinkedNode(key);
            if (node != null)
            {
                node.Val = value;
                return;
            }
            
            node = new LinkedNode(key, value);
            _keyToNode[key] = node;

            node.Next = _head.Next;
            node.Pre = _head;
            _head.Next.Pre = node;
            _head.Next = node;

            if (_keyToNode.Count > _capacity && _head != _head.Pre)
            {
                var tail = _head.Pre;
                _keyToNode.Remove(tail.Key);
                tail.Pre.Next = tail.Next;
                tail.Next.Pre = tail.Pre;
            }
        }

        private class LinkedNode
        {
            public int Key { get; set; }

            public int Val { get; set; }

            public LinkedNode(int key, int data)
            {
                Key = key;
                Val = data;
            }

            public LinkedNode Pre { get; set; }

            public LinkedNode Next { get; set; }
        }
    }
}
