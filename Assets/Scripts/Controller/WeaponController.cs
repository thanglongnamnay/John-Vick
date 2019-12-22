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
            var gun = weapon as Gun;
            float curRecoil = 0;
            if (gun != null) curRecoil = gun.currentRecoil; 
            if (weapon != null) {
                Destroy(weapon);
                Debug.Log("weapon destroyed");
            }

            weapon = weaponGameObject.AddComponent<T>();
            weapon.owner = unit;
            var newGun = weapon as Gun;
            if (newGun != null) {
                newGun.currentRecoil = curRecoil;
            }

            var newMelee = weapon as Melee;
            if (newMelee != null) {
                newMelee.meleeCollider = meleeCollider;
            }
        }

        private void Start() {
            unit = GetComponentInParent<Unit>();
            Assert.IsNotNull(unit);
            meleeCollider = GetComponentInChildren<MeleeCollider>();
            Assert.IsNotNull(meleeCollider);
            meleeCollider.unit = unit;
            weapon = weaponGameObject.GetComponent<Weapon>();
            Assert.IsNotNull(weapon);
            Debug.Log("weapon controller set");
        }
    }
}