using System;

namespace Emrgry.Core
{
    public interface IEventBus
    {
        void Subscribe<T>(Action<T> callback) where T : struct;
        void Unsubscribe<T>(Action<T> callback) where T : struct;
        void Publish<T>(T evt) where T : struct;
    }
}
