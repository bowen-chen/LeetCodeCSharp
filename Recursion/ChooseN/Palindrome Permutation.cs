/*
266	Palindrome Permutation
easy
Given a string, determine if a permutation of the string could form a palindrome.

For example,
"code" -> False, "aab" -> True, "carerac" -> True.

Hint:

Consider the palindromes of odd vs even length. What difference do you notice?
Count the frequency of each character.
If each character occurs even number of times, then it must be a palindrome. How about character which occurs odd number of times?
*/
namespace Demo
{
    public partial class Solution
    {
        // count odd
        public bool CanPermutePalindrome(string s)
        {
            int odd = 0;
            var counts = new int[256];
            foreach (char c in s)
            {
                odd += ++counts[c] % 2 == 1 ? 1 : -1;
            }

            return odd <= 1;
        }
    }
}
