using System;
using UnityEngine;

namespace Helper {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Dropping : MonoBehaviour {
        public float distance;
        public float speed;

        private Vector3 _original;
        private Rigidbody2D _body;

        private void Start() {
            _body = GetComponent<Rigidbody2D>();
            _body.gravityScale = 1;
            _original = transform.position;
        }

        private void Update() {
            if (Vector2.Distance(transform.position, _original) >= distance) {
                _body.gravityScale = 0;
                _body.velocity = Vector2.zero;
                Destroy(this);
            }
        }
    }
}