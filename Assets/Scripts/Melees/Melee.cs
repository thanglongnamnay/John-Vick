using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Melees {
    public abstract class Melee : Weapon {
        private float _lastAttackTime = 0;
        public MeleeCollider meleeCollider;

        public float lastAttackTime {
            private get { return _lastAttackTime; }
            set { _lastAttackTime = value; }
        }

        public override WeaponType type {
            get { return WeaponType.Melee; }
        }

        public abstract int durable { get; set; }
        public override void attack() {
            base.attack();
            if (canAttack()) {
                _lastAttackTime = Time.time;
                StartCoroutine(enableMeleeCollider());
                durable -= 1;
            }
        }

        private IEnumerator enableMeleeCollider() {
            yield return new WaitForSeconds(.5f);
            meleeCollider.enable = true;
        }

        protected override void playAttackAnimation() {
            Debug.Log("Play melee animation here");
            //todo: play anim
        }

        public override bool canAttack() {
            return Time.time - _lastAttackTime >= fireRate;
        }
    }
}