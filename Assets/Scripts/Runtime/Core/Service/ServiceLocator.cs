using System;
using System.Collections.Generic;

namespace SiriusFuture.Quiz.Core.Service
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static T Locate<T>()
        {
            if (_services.ContainsKey(typeof(T)))
                return (T)_services[typeof(T)];
            throw new ArgumentException($"unable to locate service {typeof(T).FullName}");
        }

        public static void Register<T>(T service)
        {
            if (_services.ContainsKey(typeof(T)))
            {
                throw new ArgumentException($"service {typeof(T).FullName} already registered");
            }
            _services.Add(typeof(T), service);
        }

        public static void Clear()
        {
            _services.Clear();
        }
    }
}