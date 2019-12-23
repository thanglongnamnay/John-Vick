using System;
using System.Collections;
using Controller.UI;
using TMPro;
using Units;
using Units.Enemies;
using UnityEngine;
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
        public TextMeshProUGUI highScoreText;
        public FadeOut fadeOut;
        [SerializeField]
        // ReSharper disable once InconsistentNaming
        private Player _player;
        public static int hardLevel = 1;
        public static float score = 0;
        public static int level = 1;
        private const string HighscoreKey = "highScore";
        
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
                var highScore = 0f;
                if (PlayerPrefs.HasKey(HighscoreKey)) {
                    highScore = PlayerPrefs.GetFloat(HighscoreKey);
                }
                PlayerPrefs.SetFloat(HighscoreKey, Math.Max(score, highScore));
                lostObject.flyIn();
                enemySpawner.stop();
                MouseLock.instance.handleLock();
            }
        }

        public static void victory() {
            if (level >= 3) return;
            level += 1;
            instance.loadScene(level);
        }

        public void loadScene(string s) {
            StartCoroutine(fadeOut.fade());
            StartCoroutine(_loadScene(s));
        }

        public void loadScene(int index) {
            StartCoroutine(fadeOut.fade());
            StartCoroutine(_loadScene(index));
        }

        private IEnumerator _loadScene(int index) {
            yield return new WaitForSecondsRealtime(1);
            SceneManager.LoadScene(index);
        }

        private IEnumerator _loadScene(string s) {
            yield return new WaitForSecondsRealtime(1);
            SceneManager.LoadScene(s);
        }

        private void Start() {
            if (highScoreText != null && PlayerPrefs.HasKey(HighscoreKey)) {
                highScoreText.text = "High score: " + Math.Round(PlayerPrefs.GetFloat(HighscoreKey));
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