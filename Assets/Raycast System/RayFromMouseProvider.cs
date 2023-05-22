using UnityEngine;

namespace Bipolar.RaycastSystem
{
    public abstract class RayFromMouseProvider : RayProvider
    {
        [SerializeField]
        private new Camera camera;

        private void Reset()
        {
            camera = GetComponent<Camera>();
        }

        public override Ray GetRay()
        {
            Vector2 screenMousePosition = GetScreenPosition();
            return camera.ScreenPointToRay(screenMousePosition);
        }

        protected abstract Vector2 GetScreenPosition();
    }
}