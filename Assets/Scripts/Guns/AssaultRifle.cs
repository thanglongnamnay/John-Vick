
using UnityEngine;

namespace Guns {
    public class AssaultRifle : Gun {
        public override float damage {
            get { return 8; }
        }

        public override float fireRate {
            get { return .25f; }
        }

        public override int magSize {
            get { return 30; }
        }

        public override float reloadTime {
            get { return 1.25f; }
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
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().owner = owner;
        }
    }
}