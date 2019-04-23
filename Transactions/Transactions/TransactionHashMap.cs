using System;
using System.Collections.Generic;

namespace Transactions
{
    public class TransactionHashMap<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _inner = new Dictionary<TKey, TValue>();
        private Stack<Transaction<TKey, TValue>> _transactions = new Stack<Transaction<TKey, TValue>>();
        public bool IsTransactionActive { get; private set; }
        private object _locker = new object();

        public bool Add(TKey key, TValue value)
        {
            if (_inner.ContainsKey(key))
            {
                return false;
            }

            if (IsTransactionActive)
            {
                var trans = _transactions.Peek();
                return trans.Add(key, value);
            }

            _inner.Add(key, value);
            return true;
        }

        public (bool isOk, TValue value) Get(TKey key)
        {
            var isOk =_inner.TryGetValue(key, out var value)
                || IsTransactionActive && _transactions.Peek().Get(key, out value);
            return (isOk, value);
        }

        public bool Remove(TKey key)
        {
            if (IsTransactionActive)
            {
                return _transactions.Peek().Remove(key);
            }

            return _inner.Remove(key);
        }

        public Transaction<TKey, TValue> BeginTransaction()
        {
            var trans = Transaction<TKey, TValue>.Create(_locker);
            _transactions.Push(trans);
            IsTransactionActive = true;
            return trans;
        }

        public bool Commit(Transaction<TKey, TValue> trans)
        {
            if (!IsTransactionActive)
            {
                return false;
            }

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

            foreach (var key in trans.GetRemovableKeys())
            {
                _inner.Remove(key);
            }

            IsTransactionActive = false;
            Release(trans);
            return true;
        }

        public void RollBack(Transaction<TKey, TValue> trans)
        {
            if (!IsTransactionActive)
            {
                return;
            }
            IsTransactionActive = false;
            Release(trans);
        }

        private void Release(Transaction<TKey, TValue> trans)
        {
            var release = _transactions.Pop();
            trans.Release(_locker);

            if (!release.Id.Equals(trans.Id))
            {
                throw new ApplicationException("Deadlock expected");
            }
        }
    }
}
