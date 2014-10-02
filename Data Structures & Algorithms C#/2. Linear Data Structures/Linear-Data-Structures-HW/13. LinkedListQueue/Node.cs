namespace GenericQueue
{
    using System.Collections;
    using System.Collections.Generic;

    internal class Node<T> : IEnumerable<Node<T>>
    {
        public Node(T data)
        {
            this.Data = data;
            this.NextNode = null;
        }

        // Data or a reference to data
        public T Data { get; set; }

        // A reference to the next node
        public Node<T> NextNode { get; set; }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            var currentNode = this;

            do
            {
                var returnNode = currentNode;
                currentNode = currentNode.NextNode;
                yield return returnNode;
            }
            while (currentNode != null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}