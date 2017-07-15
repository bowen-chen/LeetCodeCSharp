/*
38	Count and Say
easy
The count-and-say sequence is the sequence of integers beginning as follows:
1, 11, 21, 1211, 111221, ... 

1 is read off as "one 1" or 11.
11 is read off as "two 1s" or 21.
21 is read off as "one 2, then one 1" or 1211.


Given an integer n, generate the nth sequence. 

Note: The sequence of integers will be represented as a string. 
*/

using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string CountAndSay(int n)
        {
            string pre = "1";
            for (int i = 2; i <= n; i++)
            {
                StringBuilder sb = new StringBuilder();
                char preChar = 'x'; // some char not match 0 - 9
                int count = 0;
                foreach (char curChar in pre)
                {
                    if (curChar == preChar)
                    {
                        count++;
                    }
                    else
                    {
                        if (count != 0)
                        {
                            sb.Append(count);
                            sb.Append(preChar);
                        }

                        count = 1;
                        preChar = curChar;
                    }
                }

                if (count != 0)
                {
                    sb.Append(count);
                    sb.Append(preChar);
                }

                pre = sb.ToString();
            }

            return pre;
        }
    }
}
