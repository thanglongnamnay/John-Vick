using System;
using Units;
using Units.Enemies;
using UnityEngine;

namespace Controller {
    public class GameController : MonoBehaviour {
        public static GameController instance { get; private set; }
        public Player player {
            get { return GetComponentInChildren<Player>(); }
        }

        public Enemy[] enemyList {
            get { return GetComponentsInChildren<Enemy>(); }
        }

        private void Awake() {
            instance = this;
        }
    }
}