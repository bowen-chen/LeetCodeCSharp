/*
The API: int read4(char *buf) reads 4 characters at a time from a file.
The return value is the actual number of characters read. For example, it returns 3 if there is only 3 characters left in the file.
By using the read4 API, implement the function int read(char *buf, int n) that reads n characters from the file.
Note:
The read function will only be called once for each test case.
*/
using System;
using System.IO;

namespace Demo
{
    public partial class Solution
    {
        public int Read4(Stream stream, byte[] buf, int offset)
        {
            return stream.Read(buf, offset, 4);
        }

        public int Read(Stream stream, byte[] buf, int n)
        {
            int len = 0;
            int m = 0;
            while (len + 4 <= n)
            {
                m = Read4(stream, buf, len);
                len += m;
                if (m < 4)
                {
                    break; // stream.Length < n
                }
            }

            if (len == n)
            {
                return len;
            }

            byte[] remain = new byte[4];
            m = Math.Min(Read4(stream, remain, 0), n - len);
            for (int i = 0; i < m; i++)
            {
                buf[len++] = remain[i];
            }

            return len;
        }
    }
}
