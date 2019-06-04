using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Threading;

namespace Transactions.Tests
{
    [TestClass]
    public class TransactionMapTest
    {
        (string, int)[] _testData = new[] { ("a", 1), ("b", 2), ("c", 3) };

        [TestMethod]
        public void SimpleAddTest()
        {
            var hashmap = new TransactionHashMap<string, int>();
            foreach (var (k, v) in _testData)
            {
                hashmap.Add(k, v);
            }

            foreach (var (k, v) in _testData)
            {
                var (isOk, value) = hashmap.Get(k);
                Assert.IsTrue(isOk && v == value);
            }
        }

        [TestMethod]
        public void SimpleAddRemoveTest()
        {
            var hashmap = new TransactionHashMap<string, int>();
            const string keyRemove = "b";

            foreach (var (k, v) in _testData)
            {
                hashmap.Add(k, v);
            }
            hashmap.Remove(keyRemove);

            foreach (var (k, v) in _testData)
            {
                var (isOk, value) = hashmap.Get(k);
                if (k == keyRemove)
                {
                    Assert.IsFalse(isOk);
                    continue;
                }
                Assert.IsTrue(isOk && v == value);
            }
        }

        [TestMethod]
        public void SimpleAddTransactionTest()
        {
            
            var hashmap = new TransactionHashMap<string, int>();
            var trans = hashmap.BeginTransaction();
            foreach (var (k, v) in _testData)
            {
                hashmap.Add(k, v);
            }
            hashmap.Commit(trans);


            foreach (var (k, v) in _testData)
            {
                var (isOk, value) = hashmap.Get(k);
                Assert.IsTrue(isOk && v == value);
            }
        }

        [TestMethod]
        public void SimpleAddRemoveTransactionTest()
        {
            var hashmap = new TransactionHashMap<string, int>();
            var trans = hashmap.BeginTransaction();
            const string keyRemove = "b";

            foreach (var (k, v) in _testData)
            {
                hashmap.Add(k, v);
            }
            hashmap.Remove(keyRemove);
            hashmap.Commit(trans);

            foreach (var (k, v) in _testData)
            {
                var (isOk, value) = hashmap.Get(k);
                if (k == keyRemove)
                {
                    Assert.IsFalse(isOk);
                    continue;
                }
                Assert.IsTrue(isOk && v == value);
            }
        }

        [TestMethod]
        public void MultiThreadingTest()
        {
            var hashmap = new TransactionHashMap<string, int>();
            const string keyRemove = "b";

            var task1 = Task.Factory.StartNew(() =>
            {
                var trans = hashmap.BeginTransaction();
                foreach (var (k, v) in _testData)
                {
                    hashmap.Add(k, v);
                }
                hashmap.Commit(trans);
            });

            var task2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1);
                var trans = hashmap.BeginTransaction();
                hashmap.Remove(keyRemove);
                hashmap.Commit(trans);
            });

            Task.WhenAll(task1, task2).Wait();

            foreach (var (k, v) in _testData)
            {
                var (isOk, value) = hashmap.Get(k);
                if (k == keyRemove)
                {
                    Assert.IsFalse(isOk);
                    continue;
                }
                Assert.IsTrue(isOk && v == value);
            }
        }
    }
}
