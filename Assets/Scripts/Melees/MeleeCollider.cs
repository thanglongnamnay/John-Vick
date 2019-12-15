using System;
using Controller;
using Units;
using UnityEngine;
using UnityEngine.Assertions;

namespace Melees {
    [RequireComponent(typeof(Collider2D))]
    public class MeleeCollider : MonoBehaviour {
        public Unit unit;
        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag("UnitCollider")) return;
            var otherUnit = other.GetComponent<UnitCollider>().unit;
            Assert.IsNotNull(otherUnit);
            if (unit.type != otherUnit.type) {
                otherUnit.damage(unit.weapon.damage);
            }
        }
    }
}