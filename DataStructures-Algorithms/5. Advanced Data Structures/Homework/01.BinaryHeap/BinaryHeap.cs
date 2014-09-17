namespace BinaryHeap
{
    using System;
    using System.Collections;

    public class BinaryHeap<T>
    {
        protected const int InitialCapacity = 4;

        protected Comparison<T> comparison;

        protected T[] data;

        private int size;

        public BinaryHeap()
            : this(InitialCapacity, null)
        {
        }

        public BinaryHeap(int capacity, Comparison<T> comparison)
        {
            this.data = new T[capacity];
            this.comparison = comparison ?? ((x, y) => Comparer.Default.Compare(x, y));
        }

        public void Insert(T newItem)
        {
            if (this.data.Length == this.size)
            {
                this.Resize();
            }

            this.data[this.size] = newItem;
            this.UpHeap(this.size);
            this.size++;
        }

        public T Pop()
        {
            if (this.size < 0)
            {
                throw new ArgumentException("No items in array, can't get value!");
            }

            var result = this.data[0];
            this.data[0] = this.data[--this.size];
            this.DownHeap(0);

            return result;
        }

        public T Peek()
        {
            return this.data[0];
        }

        private void Resize()
        {
            var newCapacity = this.data.Length * 2;
            var resizedData = new T[newCapacity];
            Array.Copy(this.data, resizedData, this.data.Length);
            this.data = resizedData;
        }

        private void UpHeap(int childIndex)
        {
            while (true)
            {
                if (childIndex > 0)
                {
                    var parentIndex = (childIndex - 1) / 2;
                    if (this.comparison.Invoke(this.data[childIndex], this.data[parentIndex]) > 0)
                    {
                        var temp = this.data[childIndex];
                        this.data[childIndex] = this.data[parentIndex];
                        this.data[parentIndex] = temp;
                        childIndex = parentIndex;
                        continue;
                    }
                }

                break;
            }
        }

        private void DownHeap(int parentIndex)
        {
            while (true)
            {
                var leftChildIndex = (2 * parentIndex) + 1;
                var rightChildIndex = leftChildIndex + 1;
                var largestChildIndex = parentIndex;
                if (leftChildIndex < this.size
                    && this.comparison.Invoke(this.data[leftChildIndex], this.data[rightChildIndex]) > 0)
                {
                    largestChildIndex = leftChildIndex;
                }

                if (rightChildIndex < this.size
                    && this.comparison.Invoke(this.data[rightChildIndex], this.data[leftChildIndex]) > 0)
                {
                    largestChildIndex = rightChildIndex;
                }

                if (largestChildIndex != parentIndex)
                {
                    var temp = this.data[largestChildIndex];
                    this.data[parentIndex] = this.data[largestChildIndex];
                    this.data[largestChildIndex] = temp;
                    parentIndex = largestChildIndex;
                    continue;
                }

                break;
            }
        }
    }
}