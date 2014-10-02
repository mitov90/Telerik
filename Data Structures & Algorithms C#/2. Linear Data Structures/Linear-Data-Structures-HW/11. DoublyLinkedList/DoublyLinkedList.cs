using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IList<T>
{
    private int size;

    public DoublyLinkedList()
    {
        this.size = 0;
        this.firstNode = null;
        this.lastNode = null;
    }

    /// <summary>
    ///     Points to the first node of the list.
    /// </summary>
    private DoublyLinkedNode<T> firstNode;

    /// <summary>
    ///     Points to the last node of the list.
    /// </summary>
    private DoublyLinkedNode<T> lastNode;

    public int Count
    {
        get
        {
            return this.size;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException(
                    "index",
                    "Index was out of range. Must be non-negative and less than the size of the collection.");
            }

            var currentNode = this.firstNode;

            for (var i = 0; i < index; i++)
            {
                currentNode = currentNode.NextNode;
            }

            return currentNode.Data;
        }

        set
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException(
                    "index",
                    "Index was out of range. Must be non-negative and less than the size of the collection.");
            }

            var currentNode = this.firstNode;

            for (var i = 0; i < index; i++)
            {
                currentNode = currentNode.NextNode;
            }

            currentNode.Data = value;
        }
    }

    public int IndexOf(T item)
    {
        var index = 0;
        var currentNode = this.firstNode;

        while (currentNode != null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.Data, item))
            {
                return index;
            }

            currentNode = currentNode.NextNode;
            index++;
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > this.size)
        {
            throw new ArgumentOutOfRangeException(
                "index",
                "Index was out of range. Must be non-negative and less than or equal to the size of the collection.");
        }

        var newNode = new DoublyLinkedNode<T>(item);

        if (index == 0)
        {
            this.InsertBeginning(newNode);
            return;
        }

        // find the item at the specified index
        var currentIndex = 0;
        var currentNode = this.firstNode;
        while (currentIndex < index - 1)
        {
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        this.InsertAfter(currentNode, newNode);
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.size)
        {
            throw new ArgumentOutOfRangeException(
                "index",
                "Index was out of range. Must be non-negative and less than the size of the collection.");
        }

        // find the item at the specified index
        var currentIndex = 0;
        var currentNode = this.firstNode;
        while (currentIndex < index)
        {
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        this.Remove(currentNode);
    }

    public void Add(T item)
    {
        var newNode = new DoublyLinkedNode<T>(item);
        this.InsertEnd(newNode);
    }

    public void Clear()
    {
        this.size = 0;
        this.firstNode = null;
        this.lastNode = null;
    }

    public bool Contains(T item)
    {
        var index = this.IndexOf(item);
        var found = index != -1;
        return found;
    }

    public void CopyTo(T[] array)
    {
        this.CopyTo(array, 0);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array", "array cannot be null.");
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex cannot be less than zero.");
        }

        if (arrayIndex + this.size > array.Length)
        {
            throw new ArgumentException(
                "Destination array was not long enough. " + "Check arrayIndex and the array's length.");
        }

        var index = arrayIndex;

        foreach (var node in this.firstNode)
        {
            array[index] = node.Data;
            index++;
        }
    }

    public bool Remove(T item)
    {
        if (this.size == 0)
        {
            return false;
        }

        // find the node which contains the item
        var currentNode = this.firstNode;

        while (currentNode != null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.Data, item))
            {
                break;
            }

            currentNode = currentNode.NextNode;
        }

        if (currentNode != null)
        {
            this.Remove(currentNode);
            return true;
        }

        // the node was not found
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var node in this.firstNode)
        {
            yield return node.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    private void InsertAfter(DoublyLinkedNode<T> node, DoublyLinkedNode<T> newNode)
    {
        newNode.PreviousNode = node;
        newNode.NextNode = node.NextNode;
        if (node.NextNode == null)
        {
            this.lastNode = newNode;
        }
        else
        {
            node.NextNode.PreviousNode = newNode;
        }

        node.NextNode = newNode;
        this.size++;
    }

    private void InsertBefore(DoublyLinkedNode<T> node, DoublyLinkedNode<T> newNode)
    {
        newNode.PreviousNode = node.PreviousNode;
        newNode.NextNode = node;
        if (node.PreviousNode == null)
        {
            this.firstNode = newNode;
        }
        else
        {
            node.PreviousNode.NextNode = newNode;
        }

        node.PreviousNode = newNode;
        this.size++;
    }

    private void InsertBeginning(DoublyLinkedNode<T> newNode)
    {
        if (this.firstNode == null)
        {
            this.firstNode = newNode;
            this.lastNode = newNode;
            newNode.PreviousNode = null;
            newNode.NextNode = null;
            this.size++;
        }
        else
        {
            this.InsertBefore(this.firstNode, newNode);
        }
    }

    private void InsertEnd(DoublyLinkedNode<T> newNode)
    {
        if (this.lastNode == null)
        {
            this.InsertBeginning(newNode);
        }
        else
        {
            this.InsertAfter(this.lastNode, newNode);
        }
    }

    private void Remove(DoublyLinkedNode<T> node)
    {
        if (node.PreviousNode == null)
        {
            this.firstNode = node.NextNode;
        }
        else
        {
            node.PreviousNode.NextNode = node.NextNode;
        }

        if (node.NextNode == null)
        {
            this.lastNode = node.PreviousNode;
        }
        else
        {
            node.NextNode.PreviousNode = node.PreviousNode;
        }

        this.size--;
    }
}
