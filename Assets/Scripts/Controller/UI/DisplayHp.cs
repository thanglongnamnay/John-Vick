using System;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.UI {
    public class DisplayHp : MonoBehaviour {
        private Text _text;
        private void Start() {
            _text = GetComponent<Text>();
        }

        private void Update() {
            _text.text = "HP: " +  GameController.instance.player.hp;
        }
    }
}