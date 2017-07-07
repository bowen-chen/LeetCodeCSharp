using System;
using System.Collections.Generic;

namespace Demo
{
    public class NestedInteger
    {
        private int? _value;

        private readonly List<NestedInteger> _children = new List<NestedInteger>();

        // Constructor initializes an empty nested list.
        public NestedInteger()
        {
        }

        // Constructor initializes a single integer.
        public NestedInteger(int value)
            : this()
        {
            _value = value;
        }

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        public bool IsInteger()
        {
            return _value != null;
        }

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        public int GetInteger()
        {
            return _value.Value;
        }

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value)
        {
            _value = value;
            _children.Clear();
        }

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni)
        {
            _value = null;
            _children.Add(ni);
        }

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        public IList<NestedInteger> GetList()
        {
            if (_value != null)
            {
                return null;
            }

            return _children;
        }
    }
}
