using System.Collections;
using Controller;
using Guns;
using UnityEngine;

namespace Units.Enemies {
    public class Archer : Enemy {
        private Transform _box;
        private float _minDistance = 15;

        protected override void Awake() {
            base.Awake();
            maxHp = 20;
            hp = 20;
            _box = transform.Find("box");
        }

        private void Start() {
            randomWeapon(WeaponType.Gun);
            StartCoroutine(lookAtPlayer());
        }

        private IEnumerator lookAtPlayer() {
            while (GameController.instance.player != null) {
//                Debug.Log(weapon);
                var weaponControllerTransform = weaponController.transform;
                var angle = Vector2.SignedAngle(player.transform.position - weaponControllerTransform.position,
                                weaponControllerTransform.right) +
                            Random.value * (72f / (GameController.level + 2) / GameController.hardLevel);
                weaponControllerTransform.Rotate(0, 0, -angle);
                yield return new WaitForSeconds(.5f);
            }
        }

        protected override void onDead(float after = 0) {
            base.onDead(after);
            _box.parent = null;
        }

        private void Update() {
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
                    var transform1 = transform;
                    var instantiate = Instantiate(GameController.instance.creepPrefab, transform1.position, transform1.rotation);
                    instantiate.GetComponent<Unit>().hp = hp;
                    onDead(-1);
                }
            }
        }
    }
}