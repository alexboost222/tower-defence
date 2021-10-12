using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class Turret : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private Projectile projectilePrefab;

    private Coroutine _shootingCoroutine;
    private float _timeToNextShot;
    private Vector2 _aimPoint;

    private float TimeBetweenShots => fireRate <= 0 ? 0 : 1 / fireRate;

    public void OnShoot(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started && _shootingCoroutine == null)
            _shootingCoroutine = StartCoroutine(ShootingCoroutine());
        else if (callbackContext.canceled && _shootingCoroutine != null)
        {
            StopCoroutine(_shootingCoroutine);
            _shootingCoroutine = null;
        }
    }

    public void OnAim(InputAction.CallbackContext callbackContext) => _aimPoint = callbackContext.ReadValue<Vector2>();

    private void PerformShot() => Instantiate(projectilePrefab).Direction = transform.forward;

    private void Update()
    {
        if (_timeToNextShot > 0) _timeToNextShot -= Time.deltaTime;
        
        Ray ray = Camera.main.ScreenPointToRay(_aimPoint);
        
        if (Physics.Raycast(ray, out RaycastHit hit)) transform.LookAt(hit.point);
    }

    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            if (_timeToNextShot <= 0)
            {
                PerformShot();
                _timeToNextShot = TimeBetweenShots;
            }

            yield return null;
        }
    }
}