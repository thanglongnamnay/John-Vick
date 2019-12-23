using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller {
    public class EnemySpawner : MonoBehaviour {
        public GameObject[] prefabs;
        public GameObject boss;
        public float spawnInterval = 4;
        public int maxSpawn = 50;

        private bool _bossSpawned;
        private float _lastSpawnTime = -10;

        private void Update() {
            if (Time.time - _lastSpawnTime < spawnInterval - GameController.instance.level) return;
            _lastSpawnTime = Time.time;
            var instanceHardLevel = GameController.instance.hardLevel / 20f;
            if (_bossSpawned && maxSpawn <= 0) {
                _bossSpawned = true;
                randomSpawn();
                if (Random.value > .7 - instanceHardLevel) {
                    randomSpawn();
                }
                if (Random.value > 1 - instanceHardLevel) {
                    randomSpawn();
                }
                Instantiate(boss,
                    transform.position + new Vector3(Random.Range(7f, 12f), Random.Range(-5f, .5f)),
                    Quaternion.identity);

                return;
            }
            randomSpawn();
            if (Random.value > .7 - instanceHardLevel) {
                randomSpawn();
            }
            if (Random.value > 1 - instanceHardLevel) {
                randomSpawn();
            }
        }

        private void randomSpawn() {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)],
                transform.position + new Vector3(Random.Range(7f, 12f), Random.Range(-5f, .5f)),
                Quaternion.identity);
            maxSpawn -= 1;
        }
    }
}