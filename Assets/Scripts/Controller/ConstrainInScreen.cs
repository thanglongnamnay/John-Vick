using System;
using UnityEngine;

namespace Controller {
    public class ConstrainInScreen : MonoBehaviour {
        public Camera ctx;

        private void Start() {
            if (!ctx) ctx = Camera.current;
        }

        private void LateUpdate() {
            var height = ctx.orthographicSize;
            var width = height * Screen.width / Screen.height;
            var position = transform.position;

            var camPosition = ctx.transform.position;
            width += camPosition.x;
            height += camPosition.y;

            if (position.x > width) position.x = width;
            if (position.x < -width) position.x = -width;

            if (position.y > height) position.y = height;
            if (position.y < -height) position.y = -height;

            transform.position = position;
        }
    }
}