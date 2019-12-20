using Units;
using UnityEngine;

namespace Controller {
    [RequireComponent(typeof(Movable))]
    public class KeyboardControl : MonoBehaviour {
        private Movable _movable;
        private Player _player;

        private void Start() {
            _movable = GetComponentInChildren<Movable>();
            _player = GetComponent<Player>();
        }
        private void FixedUpdate ()
        {
            if (!_player) return;
            
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            _movable.direction = new Vector2(moveHorizontal, moveVertical);

            if (Input.GetKeyDown(KeyCode.F)) {
                _player.useSkill(0);
            }
        }
    }
}