using System;
using Guns;
using Melees;
using Units;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controller {
    public class WeaponController : MonoBehaviour {
        public Unit unit;
        public Transform bulletPrefab;
        public MeleeCollider meleeCollider { get; private set; }
        public GameObject weaponGameObject;

        public Weapon weapon { get; private set; }

        public void setWeapon<T>() where T : Weapon {
            if (weapon != null) {
                Destroy(weapon);
            }

            weapon = weaponGameObject.AddComponent<T>();
            var newGun = weapon as Gun;
            if (newGun != null) {
                newGun.bulletPrefab = bulletPrefab;
            }

            var newMelee = weapon as Melee;
            if (newMelee != null) {
                newMelee.meleeCollider = meleeCollider;
            }
        }

        private void Start() {
            meleeCollider = GetComponentInChildren<MeleeCollider>();
            Assert.IsNotNull(meleeCollider);
            meleeCollider.unit = unit;
            Debug.Log("meleeCollider.unit set");
            weapon = weaponGameObject.GetComponent<Weapon>();
            Assert.IsNotNull(weapon);
        }
    }
}