using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed;

    private float _rotationSpeedCoefficient;

    public void OnCameraMove(InputAction.CallbackContext callbackContext) =>
        _rotationSpeedCoefficient = callbackContext.ReadValue<float>();

    private void Update()
    {
        transform.RotateAround(target.position, Vector3.down, rotationSpeed * _rotationSpeedCoefficient * Time.deltaTime);
        transform.LookAt(target);
    }
}
