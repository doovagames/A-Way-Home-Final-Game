using System.Collections.Generic;
using UnityEngine;

namespace Planets
{
    public class NewAsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _asteroidPrefabs;
        [SerializeField] private Vector3 _spawnSpread;
        [SerializeField] private float _spawnRate;
        [SerializeField] private float _lifeTime;
        [SerializeField] private int _maxAsteroids;
        [SerializeField] private List<GameObject> _asteroids;
        private float _timeSinceSpawn;

        private void Update()
        {
            _timeSinceSpawn += Time.deltaTime;
            _timeSinceSpawn = Mathf.Clamp(_timeSinceSpawn, 0, _spawnRate);
            
            // Check if the asteroids have been removed.
            _asteroids.RemoveAll(item => item == null);

            if (_timeSinceSpawn >= _spawnRate && _asteroids.Count < _maxAsteroids)
            {
                _timeSinceSpawn = 0;

                // Pick the random asteroid.
                var asteroidIndex = Random.Range(0, _asteroidPrefabs.Length);
                var randomAsteroid = _asteroidPrefabs[asteroidIndex];
                
                // Pick a random position.
                var randomX = Random.Range(-_spawnSpread.x, _spawnSpread.x) + transform.position.x;
                var randomY = Random.Range(-_spawnSpread.y, _spawnSpread.y) + transform.position.y;
                var randomZ = Random.Range(-_spawnSpread.z, _spawnSpread.z) + transform.position.z;
                
                var spawnPoint = new Vector3(randomX, randomY, randomZ);
                
                // Spawn the asteroid.
                var newAsteroid = Instantiate(randomAsteroid, spawnPoint, Quaternion.identity, transform);
                _asteroids.Add(newAsteroid);
                Destroy(newAsteroid, _lifeTime);
            }
        }
    }
}