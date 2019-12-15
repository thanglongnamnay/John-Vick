using System;
using System.Collections;
using Guns;
using Melees;
using Units;
using Units.Enemies;
using UnityEngine;

namespace Controller {
    public class GameController : MonoBehaviour {
        public static GameController instance { get; private set; }

        public Sprite[] gunSprites;
        public Sprite[] meleeSprites;
        
        [SerializeField]
        private Player _player;

        public Player player {
            get { return _player; }
        }

        public Enemy[] enemyList {
            get { return GetComponentsInChildren<Enemy>(); }
        }

        private IEnumerator Start() {
            yield return new WaitForSeconds(5);
            Debug.Log("Weapon set");
            player.setWeapon<Knife>();
        }

        private void Awake() {
            instance = this;
        }
    }
}