using System;
using System.Collections.Generic;

namespace Emrgry.Core
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<T>(T service) where T : class
        {
            var type = typeof(T);
            if (_services.ContainsKey(type))
                throw new InvalidOperationException($"Service {type.Name} is already registered.");

            _services[type] = service;
        }

        public static void Deregister<T>() where T : class
        {
            _services.Remove(typeof(T));
        }

        public static T Resolve<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out var service))
                return (T)service;

            throw new InvalidOperationException($"Service {typeof(T).Name} is not registered.");
        }

        public static bool TryResolve<T>(out T service) where T : class
        {
            if (_services.TryGetValue(typeof(T), out var obj))
            {
                service = (T)obj;
                return true;
            }

            service = null;
            return false;
        }

        public static void Clear()
        {
            _services.Clear();
        }
    }
}
