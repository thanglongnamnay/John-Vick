using System;
using TMPro;
using UnityEngine;

namespace Controller.UI {
    public class DisplayPoint : MonoBehaviour {
        private TextMeshProUGUI _text;

        private void Start() {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            _text.text = "Score: " + Math.Round(GameController.instance.score);
        }
    }
}