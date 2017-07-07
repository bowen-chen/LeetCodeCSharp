/*
537. Complex Number Multiplication
Given two strings representing two complex numbers.

You need to return a string representing their multiplication. Note i2 = -1 according to the definition.

Example 1:
Input: "1+1i", "1+1i"
Output: "0+2i"
Explanation: (1 + i) * (1 + i) = 1 + i
2

 + 2 * i = 2i, and you need convert it to the form of 0+2i.
Example 2:
Input: "1+-1i", "1+-1i"
Output: "0+-2i"
Explanation: (1 - i) * (1 - i) = 1 + i
2

 - 2 * i = -2i, and you need convert it to the form of 0+-2i.
Note:

The input strings will not have extra blank.
The input strings will be given in the form of a+bi, where the integer a and b will both belong to the range of [-100, 100]. And the output should be also in this form.
*/

namespace Demo
{
    public partial class Solution
    {
        public string ComplexNumberMultiply(string a, string b)
        {
            int n1 = a.Length;
            int n2 = b.Length;
            int p1 = a.LastIndexOf("+");
            int p2 = b.LastIndexOf("+");
            int a1 = int.Parse(a.Substring(0, p1));
            int b1 = int.Parse(b.Substring(0, p2));
            int a2 = int.Parse(a.Substring(p1 + 1, n1 - p1 - 2));
            int b2 = int.Parse(b.Substring(p2 + 1, n2 - p2 - 2));
            int r1 = a1 * b1 - a2 * b2, r2 = a1 * b2 + a2 * b1;
            return r1 + "+" + r2 + "i";
        }
    }
}
