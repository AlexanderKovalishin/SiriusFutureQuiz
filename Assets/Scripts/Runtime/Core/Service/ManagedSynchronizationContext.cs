using System.Collections.Generic;
using System.Threading;

namespace SiriusFuture.Quiz.Core.Service
{
    public class ManagedSynchronizationContext: SynchronizationContext
    {
        private readonly Queue<WorkRequest> _asyncWorkQueue = new Queue<WorkRequest>();
        private readonly int _mainThreadId;

        public override void Send(SendOrPostCallback callback, object state)
        {
            callback(state);
        }

        public override void Post(SendOrPostCallback callback, object state)
        {
            lock (_asyncWorkQueue)
            {
                _asyncWorkQueue.Enqueue(new WorkRequest(callback, state));
            }
        }
        
        public void Clear()
        {
            lock (_asyncWorkQueue)
            {
                _asyncWorkQueue.Clear();
            }
        }


        private readonly struct WorkRequest
        {
            private readonly SendOrPostCallback _delegateCallback;
            private readonly object _delegateState;
            private readonly ManualResetEvent _waitHandle;

            public WorkRequest(SendOrPostCallback callback, object state, ManualResetEvent waitHandle = null)
            {
                _delegateCallback = callback;
                _delegateState = state;
                _waitHandle = waitHandle;
            }

            public void Invoke()
            {
                _delegateCallback(_delegateState);
                _waitHandle?.Set();
            }
        }

        public void Update()
        {
            lock (_asyncWorkQueue)
            {
                int workCount = _asyncWorkQueue.Count;
                for (var i = 0; i < workCount; i++)
                {
                    WorkRequest work = _asyncWorkQueue.Dequeue();
                    work.Invoke();
                }
            }
        }
    }
}