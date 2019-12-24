using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Controller.UI {
    public enum MenuItem {
        Play,
        Instruction,
        Exit,
        PlayAgain,
        BackToMain,
        NextLevel,
        Easy,
        Medium,
        Hard
    }
    internal class MainMenuEventTrigger : EventTrigger {
        [FormerlySerializedAs("instructionFlyIn")] public FlyIn flyIn;
        public MenuItem item;
        public GameObject menuParent;
        
        public override void OnPointerClick(PointerEventData eventData) {
            switch (item) {
                case MenuItem.Play:
//                    if (menuParent != null) menuParent.SetActive(false);
                    flyIn.flyIn();
                    break;
                case MenuItem.Instruction:
                    flyIn.flyIn();
                    break;
                case MenuItem.Exit:
                    Application.Quit();
                    break;
                case MenuItem.PlayAgain:
                    GameController.score = 0;
                    GameController.instance.loadScene(SceneManager.GetActiveScene().buildIndex);
                    break;
                case MenuItem.BackToMain:
                    GameController.instance.loadScene(0);
                    break;
                case MenuItem.Easy:
                    GameController.hardLevel = 1;
                    GameController.level = 1;
                    GameController.score = 0;
                    GameController.instance.loadScene(1);
                    break;
                case MenuItem.Medium:
                    GameController.hardLevel = 2;
                    GameController.level = 1;
                    GameController.score = 0;
                    GameController.instance.loadScene(1);
                    break;
                case MenuItem.Hard:
                    GameController.hardLevel = 3;
                    GameController.level = 1;
                    GameController.score = 0;
                    GameController.instance.loadScene(1);
                    break;
                case MenuItem.NextLevel:
                    GameController.nextLevel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class MenuController : MonoBehaviour {
        [FormerlySerializedAs("instructionFlyIn")] public FlyIn flyIn;
        public MenuItem item;
//        public GameObject menuParent;
        private void Start() {
            var trigger = gameObject.AddComponent<MainMenuEventTrigger>();
            trigger.item = item;
            trigger.flyIn = flyIn;
//            trigger.menuParent = menuParent;
        }
    }
}