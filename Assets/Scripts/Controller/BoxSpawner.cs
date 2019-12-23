using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller {
    public class BoxSpawner : MonoBehaviour {
        public GameObject box;
        public float distance = 5;
        
        private float _lastPos;

        private void Update() {
            var position = transform.position;
            if (position.x - _lastPos > distance) {
                _lastPos = position.x;
                Instantiate(box,
                    position + new Vector3(Random.Range(7f, 12f), Random.Range(-5f, .5f)),
                    Quaternion.identity);
            }
        }
    }
}