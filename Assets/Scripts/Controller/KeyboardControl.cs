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
        private void Update () {
            if (!_player) return;
            
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            _movable.direction = new Vector2(moveHorizontal, moveVertical);

            if (Input.GetKeyDown(KeyCode.F)) {
                _player.useSkill(0);
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                // ReSharper disable once Unity.PreferNonAllocApi
                var hits = Physics2D.OverlapCircleAll(transform.position, 1, 1 << 2);
                foreach (var hit in hits) {
                    var dropItem = hit.GetComponent<DropItem>();
                    if (dropItem != null) {
                        dropItem.changeWeapon(_player);
                        AudioController.instance.play(AudioController.instance.empty, .5f);
                        Destroy(dropItem.gameObject);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Q)) {
                _player.swichWeapon();
            }
        }
    }
}