using UnityEngine;

namespace Controller {
    public class Movable : MonoBehaviour {
        public float speed;
        public Vector2 direction;
        public const float MoveScale = 5;
        private void Update() {
            if (direction == Vector2.zero) return;;
            var distance = direction.normalized;
            if (distance.magnitude > direction.magnitude) distance = direction;
            transform.position += new Vector3(
                distance.x * speed * Time.deltaTime * MoveScale,
                distance.y * speed * Time.deltaTime * MoveScale, 
                0);
        }
    }
}