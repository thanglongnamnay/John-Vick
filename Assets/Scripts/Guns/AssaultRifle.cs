
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
            get { return 3; }
        }

        public override int config {
            get { return 1; }
        }

        protected override void playAttackAnimation() {
            //todo shoot anim
        }

        protected override void playReloadAnimation() {
            // todo anim
        }

        protected override void makeBullet() {
            base.makeBullet();
            var bullet = Instantiate(bulletPrefab, barrelPosition, Quaternion.Euler(0, 0, shootAngle));
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().owner = owner;
        }

        public override void onUpdate() {
            base.onUpdate();
            if (Input.GetMouseButton(0)) {
                attack();
            }
        }
    }
}