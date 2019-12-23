using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.UI {
    public class FadeOut : MonoBehaviour {
        private Image _image;
        [SerializeField] private bool _fading;
        private void Start() {
            _image = GetComponentInChildren<Image>();
            _image.gameObject.SetActive(false);
        }

        public IEnumerator fade() {
            _fading = true;
            yield return new WaitForSeconds(1);
        }

        private void Update() {
            if (!_fading) return;
            _image.gameObject.SetActive(true);
            var color = _image.color;
            color.a += Time.deltaTime;
            _image.color = color;
        }
    }
}