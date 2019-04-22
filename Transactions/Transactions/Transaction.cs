using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Transactions
{
    public class Transaction<TKey, TValue> where TValue: class
    {
        private static object _locker = new object();

        private Dictionary<TKey, TValue> _addBuffer = new Dictionary<TKey, TValue>();

        private HashSet<TKey> _removeBuffer = new HashSet<TKey>();

        public Guid Id { get; } = Guid.NewGuid();

        private Transaction()
        {
        }

        public static Transaction<TKey, TValue> Create()
        {
            Monitor.Enter(_locker);
            var trans = new Transaction<TKey, TValue>();
            return trans;
        }

        public bool Add(TKey key, TValue value)
        {
            if (_addBuffer.ContainsKey(key))
            {
                return false;
            }
            _addBuffer.Add(key, value);
            _removeBuffer.Remove(key);
            return true;
        }

        internal TValue Get(TKey key)
        {
            _addBuffer.TryGetValue(key, out var value);
            return value;
        }

        internal bool Remove(TKey key)
        {
            if (_addBuffer.Remove(key))
            {
                return true;
            }

            return _removeBuffer.Add(key);
        }

        internal IReadOnlyDictionary<TKey, TValue> GetBuffer()
        {
            return _addBuffer;
        }


        internal void Release()
        {
            Monitor.Exit(_locker);
        }
    }
}
