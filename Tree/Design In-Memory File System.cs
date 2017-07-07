/*
LeetCode 588. Design In-Memory File System

Design an in-memory file system to simulate the following functions:

ls: Given a path in string format. If it is a file path, return a list that only contains this file's name. If it is a directory path, return the list of file and directory names in this directory. Your output (file and directory names together) should in lexicographic order.

mkdir: Given a directory path that does not exist, you should make a new directory according to the path. If the middle directories in the path don't exist either, you should create them as well. This function has void return type.

addContentToFile: Given a file path and file content in string format. If the file doesn't exist, you need to create that file containing given content. If the file already exists, you need to append given content to original content. This function has void return type.

readContentFromFile: Given a file path, return its content in string format.

Example:

Input: 
["FileSystem","ls","mkdir","addContentToFile","ls","readContentFromFile"]
[[],["/"],["/a/b/c"],["/a/b/c/d","hello"],["/"],["/a/b/c/d"]]
Output:
[null,[],null,null,["a"],"hello"]
Explanation:
filesystem
Note:

You can assume all file or directory paths are absolute paths which begin with / and do not end with / except that the path is just "/".
You can assume that all operations will be passed valid parameters and users will not attempt to retrieve file content or list a directory or file that does not exist.
You can assume that all directory names and file names only contain lower-case letters, and same names won't exist in the same directory.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class FileSystem
    {
        public IEnumerable<string> ls(string path)
        {
            var n = root.GetNode(path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries), false);
            if (n == null)
            {
                throw new InvalidOperationException();
            }
            if (n.IsDir)
            {
                return n.Children.Select(c => c.Key);
            }

            return new [] { n.Name};
        }

        public void mkdir(string path)
        {
            var n = root.GetNode(path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries), true);
            if(!n.IsDir)
            {
                throw new InvalidOperationException();
            }
        }

        public void addContentToFile(string filePath, string content)
        {
            var path = filePath.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            var n = root.GetNode(path.Take(path.Length -1), false);
            if (n== null || !n.IsDir)
            {
                throw new InvalidOperationException();
            }

            Node f;
            var filename = path[path.Length - 1];
            if (!n.Children.ContainsKey(filename))
            {
                f = new Node(filename, false);
                n.Children.Add(path[path.Length - 1], f);
            }
            else
            {
                f = n.Children[filename];
            }

            if (f.IsDir)
            {
                throw new InvalidOperationException();
            }

            f.Content += content;
        }

        public string readContentFromFile(string filePath)
        {

            var path = filePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var n = root.GetNode(path, false);
            if (n == null || n.IsDir)
            {
                throw new InvalidOperationException();
            }

            return n.Content;
        }

        private Node root = new Node("");
        private class Node
        {
            public string Name { get; private set; }

            public bool IsDir { get; private set; }
            
            public string Content { get; set; }

            public SortedList<string ,Node> Children { get; private set; }

            public Node(string name, bool dir = true)
            {
                Name = name;
                IsDir = dir;
                Children = new SortedList<string, Node>();
            }

            public Node GetNode(IEnumerable<string> path, bool create)
            {
                var p = path.FirstOrDefault();
                if (p == null)
                {
                    return this;
                }

                if (!this.IsDir)
                {
                    throw new InvalidOperationException();
                }
                if (Children.ContainsKey(p))
                {
                    var c = Children[p];
                        return c.GetNode(path.Skip(1), create);
                }
                if (create)
                {
                    var c = new Node(p);
                    Children.Add(p, c);
                    return c.GetNode(path.Skip(1), create);
                }

                return null;
            }
        }
    };
}
