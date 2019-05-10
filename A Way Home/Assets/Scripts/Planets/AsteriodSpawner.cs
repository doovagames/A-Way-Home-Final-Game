using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroidsPrefabs; // Referencing asteriods gameobjects.
    [SerializeField] private Transform[] _spawnPoints; // Referencing spawnpoint transforms.
    [SerializeField] private float _spawnRate; // Adding Spawnrate delay;
    [SerializeField] private float _lifeTime;
    private float _timeSinceSpawn;
    

    // Update is called once per frame
    void Update()
    {
        _timeSinceSpawn += Time.deltaTime;
        _timeSinceSpawn = Mathf.Clamp(_timeSinceSpawn, 0, _spawnRate);

        if (_timeSinceSpawn >= _spawnRate)
        {
            var randomAsteroidIndex = Random.Range(0, _asteroidsPrefabs.Length - 1);
            var randomAsteroid = _asteroidsPrefabs[randomAsteroidIndex];

            var randomSpawnpointIndex = Random.Range(0, _spawnPoints.Length - 1);
            var randomSavepoint = _spawnPoints[randomSpawnpointIndex];

            var newAsteroid = Instantiate(randomAsteroid, randomSavepoint.position, Quaternion.identity);
            
            _timeSinceSpawn = 0;
            
            Destroy(newAsteroid, _lifeTime);
        }
    }
}
