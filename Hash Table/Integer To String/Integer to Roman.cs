/*
12	Integer to Roman	
medium, math
Given an integer, convert it to a roman numeral.

Input is guaranteed to be within the range from 1 to 3999.
*/

namespace Demo
{
    public partial class Solution
    {
        public string IntToRoman(int num)
        {
            var m = new[] {"", "M", "MM", "MMM"};
            var c = new[] {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};
            var x = new[] {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};
            var i = new[] {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};
            return m[num/1000] + c[(num%1000)/100] + x[(num%100)/10] + i[num%10];
        }
    }
}
