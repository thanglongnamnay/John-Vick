using System;
using System.Collections;
using Guns;
using Units;
using Units.Enemies;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controller {
    [Serializable]
    public class WeaponConfig {
        public Sprite texture;
        public AudioClip shootSound;
    }
    public class GameController : MonoBehaviour {
        public GameController() {
            Assert.IsNull(instance);
            instance = this;
            level = 1;
            hardLevel = 1;
        }

        public static GameController instance { get; private set; }

        public Vector2 moveConstrain;
        public Transform bulletPrefab;

        public WeaponConfig[] gunConfig;
        public Sprite[] meleeSprites;
        public GameObject gunDrop;
        public GameObject creepPrefab;
        public Vector2 screenSize = new Vector2(10, 10);
        [SerializeField]
        private Player _player;

        public int level { get; private set; }
        public int hardLevel { get; private set; }
        
        public Player player {
            get { return _player; }
        }

        public Enemy[] enemyList {
            get { return GetComponentsInChildren<Enemy>(); }
        }

//        private IEnumerator Start() {
//            while (player != null) {
//                yield return new WaitForSeconds(5);
//                if (!player) yield break;
//                Debug.Log("Weapon set");
////                player.setWeapon<Sniper>();
//                player.randomWeapon(WeaponType.Gun);
//            }
//        }
    }
}