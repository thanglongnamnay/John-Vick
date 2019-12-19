using System;
using Guns;
using Units;
using UnityEngine;

namespace Controller {
    public class LookAtMouse : MonoBehaviour {
        public float maxDeltaAngle = 1;
        public Unit unit;
        public Transform cursor;
        private float _lastRecoil;
        private LineRenderer _line;
        private float _lastAngle;
        

        // Update is called once per frame
        private void Start() {
            _line = GetComponent<LineRenderer>();
        }

        private void Update () {
            if (Cursor.lockState != CursorLockMode.Locked) return;
            var delta = Vector2.ClampMagnitude(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")), 3 * MouseLock.instance.slowFactor);
            var position1 = cursor.position;
            var distance = (Vector2)position1 + delta - (Vector2)transform.position;
            var angle = Vector2.SignedAngle(Vector2.right, distance.normalized) + _lastRecoil;

            var transform1 = transform;
            var position = transform1.position;
            var right = transform1.right;
            
            position1 += (Vector3)delta;
            cursor.position = position1;
            angle = Math.Max(angle, _lastAngle - maxDeltaAngle);
            angle = Math.Min(angle, _lastAngle + maxDeltaAngle);
            angle = Math.Max(angle, -40);
            angle = Math.Min(angle, 90);
            //todo: use some setter
            var com = unit.weapon as Gun;
            if (!ReferenceEquals(com, null)) {
                angle += com.currentRecoil - _lastRecoil;
                _lastRecoil = com.currentRecoil;
            }
            
            transform1.Rotate(0, 0, angle - transform1.rotation.eulerAngles.z);
            _lastAngle = angle;
            
            _line.SetPosition(0, position);
            _line.SetPosition(1, position + (right * 20));
        }
    }
}