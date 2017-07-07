/*
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
        private readonly Dictionary<int, LinkedNode<int, int>> _map = new Dictionary<int, LinkedNode<int, int>>();
        private readonly LinkedNode<int, int> _head = new LinkedNode<int, int>(0, 0);
        private LinkedNode<int, int> _tail;
        private readonly int _capacity;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _tail = _head;
        }

        public int Get(int key)
        {
            var node = GetLinkedNode(key);
            return node != null ? node.Val : -1;
        }

        private LinkedNode<int, int> GetLinkedNode(int key)
        {
            if (!_map.ContainsKey(key))
            {
                return null;
            }

            LinkedNode<int, int> node = _map[key];

            // move node to head
            if (node.Pre != _head)
            {
                if (_tail == node)
                {
                    _tail = node.Pre;
                }

                if (node.Next != null)
                {
                    node.Next.Pre = node.Pre;
                }
                node.Pre.Next = node.Next;

                node.Next = _head.Next;
                node.Pre = _head;

                if (_head.Next != null)
                {
                    _head.Next.Pre = node;
                }
                _head.Next = node;
            }

            return node;
        }

        public void Set(int key, int value)
        {
            LinkedNode<int, int> node = GetLinkedNode(key);
            if (node != null)
            {
                node.Val = value;
            }
            else
            {
                node = new LinkedNode<int, int>(key, value);
                _map[key] = node;
                node.Next = _head.Next;
                node.Pre = _head;
                if (_head.Next != null)
                {
                    _head.Next.Pre = node;
                }
                _head.Next = node;
                if (_head == _tail)
                {
                    _tail = node;
                }

                if (_map.Count > _capacity && _head != _tail)
                {
                    _map.Remove(_tail.Key);
                    _tail = _tail.Pre;
                    _tail.Next.Pre = null;
                    _tail.Next = null;
                }
            }
        }

        private class LinkedNode<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Val { get; set; }

            public LinkedNode(TKey key, TValue data)
            {
                Key = key;
                Val = data;
            }

            public LinkedNode<TKey, TValue> Pre { get; set; }

            public LinkedNode<TKey, TValue> Next { get; set; }
        }
    }
}
