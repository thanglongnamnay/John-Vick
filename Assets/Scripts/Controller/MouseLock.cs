using System;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Controller {
    public class MouseLock : MonoBehaviour {
        public static MouseLock instance;
        public float slowFactor = .5f;

        private bool _slowing = false;
        private bool _locking = false;

        public MouseLock() {
            instance = this;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.LeftControl)) {
                handleSlow();
            } else if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButtonDown((int) MouseButton.RightMouse)) {
                handleLock();
            }
        }

        private void handleSlow() {
            if (_slowing) {
                _slowing = false;
                Time.timeScale = 1;
            } else {
                _slowing = true;
                Time.timeScale = slowFactor;
            }
        }
        private void handleLock() {
            if (_locking) {
                _locking = false;
                Cursor.lockState = CursorLockMode.None;
            } else {
                _locking = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}