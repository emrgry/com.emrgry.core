using UnityEngine;

namespace Emrgry.Core.Camera
{
    public interface ICameraMode
    {
        string ModeName { get; }
        void Activate();
        void Deactivate();
        void AddTarget(Transform target);
        void RemoveTarget(Transform target);
    }
}
