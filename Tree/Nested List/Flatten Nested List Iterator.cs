/*
341 Flatten Nested List Iterator
easy, tree, *
Given a nested list of integers, implement an iterator to flatten it.

Each element is either an integer, or a list -- whose elements may also be integers or other lists.

Example 1:
Given the list [[1,1],2,[1,1]],

By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1,1,2,1,1].

Example 2:
Given the list [1,[4,[6]]],

By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1,4,6].
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class NestedIterator
    {
        private readonly Stack<NestedInteger> _stack = new Stack<NestedInteger>();

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            foreach (var m in nestedList.Reverse())
            {
                _stack.Push(m);
            }
        }

        public bool HasNext()
        {
            while (_stack.Count > 0)
            {
                var m = _stack.Peek();
                if (m.IsInteger())
                {
                    return true;
                }

                _stack.Pop();
                foreach (var c in m.GetList().Reverse())
                {
                    _stack.Push(c);
                }
            }

            return false;
        }

        public int Next()
        {
            return _stack.Pop().GetInteger();
        }
    }
}
