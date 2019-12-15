using System;
using UnityEngine;

namespace Guns {
    public class Deagle : Gun {

        public override float damage {
            get { return 13; }
        }

        public override float fireRate {
            get { return .5f; }
        }

        public override int magSize {
            get { return 7; }
        }

        public override float reloadTime {
            get { return 1;  }
        }

        protected override void playAnimation() {
            Debug.Log("Shoot anim here");
        }

        protected override void makeBullet() {
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().owner = owner;
        }
        
        protected override void reload() {
            base.reload();
            Debug.Log("Reload anim here");
        }
    }
}