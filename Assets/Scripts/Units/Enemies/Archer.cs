using System.Collections;
using Controller;
using Guns;
using UnityEngine;

namespace Units.Enemies {
    public class Archer : Enemy {
        protected override void Start() {
            base.Start();
            hp = 20;
            StartCoroutine(setRangedWeapon());
            StartCoroutine(lookAtPlayer());
        }

        IEnumerator setRangedWeapon() {
            yield return new WaitForSeconds(0);
            if (weapon.type == WeaponType.Melee) {
                randomWeapon(WeaponType.Gun);
            }
        }

        IEnumerator lookAtPlayer() {
            while (GameController.instance.player != null) {
                var weaponControllerTransform = weaponController.transform;
                var angle = Vector2.SignedAngle(player.transform.position - weaponControllerTransform.position,
                                weaponControllerTransform.right) +
                            Random.value * (8f / GameController.instance.hardNess);
                weaponControllerTransform.Rotate(0, 0, -angle);
                yield return new WaitForSeconds(.5f);
            }
        }
        
        private void Update() {
            weapon.attack();
            var gun = weapon as Gun;
            if (gun != null && gun.mag == 0) {
                gun.reload();
            }
        }
    }
}