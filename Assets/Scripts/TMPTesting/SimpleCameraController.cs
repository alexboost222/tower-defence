using UnityEngine;
using UnityEngine.InputSystem;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    public class SimpleCameraController : MonoBehaviour
    {
        [SerializeField] private float velocity;
        [SerializeField] private Transform target;

        private float _input;

        public void HandleRotateCameraAction(InputAction.CallbackContext callbackContext) =>
            _input = callbackContext.ReadValue<float>();

        private void Update()
        {
            transform.Translate(velocity * Time.deltaTime * _input * Vector3.right);
            transform.LookAt(target);
        }
    }
}