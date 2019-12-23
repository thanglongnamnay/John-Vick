using System;
using UnityEngine;

namespace Controller.UI {
    public class FlyIn : MonoBehaviour {
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
                var transform1 = transform;
                var position = transform1.position;
                var delta = new Vector3();
                if (transform1.parent) {
                    delta = transform1.parent.position + Vector3.forward;
                }
                position = Vector3.Lerp(position, delta + _flyInPos, .1f);
                transform.position = position;
            } else if (!isFlyIn && Math.Abs(transform.position.x - positions.y) > .1f) {
                var transform1 = transform;
                var position = transform1.position;
                var delta = new Vector3();
                if (transform1.parent) {
                    delta = transform1.parent.position + Vector3.forward;
                }
                position = Vector3.Lerp(position, delta + _flyOutPos, .1f);
                transform.position = position;
            }
        }

        public void flyOut() {
            Debug.Log("fly out");
            isFlyIn = false;
        }

        public void flyIn() {
            isFlyIn = true;
        }
    }
}