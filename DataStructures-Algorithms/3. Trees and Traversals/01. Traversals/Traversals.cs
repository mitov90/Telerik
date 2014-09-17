using System;
using System.Collections.Generic;
using System.Text;

internal class Traversals
{
    private static void PrintAllSubtreesThatSumTo(IEnumerable<TreeNode<int>> nodes, int sum)
    {
        foreach (var node in nodes)
        {
            var subtreeSum = node.Accumulate(0, (a, b) => a + b);
            if (subtreeSum == sum)
            {
                Console.WriteLine(node);
            }
        }
    }

    private static void PrintAllPathsThatSumTo(IEnumerable<TreeNode<int>> nodes, int sum)
    {
        foreach (var node in nodes)
        {
            PrintAllPathsThatSumTo(node, sum);
        }
    }

    private static void PrintAllPathsThatSumTo(TreeNode<int> node, int sum)
    {
        var currentNode = node;
        var result = new StringBuilder();

        var currentSum = 0;

        while (currentNode != null)
        {
            currentSum += currentNode.Data;
            result.Insert(0, currentNode.Data + " ");

            if (currentSum == sum)
            {
                result.Length--;
                Console.WriteLine(result);
            }

            currentNode = currentNode.Parent;
        }
    }

    private static TreeNode<T> GetRoot<T>(IEnumerable<TreeNode<T>> nodes)
    {
        // Find the root. By definition that's the node
        // which has no parent
        foreach (var node in nodes)
        {
            if (node.Parent == null)
            {
                return node;
            }
        }

        return null;
    }

    private static List<TreeNode<T>> GetLeaves<T>(IEnumerable<TreeNode<T>> nodes)
    {
        var leaves = new List<TreeNode<T>>();

        // Find all leaf nodes. By definition a leaf node
        // has no children
        foreach (var node in nodes)
        {
            if (node.Nodes.Count == 0)
            {
                leaves.Add(node);
            }
        }

        return leaves;
    }

    private static List<TreeNode<T>> GetInnerNodes<T>(TreeNode<T>[] nodes)
    {
        var innerNodes = new List<TreeNode<T>>();

        // Find all internal nodes.
        foreach (var node in nodes)
        {
            if (node.Parent != null && node.Nodes.Count > 0)
            {
                innerNodes.Add(node);
            }
        }

        return innerNodes;
    }

    private static void Main()
    {
        const int Sum = 6;

        Console.Write("Enter nodes count: ");
        var n = int.Parse(Console.ReadLine());

        var nodes = new TreeNode<int>[n];

        for (var i = 0; i < n; i++)
        {
            nodes[i] = new TreeNode<int>(i);
        }

        for (var i = 1; i < n; i++)
        {
            var edge = Console.ReadLine();
            var edgeNodes = edge.Split(' ');
            var parentData = int.Parse(edgeNodes[0]);
            var childData = int.Parse(edgeNodes[1]);

            nodes[parentData].Nodes.Add(nodes[childData]);
        }

        TreeNode<int> root = GetRoot(nodes);
        Console.WriteLine("Root: {0}", root != null ? root.ToString() : "[no root]");

        List<TreeNode<int>> leaves = GetLeaves(nodes);

        Console.WriteLine("Leaf nodes:");

        foreach (var leaf in leaves)
        {
            Console.WriteLine(leaf);
        }

        var innerNodes = GetInnerNodes(nodes);

        Console.WriteLine("Inner nodes:");

        foreach (var node in innerNodes)
        {
            Console.WriteLine(node);
        }

        var tree = new Tree<int>(root);

        Console.WriteLine("Nodes data (DFS):");

        foreach (var data in tree)
        {
            Console.Write(data + " ");
        }

        Console.WriteLine();

        Console.WriteLine("The tree (DFS):{0}{1}", Environment.NewLine, tree);

        Console.WriteLine("Height: " + tree.GetHeight());

        Console.WriteLine("All downward paths that sum to {0}:", Sum);

        PrintAllPathsThatSumTo(nodes, Sum);

        Console.WriteLine("Nodes whose subtrees sum to {0}:", Sum);

        PrintAllSubtreesThatSumTo(nodes, Sum);

        Tree<double> sinTree = tree.Map(i => Math.Sin(i));

        Console.WriteLine("A tree created by applying Math.Sin() to the tree nodes:");

        Console.WriteLine(sinTree);
    }
}
