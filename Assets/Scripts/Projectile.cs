using UnityEngine;

[DisallowMultipleComponent]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    
    public Vector3 Direction { get; set; }

    private void Update() => transform.Translate(speed * Time.deltaTime * Direction);
}