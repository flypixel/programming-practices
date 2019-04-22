using System;
using System.Collections.Generic;

namespace Transactions
{
    public class TransactionHashMap<TKey, TValue> where TValue: class
    {
        private Dictionary<TKey, TValue> _inner = new Dictionary<TKey, TValue>();
        private Stack<Transaction<TKey, TValue>> _transactions = new Stack<Transaction<TKey, TValue>>();

        public bool Add(TKey key, TValue value)
        {
            var trans = _transactions.Peek();
            if (_inner.ContainsKey(key))
            {
                return false;
            }

            return trans.Add(key, value);
        }

        public TValue Get(TKey key)
        {
            _inner.TryGetValue(key, out var value);
            if (value is null)
            {
                return _transactions.Peek().Get(key);
            }
            return value;
        }

        public bool Remove(TKey key)
        {
            return _transactions.Peek().Remove(key);
        }

        public Transaction<TKey, TValue> BeginTransaction()
        {
            var trans = Transaction<TKey, TValue>.Create();
            _transactions.Push(trans);
            return trans;
        }

        public bool Commit(Transaction<TKey, TValue> trans)
        {
            foreach (var kvp in trans.GetBuffer())
            {
                if (_inner.ContainsKey(kvp.Key))
                {
                    Release(trans);
                    return false;
                }
            }

            foreach (var kvp in trans.GetBuffer())
            {
                _inner.Add(kvp.Key, kvp.Value);
            }

            Release(trans);
            return true;
        }

        public void RollBack(Transaction<TKey, TValue> trans)
        {
            Release(trans);
        }

        private void Release(Transaction<TKey, TValue> trans)
        {
            var release = _transactions.Pop();
            trans.Release();

            if (!release.Id.Equals(trans.Id))
            {
                throw new ApplicationException("Deadlock expected");
            }
        }
    }
}
