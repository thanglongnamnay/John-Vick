using System;
using Controller;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowerUps {
    public class PowerUpSpawn : MonoBehaviour {
        public GameObject prefab;
        public float spawnInterval = 5;

        private float _lastSpawnTime = -10;

        private static void randomPowerUp(GameObject powerUp) {
            var choice = Random.value * 3;
            if (choice < 1) {
                powerUp.AddComponent<Mag>();
                return;
            }
            if (choice < 2) {
                powerUp.AddComponent<Med>();
                return;
            }

            powerUp.AddComponent<Weed>();
        }

        private void Start() {
            if (!prefab) prefab = GameController.instance.powerUpPrefab;
        }

        private void Update() {
            if (Time.time - _lastSpawnTime < spawnInterval) return;
            _lastSpawnTime = Time.time;
            var powerUp = Instantiate(prefab, transform.position + new Vector3(Random.Range(2f, 5f), Random.Range(4.5f, 7.5f)),
                Quaternion.identity);
            randomPowerUp(powerUp);
        }
    }
}