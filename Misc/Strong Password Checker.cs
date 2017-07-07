﻿/*
420. Strong Password Checker
A password is considered strong if below conditions are all met:

It has at least 6 characters and at most 20 characters.
It must contain at least one lowercase letter, at least one uppercase letter, and at least one digit.
It must NOT contain three repeating characters in a row ("...aaa..." is weak, but "...aa...a..." is strong, assuming other conditions are met).
Write a function strongPasswordChecker(s), that takes a string s as input, and return the MINIMUM change required to make s a strong password. If s is already strong, return 0.

Insertion, deletion or replace of any one character are all considered as one change.
*/

using System;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int StrongPasswordChecker(string s)
        {
            int missing_type = 3;
            if (s.Any(c => c >= 'a' && c <= 'z'))
            {
                missing_type --;
            }

            if (s.Any(c => c >= 'A' && c <= 'Z'))
            {
                missing_type --;
            }

            if (s.Any(c => c >= '0' && c <= '9'))
            {
                missing_type --;
            }

            int change = 0; // the number of triple set of number
            int one = 0; // AAA,A can be solve by change times [replace] AABA or change-1 [replace] and 2 [delete] AA
            int two = 0; // AAA,AA can be solve by change times [replace]
            int three = 0; // AAA,AAA can be solve by change times [replace] AAB or change-1 replace and 1 delete AA;

            int p = 2;
            while (p < s.Length)
            {
                if (s[p] == s[p - 1] && s[p - 1] == s[p - 2])
                {
                    int length = 2;
                    while (p < s.Length && s[p] == s[p - 1])
                    {

                        length ++;
                        p ++;
                    }

                    change += length/3;
                    if (length%3 == 0)
                    {
                        three ++;
                    }
                    else if (length%3 == 1)
                    {
                        one ++;
                    }
                    else
                    {
                        two ++;
                    }
                }
                else
                {
                    p++;
                }
            }

            if (s.Length < 6)
            {
                // insert only
                return Math.Max(missing_type, 6 - s.Length);
            }

            if (s.Length <= 20)
            {
                // replace only
                return Math.Max(missing_type, change);
            }

            int deleteTotal = s.Length - 20;
            int remainingDelete = deleteTotal;

            // delete 1 from each three
            var delete = Math.Min(remainingDelete, three);
            change -= delete;
            remainingDelete -= delete;

            // delete 2 from each one
            if (remainingDelete > 0)
            {
                delete = Math.Min(remainingDelete, one*2);
                change -= delete/2;
                remainingDelete -= delete;
            }

            // delete 3 from each seq
            if (remainingDelete > 0)
            {
                delete = remainingDelete;
                change -= delete/3;
            }

            return deleteTotal + Math.Max(missing_type, change);
        }
    }
}