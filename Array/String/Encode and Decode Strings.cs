/*
271	Encode and Decode Strings
easy
Design an algorithm to encode a list of strings to a string. The encoded string is then sent over the network and is decoded back to the original list of strings.

Machine 1 (sender) has the function:

string encode(vector<string> strs) {
  // ... your code
  return encoded_string;
}
Machine 2 (receiver) has the function:

vector<string> decode(string s) {
  //... your code
  return strs;
} 
So Machine 1 does:

string encoded_string = encode(strs);
and Machine 2 does:

vector<string> strs2 = decode(encoded_string);
strs2 in Machine 2 should be the same as strs in Machine 1.

Implement the encode and decode methods.

Note:

The string may contain any possible characters out of 256 valid ascii characters. Your algorithm should be generalized enough to work on any possible characters.
Do not use class member/global/static variables to store states. Your encode and decode algorithms should be stateless.
Do not rely on any library method such as eval or serialize methods. You should implement your own encode/decode algorithm.
*/

using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public partial class Codec
    {
        // Encodes a list of strings to a single string.
        public string Encode(List<string> strs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in strs)
            {
                sb.Append(s.Length).Append('/').Append(s);
            }
            return sb.ToString();
        }

        // Decodes a single string to a list of strings.
        public List<string> Decode(string s)
        {
            List<string> ret = new List<string>();
            int i = 0;
            while (i < s.Length)
            {
                int slash = s.IndexOf('/', i);
                int size = int.Parse(s.Substring(i, slash));
                ret.Add(s.Substring(slash + 1, slash + size + 1));
                i = slash + size + 1;
            }
            return ret;
        }
    }
}
