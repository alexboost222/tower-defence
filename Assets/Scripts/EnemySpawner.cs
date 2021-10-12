using System;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private Transform target;
    
    private float _timeToNextSpawn;

    private float TimeBetweenSpawns => spawnRate <= 0 ? 0 : 1 / spawnRate;
    
    private void Update()
    {
        _timeToNextSpawn -= Time.deltaTime;

        if (!(_timeToNextSpawn <= 0)) return;
        
        SpawnEnemy();
        _timeToNextSpawn = TimeBetweenSpawns;
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefab);
        enemy.transform.position = transform.position;
        enemy.Target = target;
    }
}