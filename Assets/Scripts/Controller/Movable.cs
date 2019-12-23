using Units;
using UnityEngine;

namespace Controller {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movable : MonoBehaviour {
        public Unit unit;
        public const float MoveScale = 5;
        public float speed;
        public Vector2 direction;
        private float _moveConstrainX;
        private float _moveConstrainY;
        private Rigidbody2D _body;

        private void Start() {
            var height = Camera.main.orthographicSize;
            _moveConstrainY = GameController.instance.moveConstrain.y * height;
            _moveConstrainX = GameController.instance.moveConstrain.x * height;
            _body = GetComponent<Rigidbody2D>();
            if (!unit) unit = GetComponent<Unit>();
        }

//        private void Update() {
//            if (direction == Vector2.zero) return;
//            var distance = direction.normalized;
//            if (1 > direction.magnitude) distance = direction;
//            var newPos = transform.position + new Vector3(
//                distance.x * speed * Time.deltaTime * MoveScale,
//                distance.y * speed * Time.deltaTime * MoveScale, 
//                0);
//            newPos.y = Math.Max(newPos.y, _moveConstrainX);
//            newPos.y = Math.Min(newPos.y, _moveConstrainY);
//
//            transform.position = newPos;
//        }

        private void Update() {
            var transform1 = transform;
            var position = transform1.position;
//            Debug.Log(position);
            if (position.y < _moveConstrainX) position.y = _moveConstrainX;
            if (position.y > _moveConstrainY) position.y = _moveConstrainY;
            transform1.position = position;
        }

        private void FixedUpdate() {
            if (direction == Vector2.zero || unit.hp <= 0) {
                _body.velocity = Vector2.zero;
            } else {
                var velocity = MoveScale * speed * direction.normalized;
                velocity.y /= 2;
                _body.velocity = velocity;
            }
        }
    }
}