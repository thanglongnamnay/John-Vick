using System;
using Units;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controller {
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class UnitCollider : MonoBehaviour {
        public Unit unit;

        private void Start() {
            unit = GetComponentInParent<Unit>();
            Assert.IsNotNull(unit);
        }
    }
}