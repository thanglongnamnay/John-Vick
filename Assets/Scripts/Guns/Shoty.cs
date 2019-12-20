using Controller;
using UnityEngine;

namespace Guns {
    public class Shoty : Gun {
        private const int Spread = 3;
        private const int Duck = 5;

        public override float damage {
            get { return 25; }
        }

        public override float fireRate {
            get { return .3f; }
        }

        public override int magSize {
            get { return 2; }
        }

        public override float reloadTime {
            get { return 1; }
        }

        public override float recoil {
            get { return 20; }
        }

        public override float inaccuracy {
            get { return 5; }
        }

        public override int config {
            get { return 2; }
        }

        protected override void playAttackAnimation() {
            // todo anim
        }

        protected override void playReloadAnimation() {
            // todo anim
        }

        protected override void makeBullet() {
            base.makeBullet();
            var angles = shootAngle;
            var min = Duck / 2 * Spread;
            for (var i = 0; i < Duck; ++i) {
                var bullet = Instantiate(bulletPrefab, barrelPosition, Quaternion.Euler(0, 0, angles - min + Spread*i));
                bullet.GetComponent<Bullet>().damage = damage;
                bullet.GetComponent<Bullet>().owner = owner;
            }
        }
    }
}