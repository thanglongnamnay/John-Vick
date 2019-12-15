using UnityEngine;

namespace Controller {
    [RequireComponent(typeof(Movable))]
    public class KeyboardControl : MonoBehaviour {
        private Movable _movable;

        private void Start() {
            _movable = GetComponentInChildren<Movable>();
        }
        private void FixedUpdate ()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            _movable.move(new Vector2(moveHorizontal, moveVertical));
        }
    }
}