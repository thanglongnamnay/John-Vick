using System;
using UnityEngine;

namespace Controller {
    public class Movable : MonoBehaviour {
        public float speed;
        public Vector2 direction;
        private float _moveConstrainX;
        private float _moveConstrainY;
        public const float MoveScale = 5;

        private void Start() {
            _moveConstrainY = GameController.instance.moveConstrain.y;
            _moveConstrainX = GameController.instance.moveConstrain.x;
        }

        private void Update() {
            if (direction == Vector2.zero) return;
            var distance = direction.normalized;
            if (distance.magnitude > direction.magnitude) distance = direction;
            var newPos = transform.position + new Vector3(
                distance.x * speed * Time.deltaTime * MoveScale,
                distance.y * speed * Time.deltaTime * MoveScale, 
                0);
            newPos.y = Math.Max(newPos.y, _moveConstrainX);
            newPos.y = Math.Min(newPos.y, _moveConstrainY);

            transform.position = newPos;
        }
    }
}