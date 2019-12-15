using System;
using Guns;
using UnityEngine;

namespace Controller {
    public class WeaponController : MonoBehaviour {
        public Transform bulletPrefab;
        public GameObject gun;

        public Weapon weapon { get; private set; }

        public void setWeapon<T>() where T : Weapon {
            if (weapon != null) {
                Destroy(weapon);
            }

            weapon = gun.AddComponent<T>();
            var newGun = weapon as Gun;
            if (newGun != null) {
                newGun.bulletPrefab = bulletPrefab;
            }
        }

        private void Start() {
            weapon = gun.GetComponent<Weapon>();
        }
    }
}