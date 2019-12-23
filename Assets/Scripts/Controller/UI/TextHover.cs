using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Controller.UI {
    public enum MenuItem {
        Play,
        Instruction,
        Exit
    }

    [RequireComponent(typeof(AudioSource))]
    internal class TextHoverEventTrigger : EventTrigger {

        public FlyIn instructionFlyIn;
        [SerializeField] 
        public MenuItem menuItem = MenuItem.Play;
        
        private AudioSource _audio;

        private void Start() {
            _audio = GetComponent<AudioSource>();
        }

        private void hoverIn() {
            _audio.Play();
            transform.localScale = new Vector3(1.25f, 1.25f, 1);
        }

        private void hoverOut() {
            transform.localScale = new Vector3(1, 1, 1);
        }

        private void OnEnable() {
            hoverOut();
        }

        private static void play() {
            SceneManager.LoadScene("level1");
        }

        private void instruction() {
            instructionFlyIn.flyIn();
        }

        private static void exit() {
            Application.Quit();
        }

        public override void OnPointerEnter(PointerEventData eventData) {
            hoverIn();
        }
        
        public override void OnPointerExit(PointerEventData eventData) {
            hoverOut();
        }

        public override void OnPointerClick(PointerEventData eventData) {
            switch (menuItem) {
                case MenuItem.Play:
                    play();
                    break;
                case MenuItem.Instruction:
                    instruction();
                    break;
                case MenuItem.Exit:
                    exit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class TextHover : MonoBehaviour {
        public MenuItem menuItem = MenuItem.Play;
        public FlyIn instructionFlyIn;

        private void Start() {
            var com = gameObject.AddComponent<TextHoverEventTrigger>();
            com.menuItem = menuItem;
            com.instructionFlyIn = instructionFlyIn;
        }
    }
}