using UnityEngine;

namespace Controller {
    public class Movable : MonoBehaviour {
        public float speed;

        public void move(Vector2 direction) {
            transform.position += new Vector3(direction.x * speed, direction.y * speed, 0);
        }
    }
}