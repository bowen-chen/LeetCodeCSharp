/*
381. Insert Delete GetRandom O(1) - Duplicates allowed
Design a data structure that supports all following operations in average O(1) time.

Note: Duplicate elements are allowed.
insert(val): Inserts an item val to the collection.
remove(val): Removes an item val from the collection if present.
getRandom: Returns a random element from current collection of elements. The probability of each element being returned is linearly related to the number of same value the collection contains.
Example:

// Init an empty collection.
RandomizedCollection collection = new RandomizedCollection();

// Inserts 1 to the collection. Returns true as the collection did not contain 1.
collection.insert(1);

// Inserts another 1 to the collection. Returns false as the collection contained 1. Collection now contains [1,1].
collection.insert(1);

// Inserts 2 to the collection, returns true. Collection now contains [1,1,2].
collection.insert(2);

// getRandom should return 1 with the probability 2/3, and returns 2 with the probability 1/3.
collection.getRandom();

// Removes 1 from the collection, returns true. Collection now contains [1,2].
collection.remove(1);

// getRandom should return 1 and 2 both equally likely.
collection.getRandom();
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class RandomizedCollection
    {
        // value to index
        private readonly Dictionary<int, List<int>> _valueToIndex = new Dictionary<int, List<int>>();

        // values <value, index in the _valueToIndex list>
        private readonly List<Tuple<int, int>> _nums = new List<Tuple<int, int>>();
        private readonly Random _random = new Random();

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            bool ret = false;
            if (!_valueToIndex.ContainsKey(val))
            {
                ret = true;
                _valueToIndex[val] = new List<int>();
            }
            
            _valueToIndex[val].Add(_nums.Count);
            _nums.Add(Tuple.Create(val, _valueToIndex[val].Count - 1));
            return ret;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!_valueToIndex.ContainsKey(val))
            {
                return false;
            }

            var last = _nums[_nums.Count - 1];
            int valueIndexToRemove = _valueToIndex[val][_valueToIndex[val].Count - 1];
            _valueToIndex[last.Item1][last.Item2] = valueIndexToRemove;
            _nums[valueIndexToRemove] = last;
            _nums.RemoveAt(_nums.Count - 1);
            _valueToIndex[val].RemoveAt(_valueToIndex[val].Count -1);
            if (_valueToIndex[val].Count == 0)
            {
                _valueToIndex.Remove(val);
            }

            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return _nums[_random.Next(_nums.Count)].Item1;
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */

    public class RandomizedCollection2
    {
        public List<int> list = new List<int>();
        public Dictionary<int, HashSet<int>> valueToIndex = new Dictionary<int, HashSet<int>>();
        private readonly Random _random = new Random();

        /** Initialize your data structure here. */
        public RandomizedCollection2()
        {

        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (!valueToIndex.ContainsKey(val))
            {
                valueToIndex[val] = new HashSet<int>();
            }

            list.Add(val);
            valueToIndex[val].Add(list.Count - 1);
            return valueToIndex[val].Count == 1;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */

        public bool Remove(int val)
        {
            if (!valueToIndex.ContainsKey(val))
            {
                return false;
            }

            int index = valueToIndex[val].First();
            valueToIndex[val].Remove(index);

            valueToIndex[list[list.Count - 1]].Add(index);
            valueToIndex[list[list.Count - 1]].Remove(list.Count - 1);
            list[index] = list[list.Count - 1];

            list.RemoveAt(list.Count - 1);
            if (valueToIndex[val].Count == 0)
            {
                valueToIndex.Remove(val);
            }

            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            if (list.Count == 0)
            {
                return 0;
            }
            int r = _random.Next(list.Count);
            return list[r];
        }
    }
}
