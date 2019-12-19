using System;
using Controller;
using Units;
using UnityEngine;

namespace PowerUps {
    public abstract class PowerUp : MonoBehaviour {
        private static Player _player;
        protected abstract void affect(Player player);

        private void OnEnable() {
            _player = GameController.instance.player;
        }

        private void OnTriggerEnter(Collider other) {
            if (other.GetComponent<Player>() != _player) return;
            affect(_player);
        }
    }
}