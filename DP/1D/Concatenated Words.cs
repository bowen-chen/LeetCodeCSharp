/*
472. Concatenated Words
Given a list of words (without duplicates), please write a program that returns all concatenated words in the given list of words.

A concatenated word is defined as a string that is comprised entirely of at least two shorter words in the given array.

Example:
Input: ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]

Output: ["catsdogcats","dogcatsdog","ratcatdogcat"]

Explanation: "catsdogcats" can be concatenated by "cats", "dog" and "cats"; 
 "dogcatsdog" can be concatenated by "dog", "cats" and "dog"; 
"ratcatdogcat" can be concatenated by "rat", "cat", "dog" and "cat".
Note:
The number of elements of the given array will not exceed 10,000
The length sum of elements in the given array will not exceed 600,000.
All the input string will only include lower case letters.
The returned elements order does not matter.

*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            var res = new List<string>();
            var dic = new HashSet<string>(words);

            foreach (string word in words)
            {
                int len = word.Length;
                var dp = new bool[len];

                // dp[i], [0,i] can be construct from dic.
                for (int i = 0; i < len; i++)
                {
                    if (i - 1 >= 0 && !dp[i - 1])
                    {
                        continue;
                    }

                    for (int j = i; j < len; j++)
                    {
                        // same word
                        if (i == 0 && j == len - 1)
                        {
                            continue;
                        }

                        if (!dp[j] && dic.Contains(word.Substring(i, j - i + 1)))
                        {
                            dp[j] = true;
                        }
                    }

                    if (dp[len - 1])
                    {
                        res.Add(word);
                        break;
                    }
                }
            }
            return res;
        }
    }
}
