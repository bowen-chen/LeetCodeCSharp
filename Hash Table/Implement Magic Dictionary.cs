/*
676. Implement Magic Dictionary
Implement a magic directory with buildDict, and search methods.

For the method buildDict, you'll be given a list of non-repetitive words to build a dictionary.

For the method search, you'll be given a word, and judge whether if you modify exactly one character into another character in this word, the modified word is in the dictionary you just built.

Example 1:
Input: buildDict(["hello", "leetcode"]), Output: Null
Input: search("hello"), Output: False
Input: search("hhllo"), Output: True
Input: search("hell"), Output: False
Input: search("leetcoded"), Output: False
Note:
You may assume that all the inputs are consist of lowercase letters a-z.
For contest purpose, the test data is rather small by now. You could think about highly efficient algorithm after the contest.
Please remember to RESET your class variables declared in class MagicDictionary, as static/class variables are persisted across multiple test cases. Please see here for more details.
*/

using System.Collections.Generic;

namespace Demo
{
    public class MagicDictionary
    {
        private HashSet<string> s = new HashSet<string>();

        /** Initialize your data structure here. */
        public MagicDictionary()
        {

        }

        /** Build a dictionary through a list of words */
        public void BuildDict(string[] dict)
        {
            foreach (var w in dict)
            {
                s.Add(w);
            }
        }

        /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
        public bool Search(string word)
        {
            var cs = word.ToCharArray();
            for (int i = 0; i < cs.Length; i++)
            {
                var c = cs[i];
                for (char n = 'a'; n <= 'z'; n++)
                {
                    if (c == n)
                    {
                        continue;
                    }
                    cs[i] = n;
                    if (s.Contains(new string(cs)))
                    {
                        return true;
                    }
                }
                cs[i] = c;
            }
            return false;
        }
    }

    /**
     * Your MagicDictionary object will be instantiated and called as such:
     * MagicDictionary obj = new MagicDictionary();
     * obj.BuildDict(dict);
     * bool param_2 = obj.Search(word);
     */
}
