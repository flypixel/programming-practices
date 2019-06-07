using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LinkedList
{
    public class LinkedList<T>: IEnumerable<T>
    {
        private volatile LinkedListNode<T> _head = null;

        public T Head => (_head ?? throw new AccessViolationException("list is empty")).Value;
        public LinkedList<T> Tail => new LinkedList<T>(_head.Next);

        public LinkedList()
        {
        }

        public LinkedList(params T[] list)
        {
            foreach (var x in list.Reverse())
            {
                var node = new LinkedListNode<T>(x, _head);
                _head = node;
            }
        }

        private LinkedList(LinkedListNode<T> node)
        {
            _head = node;
        }

        // lock free mutation
        public void Push(T value)
        {
            LinkedListNode<T> prev;
            LinkedListNode<T> created = new LinkedListNode<T>(value, _head);

            do
            {
                prev = _head;
                created.Next = _head;
                Interlocked.CompareExchange(ref _head, created, prev);
            } while (_head.Equals(prev));
        }

        public LinkedList<T> Cons(T value)
        {
            return new LinkedList<T>(new LinkedListNode<T>(value, _head));
        }

        public bool IsEmpty => _head == null;

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
