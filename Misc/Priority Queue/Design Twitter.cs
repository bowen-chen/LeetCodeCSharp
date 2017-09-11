/*
355. Design Twitter
easy, *
Design a simplified version of Twitter where users can post tweets, follow/unfollow another user and is able to see the 10 most recent tweets in the user's news feed. Your design should support the following methods:

postTweet(userId, tweetId): Compose a new tweet.
getNewsFeed(userId): Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent.
follow(followerId, followeeId): Follower follows a followee.
unfollow(followerId, followeeId): Follower unfollows a followee.
Example:

Twitter twitter = new Twitter();

// User 1 posts a new tweet (id = 5).
twitter.postTweet(1, 5);

// User 1's news feed should return a list with 1 tweet id -> [5].
twitter.getNewsFeed(1);

// User 1 follows user 2.
twitter.follow(1, 2);

// User 2 posts a new tweet (id = 6).
twitter.postTweet(2, 6);

// User 1's news feed should return a list with 2 tweet ids -> [6, 5].
// Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
twitter.getNewsFeed(1);

// User 1 unfollows user 2.
twitter.unfollow(1, 2);

// User 1's news feed should return a list with 1 tweet id -> [5],
// since user 1 is no longer following user 2.
twitter.getNewsFeed(1);
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Common;

namespace Demo
{
    public class Twitter
    {
        private int _index = 0;
        private readonly Dictionary<int, List<Tuple<int, int>>> _userToPost = new Dictionary<int, List<Tuple<int, int>>>();
        private readonly Dictionary<int, HashSet<int>> _userToFollowees = new Dictionary<int, HashSet<int>>();  
        
        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            EnsureUserExists(userId);
            _userToPost[userId].Add(Tuple.Create(_index++, tweetId));
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            EnsureUserExists(userId);
            var q = new PriorityQueue<Tuple<int, int>>(11, Comparer<Tuple<int, int>>.Create((p1, p2)=>p1.Item1 - p2.Item1));
            foreach (var user in _userToFollowees[userId])
            {
                var post = _userToPost[user];
                for (int i = post.Count - 1; i >= 0 && i >= post.Count - 10; i--)
                {
                    q.Push(post[i]);
                    if (q.Count > 10)
                    {
                        q.Pop();
                    }
                }
            }

            var ret = new List<int>();
            while (q.Count != 0)
            {
                ret.Insert(0, q.Pop().Item2);
            }

            return ret;
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            EnsureUserExists(followerId);
            EnsureUserExists(followeeId);
            if (followerId != followeeId && !_userToFollowees[followerId].Contains(followeeId))
            {
                _userToFollowees[followerId].Add(followeeId);
            }
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            EnsureUserExists(followerId);
            EnsureUserExists(followeeId);
            if (followerId != followeeId && _userToFollowees[followerId].Contains(followeeId))
            {
                _userToFollowees[followerId].Remove(followeeId);
            }
        }

        private void EnsureUserExists(int userId)
        {
            if (!_userToPost.ContainsKey(userId))
            {
                _userToPost[userId] = new List<Tuple<int, int>>();
                _userToFollowees[userId] = new HashSet<int> {userId};
            }
        }
    }

    public class Twitter2
    {

        class User
        {
            public int id { get; set; }
            public SortedList<int, int> timeLine { get; set; }
            public SortedList<int, int> newsFeed { get; set; }
            public HashSet<int> followers { get; set; }
            public User(int id)
            {
                this.id = id;
                this.timeLine = new SortedList<int, int>(Comparer<int>.Create((a, b) => b - a));
                this.newsFeed = new SortedList<int, int>(Comparer<int>.Create((a, b) => b - a));
                this.followers = new HashSet<int>();
            }
        }

        Dictionary<int, User> userStore = new Dictionary<int, User>();

        int id = 0;

        private User GetUser(int id)
        {
            if (!userStore.ContainsKey(id))
            {
                userStore[id] = new User(id);
            }

            return userStore[id];
        }

        /** Initialize your data structure here. */
        public Twitter()
        {

        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            var user = GetUser(userId);
            user.timeLine.Add(id, tweetId);
            user.newsFeed.Add(id, tweetId);
            foreach (var f in user.followers)
            {
                var u = GetUser(f);
                u.newsFeed.Add(id, tweetId);
            }
            id++;
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            var user = GetUser(userId);
            return user.newsFeed.Values.Take(10).ToList();
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if (followerId == followeeId)
            {
                return;
            }
            var follower = GetUser(followerId);
            var followee = GetUser(followeeId);
            if (followee.followers.Add(followerId))
            {
                foreach (var t in followee.timeLine.Keys)
                {
                    follower.newsFeed.Add(t, followee.timeLine[t]);
                }
            }
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if (followerId == followeeId)
            {
                return;
            }
            var follower = GetUser(followerId);
            var followee = GetUser(followeeId);
            if (followee.followers.Remove(followerId))
            {
                foreach (var t in followee.timeLine.Keys)
                {
                    follower.newsFeed.Remove(t);
                }
            }
        }
    }
}
