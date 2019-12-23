using System;
using UnityEngine;

namespace Controller {
    public class ZOrderController : MonoBehaviour {
        private void Update() {
            var transform1 = transform;
            var transformPosition = transform1.position;
            transformPosition.z = transformPosition.y / 100f;
            transform1.position = transformPosition;
        }
    }
}