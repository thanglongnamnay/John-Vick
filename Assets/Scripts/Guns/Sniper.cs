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

        protected override void playAnimation() {
            Debug.Log("Shoot anim here");
        }
        
        protected override void reload() {
            base.reload();
            Debug.Log("Reload anim here");
        }

        protected override void makeBullet() {
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            var component = bullet.GetComponent<Bullet>();
            component.damage = damage;
            bullet.GetComponent<Bullet>().owner = owner;
            component.isPenetrable = true;
        }
    }
}