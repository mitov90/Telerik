using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
///     The original source can be found at:
///     http://www.informit.com/guides/content.aspx?g=dotnet&seqNum=769
/// </summary>
public class AhoCorasickStringSearcher
{
    private readonly string[] searchStrings;

    private int maxTreeDepth;

    private TreeNode root;

    public AhoCorasickStringSearcher(IEnumerable<string> searchStrings)
    {
        this.searchStrings = searchStrings.ToArray();
        this.root = this.BuildTree();
    }

    public List<StringSearchResult> FindAll(string content, int startIndex)
    {
        var results = new List<StringSearchResult>();
        var nodes = new List<TreeNode>(this.maxTreeDepth);
        var newNodes = new List<TreeNode>(this.maxTreeDepth);

        var nodesExamined = 0;

        for (var index = startIndex; index < content.Length; ++index)
        {
            nodes.Add(this.root);

            foreach (var node in nodes)
            {
                ++nodesExamined;

                var newNode = node.GetTransition(content[index]);
                if (newNode != null)
                {
                    if (newNode.HasTransitions)
                    {
                        newNodes.Add(newNode);
                    }

                    if (newNode.Terminal != -1)
                    {
                        var foundString = this.searchStrings[newNode.Terminal];
                        results.Add(new StringSearchResult(foundString, index - foundString.Length + 1));
                    }
                }
            }

            var temp = nodes;
            nodes = newNodes;
            newNodes = temp;

            newNodes.Clear();
        }

        return results;
    }

    public void OutputTree(TextWriter writer)
    {
        writer.WriteLine("Tree");
        this.OutputNode(writer, this.root, string.Empty);
    }

    private TreeNode BuildTree()
    {
        this.root = new TreeNode((char)0);
        this.maxTreeDepth = 0;

        for (var stringIndex = 0; stringIndex < this.searchStrings.Length; ++stringIndex)
        {
            var s = this.searchStrings[stringIndex];
            this.maxTreeDepth = Math.Max(this.maxTreeDepth, s.Length);

            var node = this.root;
            for (var charIndex = 0; charIndex < s.Length; ++charIndex)
            {
                var c = s[charIndex];
                var newNode = node.GetTransition(c);
                if (newNode == null)
                {
                    var terminal = (charIndex == s.Length - 1) ? stringIndex : -1;
                    newNode = node.AddTransition(c, terminal);
                }
                else if (charIndex == s.Length - 1)
                {
                    newNode.Terminal = stringIndex;
                }

                node = newNode;
            }
        }

        ++this.maxTreeDepth;
        return this.root;
    }

    private void OutputNode(TextWriter writer, TreeNode node, string pad)
    {
        Console.WriteLine("{0}{1}: {2}", pad, node.Character, node.Terminal);
        foreach (var pair in node.GetTransitions())
        {
            this.OutputNode(writer, pair.Value, pad + " ");
        }
    }
}