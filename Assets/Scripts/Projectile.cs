using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    private Collider _collider;
    
    public Vector3 Direction { get; set; }

    private void Awake() => _collider = GetComponent<Collider>();

    private void Update()
    {
        _collider.isTrigger = true;
        transform.Translate(speed * Time.deltaTime * Direction);
    }

    private void OnTriggerEnter(Collider other) => Destroy(gameObject);
}