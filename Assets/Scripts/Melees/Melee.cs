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

        public abstract int durable { get; }
        public override void attack() {
            base.attack();
            if (canAttack()) {
                meleeCollider.enable = true;
                _lastAttackTime = Time.time;
                durable -= 1;
            }
        }

        protected override void playAttackAnimation() {
            Debug.Log("Play melee animation here");
            //todo: play anim
        }

        protected override bool canAttack() {
            return Time.time - _lastAttackTime >= fireRate;
        }
    }
}