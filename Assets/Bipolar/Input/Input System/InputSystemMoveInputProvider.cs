#if ENABLE_INPUT_SYSTEM
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bipolar.Input.InputSystem
{
    public class InputSystemMoveInputProvider : MonoBehaviour, IMoveInputProvider
    {
        [SerializeField]
        private InputActionReference moveAction;

        private void OnEnable()
        {
            moveAction.action.Enable();
        }

        public float GetHorizontal()
        {
            return moveAction.action.ReadValue<Vector2>().x;
        }

        public float GetVertical()
        {
            return moveAction.action.ReadValue<Vector2>().y;
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
        }
    }
}
#endif
