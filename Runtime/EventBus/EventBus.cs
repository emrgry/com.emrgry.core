using System;
using System.Collections.Generic;

namespace Emrgry.Core
{
    public sealed class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _listeners = new();

        public void Subscribe<T>(Action<T> callback) where T : struct
        {
            var type = typeof(T);
            if (!_listeners.TryGetValue(type, out var list))
            {
                list = new List<Delegate>();
                _listeners[type] = list;
            }

            list.Add(callback);
        }

        public void Unsubscribe<T>(Action<T> callback) where T : struct
        {
            if (_listeners.TryGetValue(typeof(T), out var list))
                list.Remove(callback);
        }

        public void Publish<T>(T evt) where T : struct
        {
            if (!_listeners.TryGetValue(typeof(T), out var list))
                return;

            // Iterate over a copy to allow subscribe/unsubscribe during publish
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (i < list.Count && list[i] is Action<T> action)
                    action.Invoke(evt);
            }
        }

        public void Clear()
        {
            _listeners.Clear();
        }
    }
}
