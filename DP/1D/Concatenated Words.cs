/*
472. Concatenated Words
*
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
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }

                int len = word.Length;
                var dp = new bool[len+1];
                dp[0] = true;

                // dp[i], substring(0, i) can be construct from dic.
                for (int i = 1; i <= len; ++i)
                {
                    for (int j = 0; j < i; ++j)
                    {
                        if (j == 0 && i == len)
                        {
                            continue;
                        }

                        if (dp[j] && dic.Contains(word.Substring(j, i - j)))
                        {
                            dp[i] = true;
                            break;
                        }
                    }
                }

                if (dp[len])
                {
                    res.Add(word);
                }
            }

            return res;
        }
    }
}
