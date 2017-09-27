/*
599. Minimum Index Sum of Two Lists
*
Suppose Andy and Doris want to choose a restaurant for dinner, and they both have a list of favorite restaurants represented by strings.

You need to help them find out their common interest with the least list index sum. If there is a choice tie between answers, output all of them with no order requirement. You could assume there always exists an answer.

Example 1:
Input:
["Shogun", "Tapioca Express", "Burger King", "KFC"]
["Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun"]
Output: ["Shogun"]
Explanation: The only restaurant they both like is "Shogun".
Example 2:
Input:
["Shogun", "Tapioca Express", "Burger King", "KFC"]
["KFC", "Shogun", "Burger King"]
Output: ["Shogun"]
Explanation: The restaurant they both like and have the least index sum is "Shogun" with index sum 1 (0+1).
Note:
The length of both lists will be in the range of [1, 1000].
The length of strings in both lists will be in the range of [1, 30].
The index is starting from 0 to the list length minus 1.
No duplicates in both lists.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            var m = new Dictionary<string, int>();
            for (int i = 0; i < list1.Length; ++i)
            {
                if (!m.ContainsKey(list1[i]))
                {
                    m[list1[i]] = i;
                }
            }

            var res = new List<string>();
            int mn = int.MaxValue;
            for (int i = 0; i < list2.Length; ++i)
            {
                if (m.ContainsKey(list2[i]))
                {
                    int sum = i + m[list2[i]];
                    if (sum == mn)
                    {
                        res.Add(list2[i]);
                    }
                    else if (sum < mn)
                    {
                        mn = sum;
                        res.Clear();
                        res.Add(list2[i]);
                    }
                }
            }

            return res.ToArray();
        }
    }
}
