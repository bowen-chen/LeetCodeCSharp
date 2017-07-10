/*
307	Range Sum Query - Mutable 
hard, binary index tree
Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.

The update(i, val) function modifies nums by updating the element at index i to val.
Example:
Given nums = [1, 3, 5]

sumRange(0, 2) -> 9
update(1, 2)
sumRange(0, 2) -> 8
Note:
The array is only modifiable by the update function.
You may assume the number of calls to update and sumRange function is distributed evenly.
*/

using System;
using System.Linq;

namespace Demo
{
    // Your NumArray object will be instantiated and called as such:
    // NumArray numArray = new NumArray(nums);
    // numArray.SumRange(0, 1);
    // numArray.Update(1, 10);
    // numArray.SumRange(1, 2);

    public partial class Solution
    {
        public void Test_NumArray()
        {
            var n = new NumArray(new [] {1, 3, 5});
            n.Print();
            n.Update(1,2);
            n.Print();
            n.SumRange(0, 2);
        }
    }

    public class NumArray
    {
        // level3 :       4
        // level2 :   2       6
        // level1 : 1   3   5   7
        // tree   : 1 2 3 4 5 6 7
        // nums   : 0 1 2 3 4 5 6

        // for each tree node, we save its num plus sum of left subtree
        // ti&(-ti) is the last bit 1
        // When update a node, we travel up from left tree. ti+=ti&(-ti)
        // When sum a rang, we travel up from right tree. ti-=ti&(-ti)

        // Binary index tree
        int[] tree;
        int[] nums;
        int size;
        public NumArray(int[] nums)
        {
            this.size = nums.Length;
            this.tree = new int[size + 1];
            this.nums = new int[size];
            for (int i = 0; i < size; i++)
            {
                Update(i, nums[i]);
            }
        }
        
        public void Update(int i, int val)
        {
            int delta = val - nums[i];
            nums[i] = val;
            for (int ti = i + 1; ti <=size; ti += ti & (-ti))
            {
                tree[i] += delta;
            }
        }

        public void Print()
        {
            Console.WriteLine("Nums : {0}", string.Join(" ,", nums.Select(n=>n.ToString())));
            Console.WriteLine("Tree : {0}", string.Join(" ,", tree.Select(n => n.ToString())));
        }

        //c[1101] = tree[1101] + tree[1100] + tree[1000]
        public int Sum(int i)
        {
            int sum = 0;
            for (int ti = i + 1; ti >= 1; ti -= ti & (-ti))
            {
                sum += tree[ti];
            }
            return sum;
        }

        public int SumRange(int i, int j)
        {
            if (i == 0) return Sum(j);
            return Sum(j) - Sum(i - 1);
        }
    }
}
