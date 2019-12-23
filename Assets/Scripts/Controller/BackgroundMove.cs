using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controller {
    public class BackgroundMove : MonoBehaviour {
        public Transform[] backgrounds = new Transform[3];
        
        [SerializeField] private float _sizeX;

        private void Start() {
            Assert.IsNotNull(backgrounds[0]);
            Assert.IsNotNull(backgrounds[1]);
            Assert.IsNotNull(backgrounds[2]);
            _sizeX = (backgrounds[1].position - backgrounds[0].position).x;
        }

        private void Update() {
            foreach (var background in backgrounds) {
                Vector2 distance = transform.position - background.position;
                if (distance.magnitude >= _sizeX * 2) {
                    background.position += distance.x > 0 ? 3 * _sizeX * Vector3.right : 3 * _sizeX * Vector3.left;
                }
            }
        }
    }
}