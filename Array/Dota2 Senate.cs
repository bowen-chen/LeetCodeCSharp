/*
649. Dota2 Senate
In the world of Dota2, there are two parties: the Radiant and the Dire.

The Dota2 senate consists of senators coming from two parties. Now the senate wants to make a decision about a change in the Dota2 game. The voting for this change is a round-based procedure. In each round, each senator can exercise one of the two rights:

Ban one senator's right: 
A senator can make another senator lose all his rights in this and all the following rounds.
Announce the victory: 
If this senator found the senators who still have rights to vote are all from the same party, he can announce the victory and make the decision about the change in the game.
Given a string representing each senator's party belonging. The character 'R' and 'D' represent the Radiant party and the Dire party respectively. Then if there are n senators, the size of the given string will be n.

The round-based procedure starts from the first senator to the last senator in the given order. This procedure will last until the end of voting. All the senators who have lost their rights will be skipped during the procedure.

Suppose every senator is smart enough and will play the best strategy for his own party, you need to predict which party will finally announce the victory and make the change in the Dota2 game. The output should be Radiant or Dire.

Example 1:
Input: "RD"
Output: "Radiant"
Explanation: The first senator comes from Radiant and he can just ban the next senator's right in the round 1. 
And the second senator can't exercise any rights any more since his right has been banned. 
And in the round 2, the first senator can just announce the victory since he is the only guy in the senate who can vote.
Example 2:
Input: "RDD"
Output: "Dire"
Explanation: 
The first senator comes from Radiant and he can just ban the next senator's right in the round 1. 
And the second senator can't exercise any rights anymore since his right has been banned. 
And the third senator comes from Dire and he can ban the first senator's right in the round 1. 
And in the round 2, the third senator can just announce the victory since he is the only guy in the senate who can vote.
Note:
The length of the given string will in the range [1, 10,000].
*/

namespace Demo
{
    public partial class Solution
    {
        public string PredictPartyVictory(string senate)
        {
            bool[] skipped = new bool[senate.Length];
            int[] kill = new int[2];
            int[] count = new int[2];

            foreach (var ch in senate)
            {
                if (ch == 'D') count[0]++;
                else count[1]++;
            }

            for (int i = 0; true; i = i + 1 >= senate.Length ? 0 : i + 1)
            {
                if (count[0] == 0) return "Radiant";
                if (count[1] == 0) return "Dire";

                if (skipped[i]) continue;

                var ch = senate[i];
                int party = ch == 'D' ? 0 : 1;
                if (kill[party] > 0)
                {
                    skipped[i] = true;
                    kill[party]--;
                    continue;
                }

                kill[1 - party]++;
                count[1 - party]--;
            }
        }

        public string PredictPartyVictory2(string senate)
        {
            var buffer = senate.ToCharArray();
            int i = 0;

            do
            {
                bool ban = false;
                for (int j = 1; j < buffer.Length; j++)
                {
                    int index = (j + i)%buffer.Length;
                    if (buffer[index] != 'B'&&buffer[index] != buffer[i])
                    {
                        buffer[index] = 'B';
                        ban = true;
                        break;
                    }
                }
                if (!ban)
                {
                    break;
                }
                do
                {
                    i++;
                    i = i%buffer.Length;
                } while (buffer[i] == 'B');
            } while (true);

            return buffer[i] == 'R' ? "Radiant" : "Dire";
        }
    }
}
