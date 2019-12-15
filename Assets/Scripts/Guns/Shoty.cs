using Controller;
using UnityEngine;

namespace Guns {
    public class Shoty : Gun {
        public override Sprite renderedSprite {
            get { return GameController.instance.gunSprites[0]; }
        }

        public override float damage {
            get { return 25; }
        }

        public override float fireRate {
            get { return .8f; }
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
            get { return 10; }
        }

        protected override void playAnimation() {
            Debug.Log("Shoot anim here");
        }
        
        protected override void reload() {
            base.reload();
            Debug.Log("Reload anim here");
        }

        protected override void makeBullet() {
            var angles = shootAngle;
            for (var i = 0; i < 3; ++i) {
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angles - 15 + 15*i));
                bullet.GetComponent<Bullet>().damage = damage;
                bullet.GetComponent<Bullet>().owner = owner;
            }
        }
    }
}