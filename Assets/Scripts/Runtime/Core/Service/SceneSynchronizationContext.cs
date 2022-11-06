using System;
using System.Threading;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Service
{
    public class SceneSynchronizationContext : MonoBehaviour
    {
        private ManagedSynchronizationContext _managedSynchronizationContext;
        private SynchronizationContext _systemContext;
        private void Awake()
        {
            _systemContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(_managedSynchronizationContext = new ManagedSynchronizationContext());
        }

        private void Update()
        {
            _managedSynchronizationContext.Update();
        }

        private void OnDestroy()
        {
            _managedSynchronizationContext.Clear();
            SynchronizationContext.SetSynchronizationContext(_systemContext);
        }
    }
}