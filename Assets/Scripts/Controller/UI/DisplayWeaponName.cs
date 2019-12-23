using TMPro;
using Units;
using UnityEngine;

namespace Controller.UI {
    public class DisplayWeaponName : MonoBehaviour {
        public Player player;

        private TextMeshProUGUI _text;

        private void Start() {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            _text.text = "Weapon: " + player.weapon.weaponName;
        }
    }
}