/*
155	Min Stack
easy
Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

push(x) -- Push element x onto stack.
pop() -- Removes the element on top of the stack.
top() -- Get the top element.
getMin() -- Retrieve the minimum element in the stack.
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public class MinStack
    {
        int _min = int.MaxValue;
        readonly Stack<Tuple<int,int>> _stack = new Stack<Tuple<int, int>>(); 
        public void Push(int x)
        {
            _stack.Push(Tuple.Create(x, _min));
            _min = Math.Min(x, _min);
        }

        public void Pop()
        {
            var v = _stack.Pop();
            _min = v.Item2;
        }

        public int Top()
        {
            return _stack.Peek().Item1;
        }

        public int GetMin()
        {
            return _min;
        }
    }
}
