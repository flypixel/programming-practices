using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Builder
{
    public class ObjectBuilder
    {
        private readonly Dictionary<int, ThreadSpecificObject> _objects 
            = new Dictionary<int, ThreadSpecificObject>();

        private volatile int _ticket = 0;
        private volatile int _turn = 1;

        public ThreadSpecificObject Create(string name)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            if (!_objects.TryGetValue(threadId, out ThreadSpecificObject created))
            {
                Lock();
                created = Create(name, threadId);
                _objects.Add(threadId, created);
                UnLock();
            }
            return created;
        }

        private ThreadSpecificObject Create(string name, int threadId)
        {
            return new ThreadSpecificObject
            {
                Id = Guid.NewGuid(),
                Name = name,
                ThreadId = threadId
            };
        }

        private void Lock()
        {
            int myturn = Interlocked.Increment(ref _ticket);
            while (_turn != myturn)
            {
                Thread.Sleep(1);
            }
        }

        private void UnLock()
        {
            Interlocked.Increment(ref _turn);
        }
    }
}
