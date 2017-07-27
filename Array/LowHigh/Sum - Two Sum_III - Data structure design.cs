/*
170	Two Sum III - Data structure design
Design and implement a TwoSum class. It should support the following operations: add and find.

add - Add the number to an internal data structure.
find - Find if there exists any pair of numbers which sum is equal to the value.

For example,
add(1); add(3); add(5);
find(4) -> true
find(7) -> false
*/

using System.Collections.Generic;

namespace Demo
{
    public class TwoSum
    {
        private readonly Dictionary<int, int> map = new Dictionary<int, int>();

        public void Add(int number)
        {
            if (!map.ContainsKey(number))
            {
                map[number] = 1;
            }
            else
            {
                map[number]++;
            }
        }

        public bool Find(int value)
        {
            foreach (var i in map.Keys)
            {
                int j = value - i;
                if ((i == j && map.ContainsKey(i) && map[i] > 1)
                    || (i != j && map.ContainsKey(j)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
