using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T>: IEnumerable<T>
    {
        private LinkedListNode<T> Head { get; set; }

        public LinkedList()
        {
        }

        private LinkedList(LinkedListNode<T> node)
        {
            Head = node;
        }

        public T Car()
        {
            return (Head ?? throw new AccessViolationException("list is empty")).Value;
        }

        public LinkedList<T> Cdr()
        {
            return new LinkedList<T>(Head.Next);
        }

        public LinkedList<T> Cons(T value)
        {
            return new LinkedList<T>(new LinkedListNode<T>(value, Head));
        }

        public bool isEmpty()
        {
            return Head == null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = Head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
