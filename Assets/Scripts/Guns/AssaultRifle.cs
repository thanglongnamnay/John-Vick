using Controller;
using UnityEngine;

namespace Guns {
    public class AssaultRifle : Gun {
        public override float damage {
            get { return 8; }
        }

        public override float fireRate {
            get { return .085f; }
        }

        public override int magSize {
            get { return 30; }
        }

        public override float reloadTime {
            get { return 1.25f; }
        }

        public override float recoil {
            get { return 3; }
        }

        public override float inaccuracy {
            get { return 1; }
        }

        public override float bulletSpeed {
            get { return 25; }
        }

        public override int config {
            get { return 1; }
        }

        public override string weaponName {
            get { return "M4A1"; }
        }

        protected override void playAttackAnimation() {
            //todo shoot anim
        }

        protected override void playReloadAnimation() {
            // todo anim
        }

        protected override void makeBullet() {
            base.makeBullet();
            var bullet = pool.getGameObject("bullet", barrelPosition, Quaternion.Euler(0, 0, shootAngle));
            var component = bullet.GetComponent<Bullet>();
            component.speed = bulletSpeed;
            component.damage = damage;
            component.owner = owner;
        }

        public override void onUpdate() {
            base.onUpdate();
            if (Input.GetMouseButton(0)) {
                if (canAttack()) {
                    attack();
                } else if (mag == 0) {
                    Debug.Log("Play empty sound");
                    AudioController.instance.play(AudioController.instance.empty, 1, 0);
                }
            }
        }
    }
}