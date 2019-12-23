using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Controller.UI {

    [RequireComponent(typeof(AudioSource))]
    internal class TextHoverEventTrigger : EventTrigger {
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
        
        public override void OnPointerEnter(PointerEventData eventData) {
            hoverIn();
        }
        
        public override void OnPointerExit(PointerEventData eventData) {
            hoverOut();
        }
    }
    public class TextHover : MonoBehaviour {
        private void Start() {
            gameObject.AddComponent<TextHoverEventTrigger>();
        }
    }
}