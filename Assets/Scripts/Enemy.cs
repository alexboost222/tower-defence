using UnityEngine;

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    
    public Transform Target { get; set; }

    private void Update()
    {
        if (Target != null) transform.Translate(speed * Time.deltaTime * (Target.position - transform.position));
    }
}