using Controller;
using Guns;
using UnityEngine;

namespace Units {
    public class Player : Unit {
        public override UnitType type {
            get { return UnitType.Player; }
        }

        public override float hp {
            get { return base.hp; }
            set {
                base.hp = value;
                if (value < 0) {
                    GameController.instance.gameOver();
                }
            }
        }

        private float _tempEvasion;
        private int _deagleMag = 14;
        private WeaponName _lastWeapon = WeaponName.Knife;
        public override float evasion { get; set; }

        protected override void Awake() {
            base.Awake();
            var level = GameController.level;
            maxHp = 105 + 45 * level;
            hp = 105 + 45 * level;
            if (level == 1) {
                setWeapon<Deagle>();
            } else if (level == 2) {
                setWeapon<Shoty>();
            } else if (level == 3) {
                setWeapon<AssaultRifle>();
            }

            _deagleMag = (weapon as Gun).magSize * 2;

//            moveSpeed = .75f;
        }

//        private void OnEnable() {
//            var dodge = gameObject.AddComponent<Dodge>();
//            skills.Add(dodge);
//        }

        private void Start() {
            var gun = weapon as Gun;
            if (gun != null) {
                gun.mag = (_deagleMag - 1) % gun.magSize + 1;
                gun.magNum = _deagleMag / gun.magSize;
            }
        }

        protected override void onDead(float after = 0) {
            GetComponentInChildren<Animator>().Play("Hurt");
            base.onDead(after + 1);
        }

        public void swichWeapon() {
            var currentWp = weapon.wName;
            if (weapon is Gun) {
                var gun = weapon as Gun;
                if (gun != null) {
                    _deagleMag = gun.magNum * gun.magSize + gun.mag;
                }
            }
            
            setWeapon(_lastWeapon);
            var gun2 = weapon as Gun;
            if (gun2 != null) {
                gun2.magNum = _deagleMag / gun2.magSize;
                gun2.mag = _deagleMag % gun2.magSize;

                if (gun2.magNum > 0 && gun2.mag == 0) {
                    gun2.reload();
                }
            }

            _lastWeapon = currentWp;
        }
        
    }
}