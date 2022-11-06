using System;
using System.Collections.Generic;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    public class Pool<T, TFactory> : MonoBehaviour 
        where T: MonoBehaviour 
        where TFactory: Factory<T>
    {
        [SerializeField] private int _startCapacity;
        [SerializeField] private TFactory _factory;

        private readonly Queue<T> _inactiveInstances = new Queue<T>();
        private readonly HashSet<T> _activeInstances = new HashSet<T>();

        private void Awake()
        {
            for (var i = 0; i < _startCapacity; i++)
            {
                var instance = _factory.Create();
                instance.gameObject.SetActive(false);
                _inactiveInstances.Enqueue(instance);
            }
        }
        
        public T GetInstance()
        {
            var instance = _inactiveInstances.Count == 0 
                ? _factory.Create() 
                : _inactiveInstances.Dequeue();
            instance.gameObject.SetActive(true);
            _activeInstances.Add(instance);
            InvokeGetEvents(instance);
            return instance;
        }

        public void ReturnInstance(T instance)
        {
            InvokeReturnEvents(instance);
            _activeInstances.Remove(instance);
            instance.gameObject.SetActive(false);
            _inactiveInstances.Enqueue(instance);
        }

        public void ReturnAll()
        {
            foreach (var instance in _activeInstances)
            {
                InvokeReturnEvents(instance);
                instance.gameObject.SetActive(false);
                _inactiveInstances.Enqueue(instance);
            }
            _activeInstances.Clear();
        }

        private void InvokeGetEvents(T instance)
        {
            if (instance is IGetInstanceFromPoolListener listener)
            {
                listener.OnGetInstanceFromPool();
            }
        }

        private void InvokeReturnEvents(T instance)
        {
            if (instance is IReturnInstanceToPoolListener listener)
            {
                listener.OnReturnInstanceToPool();
            }
        }
    }
}