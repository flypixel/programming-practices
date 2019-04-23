using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Transactions
{
    public class Transaction<TKey, TValue>
    {
        public Guid Id { get; } = Guid.NewGuid();

        private Dictionary<TKey, TValue> _addBuffer = new Dictionary<TKey, TValue>();

        private HashSet<TKey> _removeBuffer = new HashSet<TKey>();


        private Transaction()
        {
        }

        internal static Transaction<TKey, TValue> Create(object locker)
        {
            Monitor.Enter(locker);
            var trans = new Transaction<TKey, TValue>();
            return trans;
        }

        internal bool Add(TKey key, TValue value)
        {
            if (_addBuffer.ContainsKey(key))
            {
                return false;
            }
            _addBuffer.Add(key, value);
            _removeBuffer.Remove(key);
            return true;
        }

        internal bool Get(TKey key, out TValue value)
        {
            return _addBuffer.TryGetValue(key, out value);
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

        internal IEnumerable<TKey> GetRemovableKeys()
        {
            return _removeBuffer;
        }


        internal void Release(object locker)
        {
            Monitor.Exit(locker);
        }
    }
}
