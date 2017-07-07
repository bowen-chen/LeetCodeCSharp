/*
288	Unique Word Abbreviation $
easy
Problem Description:

An abbreviation of a word follows the form <first letter><number><last letter>. Below are some examples of word abbreviations:

a) it                      --> it    (no abbreviation)

     1
b) d|o|g                   --> d1g

              1    1  1
     1---5----0----5--8
c) i|nternationalizatio|n  --> i18n

              1
     1---5----0
d) l|ocalizatio|n          --> l10n
Assume you have a dictionary and given a word, find whether its abbreviation is unique in the dictionary. A word's abbreviation is unique if no other word from the dictionary has the same abbreviation.

Example: 

Given dictionary = [ "deer", "door", "cake", "card" ]

isUnique("dear") -> false
isUnique("cart") -> true
isUnique("cane") -> false
isUnique("make") -> true 
*/

using System.Collections.Generic;

namespace Demo
{
    public class ValidWordAbbr
    {
        Dictionary<string, string> map;
        public ValidWordAbbr(string[] dictionary)
        {
            map = new Dictionary<string, string>();
            foreach (string str in dictionary)
            {
                string key = GetKey(str);
                if (map.ContainsKey(key))
                {
                    if (map[key] != str)
                    {
                        // two words has same abbr
                        map[key] = "";
                    }
                }
                else
                {
                    map.Add(key, str);
                }
            }
        }

        public bool IsUnique(string word)
        {
            var key = GetKey(word);
            return !map.ContainsKey(key) || map[key] == word;
        }

        private string GetKey(string str)
        {
            if (str.Length <= 2)
            {
                return str;
            }
            return str[0] + (str.Length - 2).ToString() + str[str.Length - 1];
        }
    }
}
