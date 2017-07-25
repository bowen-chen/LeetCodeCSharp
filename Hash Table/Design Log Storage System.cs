/*
635	Design Log Storage System
You are given several logs that each log contains a unique id and timestamp. Timestamp is a string that has the following format: Year:Month:Day:Hour:Minute:Second, for example, 2017:01:01:23:59:59. All domains are zero-padded decimal numbers.

Design a log storage system to implement the following functions:

void Put(int id, string timestamp): Given a log's unique id and timestamp, store the log in your storage system.

int[] Retrieve(String start, String end, String granularity): Return the id of logs whose timestamps are within the range from start to end. Start and end all have the same format as timestamp. However, granularity means the time level for consideration. For example, start = "2017:01:01:23:59:59", end = "2017:01:02:23:59:59", granularity = "Day", it means that we need to find the logs within the range from Jan. 1st 2017 to Jan. 2nd 2017.

Example 1:

put(1, "2017:01:01:23:59:59");
put(2, "2017:01:01:22:59:59");
put(3, "2016:01:01:00:00:00");
retrieve("2016:01:01:01:01:01","2017:01:01:23:00:00","Year"); // return [1,2,3], because you need to return all logs within 2016 and 2017.
retrieve("2016:01:01:01:01:01","2017:01:01:23:00:00","Hour"); // return [1,2], because you need to return all logs start from 2016:01:01:01 to 2017:01:01:23, where log 3 is left outside the range.
Note:

There will be at most 300 operations of Put or Retrieve.
Year ranges from [2000,2017]. Hour ranges from [00,23].
Output for Retrieve has no order required.
*/

using System.Collections.Generic;
using System.Xml;

namespace Demo.Hash_Table
{
    public class LogSystem
    {
        private readonly SortedList<long, int> map = new SortedList<long, int>();
        private static readonly string[] gras = "Year:Month:Day:Hour:Minute".Split(':');

        public void put(int id, string timestamp)
        {
            map.Add(GetKey(timestamp, "Second"), id);
        }

        public IList<int> retrieve(string s, string e, string gra)
        {
            long low = GetKey(s, gra);
            long high = GetKey(e, gra);
            var ans = new List<int>();
            foreach (var key in map.Keys)
            {
                if (low <= key)
                {
                    if (key <= high)
                    {
                        ans.Add(map[key]);
                    }
                }
            }

            return ans;
        }

        private long GetKey(string timestamp, string gra)
        {
            var tokens = timestamp.Split(':');
            long ret=0;
            bool trancate = false;
            for (int i=0;i < tokens.Length;i++)
            {
                int c = int.Parse(tokens[i]);
                switch (gras[i])
                {
                    case "Year":
                        ret += (c - 2000);
                        trancate = gra == "Year";
                        break;
                    case "Month":
                        ret *= 366;
                        ret += trancate ? 0 : c;
                        trancate = gra == "Month";
                        break;
                    case "Day":
                        ret *= 12;
                        ret += trancate ? 0 : c;
                        trancate = gra == "Day";
                        break;
                    case "Hour":
                        ret *= 24;
                        ret += trancate ? 0 : c;
                        trancate = gra == "Hour";
                        break;
                    case "Minute":
                        ret *= 60;
                        ret += trancate ? 0 : c;
                        trancate = gra == "Minute";
                        break;
                    case "Second":
                        ret *= 60;
                        ret += trancate ? 0 : c;
                        trancate = gra == "Second";
                        break;
                }
            }

            return ret;
        }

    }
}
