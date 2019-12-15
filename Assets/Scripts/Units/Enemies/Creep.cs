using System;
using Controller;
using Melees;

namespace Units.Enemies {
    public class Creep : Enemy {
        private float _minDistance;
        protected override void Start() {
            base.Start();
            hp = 30;
            _minDistance = GetComponentInChildren<MeleeCollider>().colliderSize;
        }

        private void Update() {
            var distanceToPlayer = GameController.instance.player.transform.position - transform.position;
            if (distanceToPlayer.magnitude >= _minDistance) _movable.direction = distanceToPlayer;
            else weapon.attack();
        }
    }
}