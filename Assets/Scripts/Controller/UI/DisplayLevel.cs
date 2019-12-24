using TMPro;
using UnityEngine;

namespace Controller.UI {
    public class DisplayLevel : MonoBehaviour {
        private void Start() {
            GetComponent<TextMeshProUGUI>().text = "Level: " + GameController.level;
        }
    }
}