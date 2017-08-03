/*
604	Design Compressed String Iterator
Design and implement a data structure for a compressed string iterator. It should support the following operations: next and hasNext.

The given compressed string will be in the form of each letter followed by a positive integer representing the number of this letter existing in the original uncompressed string.

next() - if the original string still has uncompressed characters, return the next letter; Otherwise return a white space.
hasNext() - Judge whether there is any letter needs to be uncompressed.

Note:
Please remember to RESET your class variables declared in StringIterator, as static/class variables are persisted across multiple test cases. Please see here for more details.

Example:

StringIterator iterator = new StringIterator("L1e2t1C1o1d1e1");

iterator.next(); // return 'L'
iterator.next(); // return 'e'
iterator.next(); // return 'e'
iterator.next(); // return 't'
iterator.next(); // return 'C'
iterator.next(); // return 'o'
iterator.next(); // return 'd'
iterator.hasNext(); // return true
iterator.next(); // return 'e'
iterator.hasNext(); // return false
iterator.next(); // return ' '
*/

namespace Demo
{
    public class StringIterator
    {
        public StringIterator(string compressedString)
        {
            s = compressedString;
            i = 0;
            cnt = 0;
            c = ' ';
        }

        public char next()
        {
            if (hasNext())
            {
                --cnt;
                return c;
            }
            return ' ';
        }

        public bool hasNext()
        {
            if (cnt > 0)
            {
                return true;
            }

            if (i >= s.Length)
            {
                return false;
            }

            c = s[i++];
            while (i < s.Length && s[i] >= '0' && s[i] <= '9')
            {
                cnt = cnt*10 + (s[i++] - '0');
            }

            return true;
        }

        private readonly string s;
        private int i;
        private int cnt;
        private char c;
    };
}
