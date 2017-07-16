/*
The API: int read4(char *buf) reads 4 characters at a time from a file.

The return value is the actual number of characters read. For example, it returns 3 if there is only 3 characters left in the file.

By using the read4 API, implement the function int read(char *buf, int n) that reads n characters from the file.

Note:
The read function may be called multiple times.
*/
using System;
using System.IO;

namespace Demo
{
    public partial class Solution
    {
        private int Read42(Stream stream, byte[] buf, int offset)
        {
            return stream.Read(buf, offset, 4);
        }

        private byte[] buffer = new byte[4];
        private int bufferLength = 0;
        private int current = 0;

        private int Read2(Stream stream, byte[] buf, int n)
        {

            int len = 0;
            int m = 0;
            for (int i = current; i < bufferLength; i++)
            {
                buf[len++] = buffer[i];
            }
            
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
            
            bufferLength = Read4(stream, buffer, 0);
            m = Math.Min(bufferLength, n - len);
            for (int i = 0; i < m; i++)
            {
                buf[len++] = buffer[i];
            }

            current = m;
            return len;
        }
    }
}
