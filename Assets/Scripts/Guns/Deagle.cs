using UnityEngine;

namespace Guns {
    public class Deagle : Gun {
        public override float damage {
            get { return 13; }
        }

        public override float fireRate {
            get { return .3f; }
        }

        public override int magSize {
            get { return 7; }
        }

        public override float reloadTime {
            get { return 1;  }
        }

        public override float recoil {
            get { return 15; }
        }

        public override float inaccuracy {
            get { return 2; }
        }

        public override float bulletSpeed {
            get { return 40; }
        }

        public override int config {
            get { return 0; }
        }

        protected override void playAttackAnimation() {
            // todo anim
        }

        protected override void playReloadAnimation() {
            //todo anim
        }

        public override string weaponName {
            get { return "Desert Eagle"; }
        }

        protected override void makeBullet() {
            base.makeBullet();
            var bullet = pool.getGameObject("bullet", barrelPosition, Quaternion.Euler(0, 0, shootAngle));
            var component = bullet.GetComponent<Bullet>();
            component.speed = bulletSpeed;
            component.damage = damage;
            component.owner = owner;
        }
    }
}