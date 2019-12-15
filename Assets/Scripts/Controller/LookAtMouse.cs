using System;
using Guns;
using Units;
using UnityEngine;

namespace Controller {
    public class LookAtMouse : MonoBehaviour {
        public Unit unit;
        private Camera _camera;

        // Update is called once per frame
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update () {
            var angle = Vector2.SignedAngle(Vector2.right, ((Vector2) _camera.ScreenToWorldPoint(Input.mousePosition) - (Vector2) transform.position).normalized);
            angle = Math.Max(angle, -45);
            angle = Math.Min(angle, 45);
            //todo: use some setter
            var com = unit.weapon as Gun;
            if (!ReferenceEquals(com, null)) {
                angle += com.currentRecoil;
            }
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}