/*
535. Encode and Decode TinyURL
Note: This is a companion problem to the System Design problem: Design TinyURL.
TinyURL is a URL shortening service where you enter a URL such as https://leetcode.com/problems/design-tinyurl and it returns a short URL such as http://tinyurl.com/4e9iAk.

Design the encode and decode methods for the TinyURL service. There is no restriction on how your encode/decode algorithm should work. You just need to ensure that a URL can be encoded to a tiny URL and the tiny URL can be decoded to the original URL.
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Demo
{
    public class Codec3
    {
        private const string dict = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly Dictionary<int, string> storage = new Dictionary<int, string>();

        private readonly Dictionary<char, int> idLookup = new Dictionary<char, int>();

        public Codec3()
        {
            for (int i = 0; i < dict.Length; i++)
            {
                idLookup[dict[i]] = i;
            }
        }

        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            int id = Math.Abs(longUrl.GetHashCode());
            while (storage.ContainsKey(id))
            {
                id++;
            }
            storage[id] = longUrl;
            string res = "";
            while (id!=0)
            {
                res = dict[id%dict.Length] + res;
                id = id/dict.Length;
            }
            return res;
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            string idStr = shortUrl.Substring(shortUrl.LastIndexOf("/") + 1);
            int id = 0;
            foreach (char c in idStr)
            {
                id = id*dict.Length + idLookup[c];
            }
            return storage.ContainsKey(id) ? storage[id] : shortUrl;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.decode(codec.encode(url));
}
