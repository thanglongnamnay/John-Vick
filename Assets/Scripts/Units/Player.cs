using System.Collections;
using UnityEngine;

namespace Units {
    public class Player : Unit {
        private float _lastDodgeTime = 0;
        private const float DodgeCooldown = 3;
        public override UnitType type {
            get { return UnitType.Player; }
        }

        private float _tempEvasion;
        public override float evasion { get; protected set; }

        protected override void Start() {
            base.Start();
            hp = 100;
//            moveSpeed = .75f;
        }

        public void dodge() {
            if (Time.time - _lastDodgeTime >= DodgeCooldown) {
                _tempEvasion = evasion;
                evasion = 1;

                StartCoroutine(resetEvasion());
            }
        }

        IEnumerator resetEvasion() {
            yield return new WaitForSeconds(.5f);
            evasion = _tempEvasion;
        }
    }
}