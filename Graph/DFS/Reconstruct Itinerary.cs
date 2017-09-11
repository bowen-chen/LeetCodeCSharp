/*
332	Reconstruct Itinerary
medium, recursion, *
Given a list of airline tickets represented by pairs of departure and arrival airports [from, to], reconstruct the itinerary in order. All of the tickets belong to a man who departs from JFK. Thus, the itinerary must begin with JFK.

Note:
If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string. For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
All airports are represented by three capital letters (IATA code).
You may assume all tickets may form at least one valid itinerary.
Example 1:
tickets = [["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
Return ["JFK", "MUC", "LHR", "SFO", "SJC"].
Example 2:
tickets = [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
Return ["JFK","ATL","JFK","SFO","ATL","SFO"].
Another possible reconstruction is ["JFK","SFO","ATL","JFK","ATL","SFO"]. But it is larger in lexical order.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> FindItinerary(string[,] tickets)
        {
            // from to tickets
            var t = new Dictionary<string, List<int>>();
            for (int i = 0; i < tickets.GetLength(0); i++)
            {
                if (!t.ContainsKey(tickets[i, 0]))
                {
                    t.Add(tickets[i, 0], new List<int> {i});
                }
                else
                {
                    t[tickets[i, 0]].Add(i);
                }
            }

            foreach (string key in t.Keys)
            {
                t[key].Sort((i1, i2) => tickets[i1, 1].CompareTo(tickets[i2, 1])); /*lexical order*/
            }

            var ret = new List<string> { "JFK" };
            var usedTicket = new HashSet<int>();
            FindItinerary(t, usedTicket, tickets,  ret);
            return ret;
        }

        private bool FindItinerary(Dictionary<string, List<int>> t, HashSet<int> usedTicket, string[,] tickets, List<string> ret)
        {
            if (ret.Count == tickets.GetLength(0) + 1)
            {
                return true;
            }

            string whereami = ret[ret.Count - 1];
            if (t.ContainsKey(whereami))
            {
                foreach (var i in t[whereami])
                {
                    if (!usedTicket.Contains(i))
                    {
                        usedTicket.Add(i);
                        ret.Add(tickets[i, 1]);
                        if (FindItinerary(t, usedTicket, tickets, ret))
                        {
                            return true;
                        }

                        usedTicket.Remove(i);
                        ret.RemoveAt(ret.Count - 1);
                    }
                }
            }

            return false;
        }
    }
}
