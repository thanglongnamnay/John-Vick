using System;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Controller.UI {
    public class DisplayPoint : MonoBehaviour {
        private TextMeshProUGUI _text;

        private void Start() {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            _text.text = "Score: " + Math.Round(GameController.instance.point);
        }
    }
}