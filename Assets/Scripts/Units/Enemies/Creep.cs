using System;
using Controller;
using Melees;
using UnityEngine;

namespace Units.Enemies {
    public class Creep : Enemy {
        private float _minDistance;
        protected override void Start() {
            base.Start();
            hp = 30;
            _minDistance = GetComponentInChildren<MeleeCollider>().colliderSize;
        }

        private void Update() {
            if (GameController.instance.player == null) return;

            var distanceToPlayer = GameController.instance.player.transform.position - transform.position;
            if (distanceToPlayer.magnitude >= _minDistance) _movable.direction = distanceToPlayer;
            else {
                _movable.direction = Vector2.zero;
                weapon.attack();
            }
        }
    }
}