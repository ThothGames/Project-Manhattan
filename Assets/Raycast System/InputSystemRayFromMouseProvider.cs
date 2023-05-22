using UnityEngine;
using UnityEngine.InputSystem;

namespace Bipolar.RaycastSystem
{
#if ENABLE_INPUT_SYSTEM
    public class InputSystemRayFromMouseProvider : RayFromMouseProvider
    {
        protected override Vector2 GetScreenPosition()
        {
            return Mouse.current.position.ReadValue();
        }
    }
#endif
}