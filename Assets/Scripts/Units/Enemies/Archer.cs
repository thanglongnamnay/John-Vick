using System.Collections;
using Controller;
using Guns;
using UnityEngine;

namespace Units.Enemies {
    public class Archer : Enemy {
        private Transform _box;
        private float _minDistance = 15;

        protected override void Start() {
            base.Start();
            maxHp = 20;
            hp = 20;
            _box = transform.Find("box");
            StartCoroutine(setRangedWeapon());
            StartCoroutine(lookAtPlayer());
        }

        IEnumerator setRangedWeapon() {
            yield return new WaitForSeconds(0);
            if (weapon.type == WeaponType.Melee) {
                randomWeapon(WeaponType.Gun);
            }
        }

        private IEnumerator lookAtPlayer() {
            while (GameController.instance.player != null) {
                var weaponControllerTransform = weaponController.transform;
                var angle = Vector2.SignedAngle(player.transform.position - weaponControllerTransform.position,
                                weaponControllerTransform.right) +
                            ((Gun)weapon).currentRecoil / 10 +
                            Random.value * (8f / GameController.instance.hardLevel);
                weaponControllerTransform.Rotate(0, 0, -angle);
                yield return new WaitForSeconds(.5f);
            }
        }

        protected override void onDead(float after = 0) {
            base.onDead(after);
            _box.parent = null;
        }

        private void Update() {
            _minDistance = 15;
            if (!player) return;
            
            if (weapon.canAttack() && Vector2.Distance(player.transform.position, transform.position) < _minDistance) {
                weapon.attack();
            }

            var gun = weapon as Gun;
            if (gun != null) {
                if (gun.mag == 0) {
                    gun.reload();
                }

                if (gun.magNum <= 0) {
                    Instantiate(GameController.instance.creepPrefab, transform.position, transform.rotation);
                    onDead(-1);
                }
            }
        }
    }
}