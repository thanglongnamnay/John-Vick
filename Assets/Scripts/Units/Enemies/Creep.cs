using System.Collections;
using Melees;
using UnityEngine;

namespace Units.Enemies {
    public class Creep : Enemy {
        private float _minDistance;
        protected override void Awake() {
            base.Awake();
            maxHp = 35;
            hp = 35;
            moveSpeed = 1.25f;
            _minDistance = GetComponentInChildren<MeleeCollider>().colliderSize;
            StartCoroutine(setMeleeWeapon());
            StartCoroutine(lookAtPlayer());
        }

        private IEnumerator setMeleeWeapon() {
            yield return new WaitForSeconds(0);
            if (weapon.type == WeaponType.Gun) {
                randomWeapon(WeaponType.Melee);
            }
        }

        private IEnumerator lookAtPlayer() {
            while (player != null) {
                var weaponControllerTransform = weaponController.transform;
                var angle = Vector2.SignedAngle(player.transform.position - weaponControllerTransform.position,
                                weaponControllerTransform.right);
                weaponControllerTransform.Rotate(0, 0, -angle);
                yield return new WaitForSeconds(.5f);
            }
        }

        protected virtual void Update() {
            if (player == null) return;

            var distanceToPlayer = player.transform.position - transform.position;
            var magnitude = ((Vector2) distanceToPlayer).magnitude;
            
            if (magnitude >= _minDistance && magnitude <= 15) {
                movable.direction = distanceToPlayer;
            }
            else {
                movable.direction = Vector2.zero;
                if (magnitude <= _minDistance && weapon.canAttack()) {
                    weapon.attack();
                }
            }
        }
    }
}