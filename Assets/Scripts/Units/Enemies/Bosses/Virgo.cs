using System.Collections;
using Controller;
using Guns;
using Melees;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Units.Enemies.Bosses {
    public class Virgo : Enemy {
        private Transform _box;
        private float _minDistance = 15;
        protected override void Awake() {
            base.Awake();
            maxHp = 350;
            hp = 350;
            moveSpeed = 1f;
            _box = transform.Find("box");
        }

        private void Start() {
//            setWeapon<Deagle>();
            var gun = weapon as Gun;
            gun.mag = int.MaxValue;
            gun.magNum = 10;
            StartCoroutine(lookAtPlayer());
        }

        private IEnumerator lookAtPlayer() {
            while (GameController.instance.player != null) {
                var weaponControllerTransform = weaponController.transform;
                var angle = Vector2.SignedAngle(player.transform.position - weaponControllerTransform.position,
                                weaponControllerTransform.right) +
                            Random.value * (24f / GameController.hardLevel);
                weaponControllerTransform.Rotate(0, 0, -angle);
                yield return new WaitForSeconds(.5f);
            }
        }
        
        protected override void onDead(float after = 0) {
            base.onDead(after);
            GameController.victory();
        }
        
        private void Update() {
            if (!player) return;

            foreach (var skill in skills) {
                skill.use();
            }
            
            if (weapon is Gun) {
                var gun = weapon as Gun;
                if (gun != null) {
                    if (gun.mag == 0) {
                        gun.reload();
                    }

                    if (gun.magNum <= 0) {
                        setWeapon<Knife>();
                        _box.parent = null;
                    }
                }
                if (weapon.canAttack() && Vector2.Distance(player.transform.position, transform.position) < _minDistance) {
                    weapon.attack();
                }

            } else {
                var distanceToPlayer = player.transform.position - transform.position;
                if (((Vector2) distanceToPlayer).magnitude >= _minDistance) movable.direction = distanceToPlayer;
                else {
                    movable.direction = Vector2.zero;
                    if (weapon.canAttack()) {
                        weapon.attack();
                    }
                }
            }
        }
    }
}