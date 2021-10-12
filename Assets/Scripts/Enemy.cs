using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float startHealth;

    private float _health;
    
    public Transform Target { get; set; }

    private float Health
    {
        get => _health;
        set
        {
            _health = value;
            
            if (_health <= 0) Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage) => Health -= damage;
    
    private void Awake() => Health = startHealth;

    private void Update()
    {
        if (Target != null) transform.Translate(speed * Time.deltaTime * (Target.position - transform.position));
    }
}