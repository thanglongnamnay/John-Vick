using System.Collections;
using Skills;
using UnityEngine;

namespace Units {
    public class Player : Unit {
        private float _lastDodgeTime = 0;
        private const float DodgeCooldown = 3;
        public override UnitType type {
            get { return UnitType.Player; }
        }

        private float _tempEvasion;
        public override float evasion { get; set; }

        protected override void Start() {
            base.Start();
            maxHp = 100;
            hp = 100;
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

        IEnumerator resetEvasion() {
            yield return new WaitForSeconds(.5f);
            evasion = _tempEvasion;
        }
    }
}