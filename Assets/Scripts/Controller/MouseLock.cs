using System;
using UnityEngine;

namespace Controller {
    public class MouseLock : MonoBehaviour {
        private void Update() {
            Cursor.lockState = Input.GetKey(KeyCode.LeftControl) ? CursorLockMode.None : CursorLockMode.Locked;
            Time.timeScale = Input.GetKey(KeyCode.LeftControl) ? 0 : 1;
        }
    }
}