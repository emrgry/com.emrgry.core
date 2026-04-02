using UnityEngine;

namespace Emrgry.Core.Camera
{
    public interface ICameraModeService
    {
        ICameraMode ActiveMode { get; }
        void SwitchMode(string modeName);
        void RegisterMode(ICameraMode mode);
        void AddTarget(Transform target);
        void RemoveTarget(Transform target);
    }
}
