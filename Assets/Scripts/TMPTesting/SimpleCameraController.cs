using UnityEngine;
using UnityEngine.InputSystem;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    public class SimpleCameraController : MonoBehaviour
    {
        [SerializeField] private float velocity;
        [SerializeField] private Transform target;
        [SerializeField] private InputActionReference rotateCameraAction;

        private void Update()
        {
            float input = rotateCameraAction.action.ReadValue<float>();
            
            transform.Translate(velocity * Time.deltaTime * input * Vector3.right);
            transform.LookAt(target);
        }
    }
}