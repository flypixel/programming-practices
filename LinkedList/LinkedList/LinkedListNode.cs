namespace LinkedList
{
    internal class LinkedListNode<T>
    {
        public T Value { get; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T value, LinkedListNode<T> next = null)
        {
            Value = value;
            Next = next;
        }
    }
}
