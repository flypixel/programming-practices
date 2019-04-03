using CustomHashTable.Keys;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomHashTable
{
    public class HashTable : IDictionary<KeyObject, object>
    {
        private LinkedList<KeyValuePair<KeyObject, object>>[] _inner 
            = new LinkedList<KeyValuePair<KeyObject, object>>[10^6];


        public void Add(KeyValuePair<KeyObject, object> item)
        {
            var index = item.GetHashCode() % _inner.Length;
            var list = _inner[index];

            if (list == null)
            {
                list = new LinkedList<KeyValuePair<KeyObject, object>>();
            }

            list.AddLast(item);
        }

        public void Add(KeyObject key, object value)
        {
            Add(new KeyValuePair<KeyObject, object>(key, value));
        }

        public object this[KeyObject key]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ICollection<KeyObject> Keys => throw new NotImplementedException();

        public ICollection<object> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<KeyObject, object> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(KeyObject key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<KeyObject, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<KeyObject, object>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyObject key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<KeyObject, object> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(KeyObject key, out object value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
