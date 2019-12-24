using UnityEngine;

namespace Helper {
    public class SpotLightStart : MonoBehaviour {
        private void Awake() {
            GetComponent<Light>().intensity = 2.71f;
        }
    }
}