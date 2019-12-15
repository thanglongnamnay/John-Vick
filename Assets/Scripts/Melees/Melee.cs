using UnityEngine;

namespace Melees {
    public abstract class Melee : Weapon {
        private float _lastAttackTime = 0;

        public float lastAttackTime {
            private get { return _lastAttackTime; }
            set { _lastAttackTime = value; }
        }

        public abstract int durable { get; }

        protected override void playAnimation() {
            Debug.Log("Play melee animation here");
            //todo: play anim
        }

        protected override bool canAttack() {
            return Time.time - _lastAttackTime < fireRate;
        }
    }
}