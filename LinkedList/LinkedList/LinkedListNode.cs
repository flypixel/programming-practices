namespace LinkedList
{
    internal class LinkedListNode<T>
    {
        public T Value { get; }

        public LinkedListNode<T> Next { get; }

        public LinkedListNode(T value, LinkedListNode<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
