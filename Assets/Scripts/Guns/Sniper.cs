using UnityEngine;

namespace Guns {
    public class Sniper : Gun {
        public override float damage {
            get { return 50; }
        }

        public override float fireRate {
            get { return 1; }
        }

        public override int magSize {
            get { return 10; }
        }

        public override float reloadTime {
            get { return 3; }
        }

        public override float recoil {
            get { return 15; }
        }

        public override float inaccuracy {
            get { return 0; }
        }

        public override float bulletSpeed {
            get { return 80; }
        }

        public override int config {
            get { return 3; }
        }

        public override string weaponName {
            get { return "Mosin Nagan"; }
        }

        protected override void playAttackAnimation() {
            //todo anim
        }

        protected override void makeBullet() {
            base.makeBullet();
            var bullet = pool.getGameObject("bullet", barrelPosition, Quaternion.Euler(0, 0, shootAngle));
            var component = bullet.GetComponent<Bullet>();
            component.speed = bulletSpeed;
            component.damage = damage;
            component.owner = owner;
            component.isPenetrable = true;
        }

        protected override void playReloadAnimation() {
            // todo anim
        }
    }
}