using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Controller.UI {
    public enum MenuItem {
        Play,
        Instruction,
        Exit,
        PlayAgain,
        BackToMain
    }
    internal class MainMenuEventTrigger : EventTrigger {
        public FlyIn instructionFlyIn;
        public MenuItem item;
        
        public override void OnPointerClick(PointerEventData eventData) {
            switch (item) {
                case MenuItem.Play:
                    SceneManager.LoadScene("level1");
                    break;
                case MenuItem.Instruction:
                    instructionFlyIn.flyIn();
                    break;
                case MenuItem.Exit:
                    Application.Quit();
                    break;
                case MenuItem.PlayAgain:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                case MenuItem.BackToMain:
                    SceneManager.LoadScene("Intro");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class MenuController : MonoBehaviour {
        public FlyIn instructionFlyIn;
        public MenuItem item;
        private void Start() {
            var trigger = gameObject.AddComponent<MainMenuEventTrigger>();
            trigger.item = item;
            trigger.instructionFlyIn = instructionFlyIn;
        }
    }
}