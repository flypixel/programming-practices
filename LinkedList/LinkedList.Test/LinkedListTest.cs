using LinkedList;
using NUnit.Framework;
using System.Linq;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class LinkedListTest
    {

        [Test]
        public void CreationTest()
        {
            var list = new LinkedList<int>(1, 2, 3, 4);
            var result = list.ToArray();
            var expected = new int[] { 1, 2, 3, 4 };

            AssertArrayComparison(expected, result);
        }

        [Test]
        public void HeadTest()
        {
            var list = new LinkedList<int>(1, 2, 3, 4);
            Assert.AreEqual(list.Head, 1);
        }

        [Test]
        public void TailTest()
        {
            var list = new LinkedList<int>(1, 2, 3, 4);
            var tail = list.Tail.ToArray();

            AssertArrayComparison(tail, new int[] { 2, 3, 4 });
        }

        [Test]
        public void PushTest()
        {
            var list = new LinkedList<int>(1, 2, 3, 4);

            list.Push(1);
            list.Push(2);
            list.Push(3);

            AssertArrayComparison(list.ToArray(), new int[] { 3, 2, 1, 1, 2, 3, 4 });
        }

        [Test]
        public void ConsTest()
        {
            var list = new LinkedList<int>(1, 2, 3, 4);
            var newList = list.Cons(0).ToArray();

            AssertArrayComparison(newList, new int[] { 0, 1, 2, 3, 4 });
        }

        [Test]
        public void IsEmptyTest()
        {
            var empty = new LinkedList<int>();
            var list = empty.Cons(1);

            Assert.AreEqual(empty.IsEmpty, true);
            Assert.AreEqual(list.IsEmpty, false);
            Assert.AreEqual(list.Head, 1);
        }

        [Test]
        public void CheckInterlocked()
        {
            object curr = 1;
            object prev = curr;

            object origin = Interlocked.CompareExchange(ref curr, 2, prev);
            Assert.AreNotSame(origin, curr);
            Assert.AreSame(origin, prev);
        }

        private void AssertArrayComparison<T>(T[] expected, T[] result)
        {
            Assert.AreEqual(expected.Length, result.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}