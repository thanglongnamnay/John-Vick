using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller {
    public class EnemySpawner : MonoBehaviour {
        public GameObject[] prefabs;
        public GameObject boss;
        public float spawnInterval = 4;
        public int maxSpawn = 50;

        private bool _bossSpawned;
        private float _lastSpawnTime;
        private bool _stop;

        private void Update() {
            if (_stop || Time.time - _lastSpawnTime < spawnInterval - GameController.level) return;
            _lastSpawnTime = Time.time;
            var instanceHardLevel = GameController.hardLevel / 20f;
            Debug.Log("maxSpawn: " + maxSpawn);
            if (!_bossSpawned && maxSpawn <= 0) {
                Debug.Log("Spawn boss");
                _bossSpawned = true;
                randomSpawn();
                randomSpawn();
                randomSpawn();
                randomSpawn();
                Instantiate(boss,
                    transform.position + new Vector3(Random.Range(7f, 12f), Random.Range(-5f, .5f)),
                    Quaternion.identity);

                return;
            }
            randomSpawn();
            if (Random.value > .6f - instanceHardLevel) {
                randomSpawn();
            }
            if (Random.value > .9f - instanceHardLevel) {
                randomSpawn();
            }
        }

        private void randomSpawn() {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)],
                transform.position + new Vector3(Random.Range(7f, 12f), Random.Range(-5f, .5f)),
                Quaternion.identity);
            maxSpawn -= 1;
        }

        public void stop() {
            _stop = true;
        }
    }
}