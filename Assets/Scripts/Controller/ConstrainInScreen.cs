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
            var x = camPosition.x;
            var y = camPosition.y;

            if (position.x > x + width) position.x = x + width;
            if (position.x < x - width) position.x = x - width;

            if (position.y > y + height) position.y = y + height;
            if (position.y < y - height) position.y = y - height;

            transform.position = position;
        }
    }
}