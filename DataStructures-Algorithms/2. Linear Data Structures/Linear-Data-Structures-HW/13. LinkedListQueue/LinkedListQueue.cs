namespace GenericQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedListQueue<T> : IEnumerable<T>
    {
        /// <summary>
        ///     Points to the front of the queue.
        /// </summary>
        private Node<T> head;

        private int size;

        /// <summary>
        ///     Points to the rear of the queue.
        /// </summary>
        private Node<T> tail;

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var node in this.head)
            {
                yield return node.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public void Clear()
        {
            this.size = 0;
            this.head = null;
            this.tail = null;
        }

        public bool Contains(T item)
        {
            foreach (var node in this.head)
            {
                if (EqualityComparer<T>.Default.Equals(node.Data, item))
                {
                    return true;
                }
            }

            return false;
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

            foreach (var node in this.head)
            {
                array[index] = node.Data;
                index++;
            }
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Queue empty.");
            }

            var currentItem = this.head.Data;

            if (ReferenceEquals(this.head, this.tail))
            {
                // the queue contains a single node, which will be removed
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
            }

            this.size--;

            return currentItem;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);

            if (this.tail != null)
            {
                this.tail.NextNode = newNode;
            }
            else
            {
                this.head = newNode;
            }

            this.tail = newNode;

            this.size++;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Queue empty.");
            }

            var currentItem = this.head.Data;
            return currentItem;
        }

        public T[] ToArray()
        {
            var array = new T[this.size];

            var index = 0;

            foreach (var node in this.head)
            {
                array[index] = node.Data;
                index++;
            }

            return array;
        }

        public override string ToString()
        {
            if (this.size == 0)
            {
                return string.Empty;
            }

            return string.Join(", ", this.ToArray());
        }
    }
}