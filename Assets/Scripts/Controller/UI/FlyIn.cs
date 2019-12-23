using System;
using UnityEngine;

namespace Controller.UI {
    public class FlyIn : MonoBehaviour {
        public GameObject menu;
        public Vector2 positions;
        public bool isFlyIn;

        private Vector3 _flyInPos;
        private Vector3 _flyOutPos;
        private void Start() {
            var pos = transform.position;
            _flyInPos = pos;
            _flyInPos.x = positions.x;

            _flyOutPos = pos;
            _flyOutPos.x = positions.y;
        }

        private void Update() {
            if (isFlyIn && Math.Abs(transform.position.x - positions.x) > .1f) {
                var position = transform.position;
                position = Vector3.Lerp(position, _flyInPos, .1f);
                transform.position = position;
            } else if (!isFlyIn && Math.Abs(transform.position.x - positions.y) > .1f) {
                var position = transform.position;
                position = Vector3.Lerp(position, _flyOutPos, .1f);
                transform.position = position;
            }
        }

        public void flyOut() {
            Debug.Log("fly out");
            isFlyIn = false;
            menu.SetActive(true);
        }

        public void flyIn() {
            isFlyIn = true;
            menu.SetActive(false);
        }
    }
}