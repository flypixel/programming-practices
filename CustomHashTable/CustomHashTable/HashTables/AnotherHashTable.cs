using System;
using System.Collections;
using System.Collections.Generic;
using CustomHashTable.Keys;

namespace CustomHashTable.HashTables
{
    public class AnotherHashTable : ICustomHashTable
    {
        const int size = 1000_000;

        KeyValuePair<KeyObject, object>?[] _inner
            = new KeyValuePair<KeyObject, object>?[size];

        public void Add(KeyValuePair<KeyObject, object> item)
        {
            var index = Math.Abs(item.Key.GetHashCode()) % _inner.Length;
            while (_inner[index].HasValue)
            {
                if (_inner[index].Value.Key.Equals(item.Key))
                {
                    throw new ArgumentException($"Dublicate key '{item.Key}'");
                }

                if (++index >= _inner.Length)
                {
                    ResizeArray();
                    break;
                }
            }

            _inner[index] = item;
        }

        public void Add(KeyObject key, object value)
        {
            Add(new KeyValuePair<KeyObject, object>(key, value));
        }

        private void ResizeArray()
        {
            var newArr = new KeyValuePair<KeyObject, object>?[_inner.Length * 2];
            for (int i = 0; i < _inner.Length; i++)
            {
                newArr[i] = _inner[i];
            }
            _inner = newArr;
        }

        #region NotImplemented
        public object this[KeyObject key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
        #endregion
    }
}
