using System.Collections;
using System.Collections.Generic;

internal class DoublyLinkedNode<T> : IEnumerable<DoublyLinkedNode<T>>
{
    public DoublyLinkedNode(T data)
    {
        this.Data = data;
        this.NextNode = null;
        this.PreviousNode = null;
    }

    // Data or a reference to data
    public T Data { get; set; }

    // A reference to the next node
    public DoublyLinkedNode<T> NextNode { get; set; }

    // A reference to the previous node
    public DoublyLinkedNode<T> PreviousNode { get; set; }

    public IEnumerator<DoublyLinkedNode<T>> GetEnumerator()
    {
        while (this.NextNode != null)
        {
            yield return this.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
