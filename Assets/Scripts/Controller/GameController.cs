using System;
using Controller.UI;
using Units;
using Units.Enemies;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Controller {
    [Serializable]
    public class WeaponConfig {
        public Sprite texture;
        public AudioClip shootSound;
    }
    public class GameController : MonoBehaviour {
        public GameController() {
            instance = this;
            level = 1;
            hardLevel = 1;
        }

        public static GameController instance { get; private set; }

        public Vector2 moveConstrain;
        public GameObject powerUpPrefab;

        public WeaponConfig[] gunConfig;
        public Sprite[] meleeSprites;
        public GameObject gunDrop;
        public GameObject creepPrefab;
        public FlyIn lostObject;
        public EnemySpawner enemySpawner;
        [SerializeField]
        private Player _player;
        public int hardLevel;
        public float point;

        public int level { get; private set; }
        
        public Player player {
            get { return _player; }
        }

        public Enemy[] enemyList {
            get { return GetComponentsInChildren<Enemy>(); }
        }

        public static void replay() {
            SceneManager.LoadScene("level1");
        }

        public static void backToMain() {
            SceneManager.LoadScene("Intro");
        }

        public void gameOver() {
            if (player.hp <= 0) {
                lostObject.flyIn();
                enemySpawner.stop();
            }
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