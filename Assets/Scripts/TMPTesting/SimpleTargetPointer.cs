using System;
using MVPPassiveView.Models.ProjectileTargets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    public class SimpleTargetPointer : MonoBehaviour
    {
        public event Action<IProjectileTarget> TargetPointed;

        [SerializeField] private float raycastDistance;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Camera raycastCamera;

        private Vector2 _mousePosition;

        public void HandlePointerMove(InputAction.CallbackContext callbackContext) =>
            _mousePosition = callbackContext.ReadValue<Vector2>();

        public void HandlePointAttempt(InputAction.CallbackContext callbackContext)
        {
            if (!callbackContext.performed) return;
            
            PointAttempt(_mousePosition);
        }

        private void PointAttempt(Vector2 pixel)
        {
            Ray ray = raycastCamera.ScreenPointToRay(pixel);
            
            if (!Physics.Raycast(ray, out RaycastHit hit, raycastDistance, layerMask)) return;
            
            if (!hit.transform.TryGetComponent(out IProjectileTargetSource targetSource)) return;
            
            TargetPointed?.Invoke(targetSource.Target);
        }
    }
}