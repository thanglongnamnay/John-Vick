using Guns;
using TMPro;
using Units;
using UnityEngine;

namespace Controller.UI {
    public class DisplayMag : MonoBehaviour {
        public Player player;

        private TextMeshProUGUI _text;

        private void Start() {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            var gun = player.weapon as Gun;
            if (gun == null) {
                _text.text = "";
            }
            else {
                _text.text = "Mag: " + gun.magNum;
            }
        }
    }
}