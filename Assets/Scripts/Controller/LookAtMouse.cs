using System;
using Guns;
using Units;
using UnityEngine;

namespace Controller {
    public class LookAtMouse : MonoBehaviour {
        public Unit unit;
        public Transform cursor;
        private float _lastRecoil;
        

        // Update is called once per frame
        private void Start()
        {
        }

        private void Update () {
            if (Cursor.lockState != CursorLockMode.Locked) return;

            var delta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            if (delta.magnitude > 5) delta = Vector2.zero;
            var distance = (Vector2)cursor.position + delta - (Vector2)transform.position;
            var angle = Vector2.SignedAngle(Vector2.right, distance.normalized);
            angle = Math.Max(angle, -40);
            angle = Math.Min(angle, 90);
            //todo: use some setter
            var com = unit.weapon as Gun;
            if (!ReferenceEquals(com, null)) {
                angle += com.currentRecoil - _lastRecoil;
                _lastRecoil = com.currentRecoil;
            }

            Transform transform1;
            (transform1 = transform).rotation = Quaternion.Euler(0, 0, angle);
            cursor.position = transform1.position + transform1.right * distance.magnitude;
        }
    }
}