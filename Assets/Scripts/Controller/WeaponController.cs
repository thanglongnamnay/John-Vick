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

        private Weapon _weapon;

        public Weapon weapon {
            get { return _weapon; }
            private set {
                Debug.Log("weapon set: " + value);
                _weapon = value;
            }
        }

        public T setWeapon<T>() where T : Weapon {
            if (!weapon) weapon = weaponGameObject.GetComponent<Weapon>();
            var gun = weapon as Gun;
            float curRecoil = 0;
            if (gun != null) curRecoil = gun.currentRecoil; 
            Assert.IsNotNull(weapon);
            if (weapon != null) {
                Destroy(weapon);
                Debug.Log("weapon replaced");
            }

            var weapon1 = weaponGameObject.AddComponent<T>();
            weapon1.owner = unit;
            var newGun = weapon1 as Gun;
            if (newGun != null) {
                newGun.currentRecoil = curRecoil;
            }

            var newMelee = weapon1 as Melee;
            if (newMelee != null) {
                newMelee.meleeCollider = meleeCollider;
            }

            Assert.IsNotNull(weapon1);
            weapon = weapon1;
            return weapon1;
        }

        private void Awake() {
            unit = GetComponentInParent<Unit>();
            Assert.IsNotNull(unit);
            meleeCollider = GetComponentInChildren<MeleeCollider>();
            Assert.IsNotNull(meleeCollider);
            meleeCollider.unit = unit;
            weapon = weaponGameObject.GetComponent<Weapon>();
            Assert.IsNotNull(weapon);
        }
    }
}