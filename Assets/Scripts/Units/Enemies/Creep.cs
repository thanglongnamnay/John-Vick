using System.Collections;
using Controller;
using Melees;
using UnityEngine;

namespace Units.Enemies {
    public class Creep : Enemy {
        private float _minDistance;
        protected override void Start() {
            base.Start();
            hp = 30;
            _minDistance = GetComponentInChildren<MeleeCollider>().colliderSize;
            StartCoroutine(lookAtPlayer());
        }

        private IEnumerator lookAtPlayer() {
            while (GameController.instance.player != null) {
                var weaponControllerTransform = weaponController.transform;
                var angle = Vector2.SignedAngle(player.transform.position - weaponControllerTransform.position,
                                weaponControllerTransform.right);
                weaponControllerTransform.Rotate(0, 0, -angle);
                yield return new WaitForSeconds(.5f);
            }
        }

        protected virtual void Update() {
            if (GameController.instance.player == null) return;

            var distanceToPlayer = GameController.instance.player.transform.position - transform.position;
            if (distanceToPlayer.magnitude >= _minDistance) movable.direction = distanceToPlayer;
            else {
                movable.direction = Vector2.zero;
                weapon.attack();
            }
        }
    }
}