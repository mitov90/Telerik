using System;
using System.Collections.Generic;

public class TreeNodeCollection<T> : List<TreeNode<T>>
{
    public TreeNodeCollection(TreeNode<T> parent)
    {
        this.Parent = parent;
    }

    public TreeNode<T> Parent { get; set; }

    public new TreeNode<T> Add(TreeNode<T> item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("item", "item cannot be null.");
        }

        base.Add(item);
        item.Parent = this.Parent;
        return item;
    }

    public TreeNode<T> Add(T data)
    {
        var newNode = new TreeNode<T>(data);
        return this.Add(newNode);
    }
}
