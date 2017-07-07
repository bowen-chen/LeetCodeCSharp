/*
401. Binary Watch
A binary watch has 4 LEDs on the top which represent the hours (0-11), and the 6 LEDs on the bottom represent the minutes (0-59).

Each LED represents a zero or one, with the least significant bit on the right.


For example, the above binary watch reads "3:25".

Given a non-negative integer n which represents the number of LEDs that are currently on, return all possible times the watch could represent.

Example:

Input: n = 1
Return: ["1:00", "2:00", "4:00", "8:00", "0:01", "0:02", "0:04", "0:08", "0:16", "0:32"]
Note:
The order of output does not matter.
The hour must not contain a leading zero, for example "01:00" is not valid, it should be "1:00".
The minute must be consist of two digits and may contain a leading zero, for example "10:2" is not valid, it should be "10:02".
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> ReadBinaryWatch(int num)
        {
            var ret = new List<string>();
            ReadBinaryWatch(num, ret, 0, 0);
            return ret;
        }

        public void ReadBinaryWatch(int num, IList<string> ret, int current, int currentindex)
        {
            if (num == 0)
            {
                ret.Add(string.Format("{0}:{1:d2}", current >> 6, current & 0x3f));
                return;
            }

            if (num > 10 - currentindex || currentindex >= 10)
            {
                return;
            }

            // choose
            var next = current | (1 << currentindex);
            if ((next >> 6) <= 11 && (next & 63) <= 59)
            {
                ReadBinaryWatch(num - 1, ret, next, currentindex + 1);
            }

            // not choose
            ReadBinaryWatch(num, ret, current, currentindex + 1);
        }
    }
}
