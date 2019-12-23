using UnityEngine;

namespace Controller {
    public class MouseLock : MonoBehaviour {
        public static MouseLock instance;
        public float slowFactor = .5f;

        private bool _slowing;
        private bool _locking;
        private float _oldTimescale = 1;

        public MouseLock() {
            _locking = false;
            instance = this;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                handleSlow();
            } else if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButtonDown(1)) {
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
                _oldTimescale = Time.timeScale;
                Time.timeScale = 0;
            } else {
                _locking = true;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = _oldTimescale;
            }
        }
    }
}