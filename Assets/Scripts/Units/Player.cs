using Guns;
using Melees;
using UnityEngine;

namespace Units {
    public class Player : Unit {
        private float _lastDodgeTime = 0;
        private const float DodgeCooldown = 3;
        public override UnitType type {
            get { return UnitType.Player; }
        }

        private float _tempEvasion;
        public int deagleMag = 14;
        public override float evasion { get; set; }

        protected override void Awake() {
            base.Awake();
            maxHp = 100;
            hp = 100;
            setWeapon<Shoty>();
//            moveSpeed = .75f;
        }

//        private void OnEnable() {
//            var dodge = gameObject.AddComponent<Dodge>();
//            skills.Add(dodge);
//        }

        protected override void onDead(float after = 0) {
            GetComponentInChildren<Animator>().Play("Hurt");
            base.onDead(after + 1);
        }

        public void swichWeapon() {
            if (weapon is Gun) {
                var deagle = weapon as Deagle;
                if (deagle != null) {
                    deagleMag = deagle.magNum * 7 + deagle.mag;
                }
                setWeapon<Hand>();
            } else {
                setWeapon<Deagle>();
                var deagle = weapon as Deagle;
                deagle.magNum = deagleMag / 7;
                deagle.mag = deagleMag % 7;
            }
        }
        
    }
}