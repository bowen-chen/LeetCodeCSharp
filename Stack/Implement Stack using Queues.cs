/*
225	Implement Stack using Queues
easy
Implement Stack using Queues

Implement the following operations of a stack using queues.

push(x) -- Push element x onto stack.
pop() -- Removes the element on top of the stack.
top() -- Get the top element.
empty() -- Return whether the stack is empty.
Notes:
You must use only standard operations of a queue -- which means only push to back, peek/pop from front, size, and is empty operations are valid.
Depending on your language, queue may not be supported natively. You may simulate a queue by using a list or deque (double-ended queue), as long as you use only standard operations of a queue.
You may assume that all operations are valid (for example, no pop or top operations will be called on an empty stack).
*/

using System.Collections.Generic;

namespace Demo
{
    public class Stack
    {
        private readonly Queue<int> queue = new Queue<int>();

        // Push element x onto stack.
        public void Push(int x)
        {
            queue.Enqueue(x);
            for (int i = 1; i < queue.Count; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        // Removes the element on top of the stack.
        public void Pop()
        {
            queue.Dequeue();
        }

        // Get the top element.
        public int Top()
        {
            return queue.Peek();
        }

        // Return whether the stack is empty.
        public bool Empty()
        {
            return queue.Count == 0;
        }
    }
}
