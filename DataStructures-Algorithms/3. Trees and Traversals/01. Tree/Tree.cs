using System;
using System.Collections;
using System.Collections.Generic;

public class Tree<T> : IEnumerable<T>
{
    public Tree(TreeNode<T> root)
    {
        this.Root = root;
    }

    public Tree(T rootData)
    {
        this.Root = new TreeNode<T>(rootData);
    }

    public TreeNode<T> Root { get; set; }

    /// <summary>
    /// Returns the height of the tree, i.e. the height of the root.
    /// </summary>
    /// <returns>The height of the tree.</returns>
    public int GetHeight()
    {
        return this.Root.GetHeight();
    }

    public override string ToString()
    {
        return this.Root.ToStringUsingDfs();
    }

    public Tree<TU> Map<TU>(Func<T, TU> selector)
    {
        var newRoot = this.Root.Map(selector);
        var result = new Tree<TU>(newRoot);
        return result;
    }

    public TU Accumulate<TU>(TU seed, Func<TU, T, TU> func)
    {
        return this.Accumulate(seed, func, data => true);
    }

    public U Accumulate<U>(U seed, Func<U, T, U> func, Func<T, bool> predicate)
    {
        return this.Root.Accumulate(seed, func, predicate);
    }

    public IEnumerable<TreeNode<T>> Filter(Func<T, bool> predicate)
    {
        return this.Root.Filter(predicate);
    }

    /// <summary>
    /// Iterates through the child nodes of the root, i.e.
    /// traverses the whole tree structure. Uses BFS.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var node in this.Root)
        {
            yield return node.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
