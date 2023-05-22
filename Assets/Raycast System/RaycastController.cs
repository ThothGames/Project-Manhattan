using System;
using UnityEngine;

namespace Bipolar.RaycastSystem
{
    public abstract class RayProvider : MonoBehaviour
    {
        public abstract Ray GetRay();
    }

    public class RaycastController : MonoBehaviour
    {
        public enum RaycastType
        {
            Forward,
            Cursor,
        }


        public event Action<RaycastTarget> OnRayEnter;
        public event Action<RaycastTarget> OnRayExit;

        [Header("Settings")]
        [SerializeField]
        private new Camera camera;

        [SerializeField]
        private RayFromMouseProvider cursorRayProvider;

        [SerializeField]
        private TransformForwardRayProvider forwardRayProvider;

        [SerializeField]
        private LayerMask raycastedLayers;
        public LayerMask RaycastedLayers 
        { 
            get => raycastedLayers; 
            set => raycastedLayers = value; 
        }
        
        [SerializeField]
        private float raycastDistance;
        public float RaycastDistance
        {
            get => raycastDistance;
            set => raycastDistance = value;
        }
        
        [Header("States")]
        [SerializeField]
        private RaycastType raycastMode;
        public RaycastType RaycastMode
        {
            get => raycastMode;
            set => raycastMode = value;
        }
        
        [SerializeField]
        private RaycastTarget currentTarget;
        public RaycastTarget Target => currentTarget;

        private Ray ray;

        private void Reset()
        {
            if (camera == null)
                camera = GetComponent<Camera>();
        }

        private void Awake()
        {
            if (camera == null)
                camera = Camera.main;
        }

        private void Update()
        {
            DoRaycast();
        }

        private void DoRaycast()
        {
            RayProvider provider = (raycastMode == RaycastType.Cursor) ? cursorRayProvider : forwardRayProvider as RayProvider;
            ray = provider.GetRay();
            if (TryGetRaycastTarget(ray, out var target))
            {
                if (target != currentTarget)
                {
                    if (currentTarget != null)
                        CallExitEvents(currentTarget);

                    currentTarget = target;
                    if (target != null)
                        CallEnterEvents(target);
                }
                else
                {
                    currentTarget.RayStay();
                }
            }
            else
            {
                if (currentTarget != null)
                {
                    var exitedTarget = currentTarget;
                    currentTarget = null;
                    CallExitEvents(exitedTarget);
                }
            }
        }

        private bool TryGetRaycastTarget(Ray ray, out RaycastTarget target)
        {
            target = null;
            if (Physics.Raycast(ray, out var hit, raycastDistance, raycastedLayers) == false)
                return false;

            if (hit.collider.TryGetComponent<RaycastCollider>(out var raycastCollider) == false)
                return false;

            return TryGetRaycastTarget(raycastCollider, out target);
        }

        private void ProcessHit(RaycastHit hit)
        {

        }

        static bool TryGetRaycastTarget(RaycastCollider collider, out RaycastTarget target)
        {
            target = collider.RaycastTarget;
            return target != null;
        }

        private void CallEnterEvents(RaycastTarget target)
        {
            OnRayEnter?.Invoke(target);
            target.RayEnter();
        }

        private void CallExitEvents(RaycastTarget target)
        {
            OnRayExit?.Invoke(target);
            target.RayExit();
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawRay(ray.origin, ray.direction * raycastDistance);
        }

    }
}