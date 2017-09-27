/*
551. Student Attendance Record I
*
You are given a string representing an attendance record for a student. The record only contains the following three characters:

'A' : Absent.
'L' : Late.
'P' : Present.
A student could be rewarded if his attendance record doesn't contain more than one 'A' (absent) or more than two continuous 'L' (late).

You need to return whether the student could be rewarded according to his attendance record.

Example 1:
Input: "PPALLP"
Output: True
Example 2:
Input: "PPALLL"
Output: False
*/

namespace Demo
{
    public partial class Solution
    {
        public bool CheckRecord(string s)
        {
            int cntA = 0;
            int cntL = 0;
            foreach (char c in s)
            {
                if (c == 'A')
                {
                    if (++cntA > 1)
                    {
                        return false;
                    }

                    cntL = 0;
                }
                else if (c == 'L')
                {
                    if (++cntL > 2)
                    {
                        return false;
                    }
                }
                else
                {
                    cntL = 0;
                }
            }

            return true;
        }
    }
}
