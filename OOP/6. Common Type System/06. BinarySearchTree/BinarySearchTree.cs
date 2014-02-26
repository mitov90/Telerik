using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class BinarySearchTree<T> : ICloneable, IEnumerable<T>
    where T : IComparable<T>
{
    #region Private Fields

    private readonly StringBuilder _itemsBuilder = new StringBuilder();
    private const int PrimeMultiplier = 83;
    private int _count;

    /// <summary>
    /// The root of the tree
    /// </summary>
    private BinaryTreeNode<T> _root;

    #endregion

    #region Properties

    public int Count
    {
        get
        {
            return this._count;
        }
    }

    #endregion

    #region Constructors

    public BinarySearchTree()
    {
    }

    public BinarySearchTree(params T[] items)
    {
        foreach (T item in items)
        {
            this.Add(item);
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Determines whether an element is in the binary search tree.
    /// </summary>
    /// <param name="item">The object to locate in the binary search tree.</param>
    /// <returns></returns>
    public bool Contains(T item)
    {
        BinaryTreeNode<T> nodeFound = this.Find(item);

        return nodeFound != null;
    }

    /// <summary>
    /// Adds an object to the binary search tree.
    /// </summary>
    /// <param name="item">The object to be added to the binary search tree.</param>
    public void Add(T item)
    {
        if (item != null)
        {
            this._root = this.Add(item, this._root, null);
        }
        else
        {
            throw new ArgumentException("Item cannot be null.");
        }
    }

    /// <summary>
    /// Removes a specific object from the binary search tree.
    /// </summary>
    /// <param name="item">The object to remove from the binary search tree.</param>
    public void Remove(T item)
    {
        BinaryTreeNode<T> nodeToDelete = this.Find(item);
        if (nodeToDelete == null)
        {
            return;
        }

        Remove(nodeToDelete);
    }

    public override string ToString()
    {
        return this.AsString(true);
    }

    public string AsString(bool ascending)
    {
        if (this._root == null)
        {
            return String.Empty;
        }
        this._itemsBuilder.Clear();
        if (@ascending)
        {
            this.AsStringAscending(this._root);
        }
        else
        {
            this.AsStringDescending(this._root);
        }

        // remove the extra comma and space at the end
        return this._itemsBuilder.Remove(this._itemsBuilder.Length - 2, 2).ToString();
    }

    public override bool Equals(object obj)
    {
        // If the cast is invalid, the result will be null
        BinarySearchTree<T> other = obj as BinarySearchTree<T>;

        // Check if we have valid not null BinarySearchTree<T> object
        if (other == null)
        {
            return false;
        }

        return this.AreEqual(this._root, other._root);
    }

    public static bool operator ==(BinarySearchTree<T> a, BinarySearchTree<T> b)
    {
        return Equals(a, b);
    }

    public static bool operator !=(BinarySearchTree<T> a, BinarySearchTree<T> b)
    {
        return !(Equals(a, b));
    }

    public override int GetHashCode()
    {
        int result = 1;

        if (this._root != null)
        {
            this.CalcHashCodePreorder(this._root, ref result);
        }

        return result;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        if (this._root != null)
        {
            if (this._root.Left != null)
            {
                foreach (BinaryTreeNode<T> node in this._root.Left)
                {
                    yield return node.Item;
                }
            }

            yield return this._root.Item;

            if (this._root.Right != null)
            {
                foreach (BinaryTreeNode<T> node in this._root.Right)
                {
                    yield return node.Item;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    /// <summary>
    /// Explicit implementation of ICloneable.Clone()
    /// </summary>
    /// <returns></returns>
    object ICloneable.Clone()
    {
        return this.Clone();
    }

    public BinarySearchTree<T> Clone()
    {
        BinarySearchTree<T> clone = new BinarySearchTree<T>();
        this.Copy(clone, this._root);
        return clone;
    }

    #endregion

    #region Private Methods

    private BinaryTreeNode<T> Add(T item, BinaryTreeNode<T> node, BinaryTreeNode<T> parentNode)
    {
        if (node == null)
        {
            node = new BinaryTreeNode<T>(item) {Parent = parentNode};

            // update count
            this._count++;
        }
        else
        {
            int comparisonResult = node.Item.CompareTo(item);

            if (comparisonResult > 0)
            {
                node.Left = this.Add(item, node.Left, node);
            }
            else if (comparisonResult < 0)
            {
                node.Right = this.Add(item, node.Right, node);
            }
        }

        return node;
    }

    private void Copy(BinarySearchTree<T> clone, BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            clone.Add(node.Item);
            this.Copy(clone, node.Left);
            this.Copy(clone, node.Right);
        }
    }

    private BinaryTreeNode<T> Find(T item)
    {
        BinaryTreeNode<T> node = this._root;

        while (node != null)
        {
            int comparisonResult = node.Item.CompareTo(item);

            if (comparisonResult > 0)
            {
                node = node.Left;
            }
            else if (comparisonResult < 0)
            {
                node = node.Right;
            }
            else
            {
                break;
            }
        }

        return node;
    }

    private void Remove(BinaryTreeNode<T> node)
    {
        // Case 3: If the node has two children
        if (node.Left != null && node.Right != null)
        {
            BinaryTreeNode<T> replacement = this.Min(node.Right);
            node.Item = replacement.Item;
            node = replacement;
        }

        // Case 1 and 2: If the node has at most one child
        BinaryTreeNode<T> theChild = node.Left ?? node.Right;

        if (theChild != null)
        {
            theChild.Parent = node.Parent;
        }

        // Handle the case when the element is the root
        if (node.Parent == null)
        {
            this._root = theChild;
        }
        else
        {
            // Replace the element with its child subtree
            if (node == node.Parent.Left)
            {
                // the node is the left child of its parent
                node.Parent.Left = theChild;
            }
            else
            {
                // the node is the right child of its parent
                node.Parent.Right = theChild;
            }
        }

        // update count
        this._count--;
    }

    private BinaryTreeNode<T> Min(BinaryTreeNode<T> node)
    {
        BinaryTreeNode<T> min = node;

        while (min.Left != null)
        {
            min = min.Left;
        }

        return min;
    }

    private void AsStringAscending(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            this.AsStringAscending(node.Left);
            this._itemsBuilder.AppendFormat("{0}, ", node.Item);
            this.AsStringAscending(node.Right);
        }
    }

    private void AsStringDescending(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            this.AsStringDescending(node.Right);
            this._itemsBuilder.AppendFormat("{0}, ", node.Item);
            this.AsStringDescending(node.Left);
        }
    }

    private bool AreEqual(BinaryTreeNode<T> a, BinaryTreeNode<T> b)
    {
        if (a == null && b == null)
        {
            return true;
        }
        if (a != null && b != null)
        {
            return a == b && this.AreEqual(a.Left, b.Left) && this.AreEqual(a.Right, b.Right);
        }
        return false;
    }

    private void CalcHashCodePreorder(BinaryTreeNode<T> node, ref int hashCode)
    {
        if (node != null)
        {
            hashCode = hashCode * PrimeMultiplier + node.GetHashCode();
            this.CalcHashCodePreorder(node.Left, ref hashCode);
            this.CalcHashCodePreorder(node.Right, ref hashCode);
        }
    }

    #endregion
}
