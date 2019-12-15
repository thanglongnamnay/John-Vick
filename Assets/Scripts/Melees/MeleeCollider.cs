using System;
using Controller;
using Units;
using UnityEngine;
using UnityEngine.Assertions;

namespace Melees {
    [RequireComponent(typeof(CircleCollider2D))]
    public class MeleeCollider : MonoBehaviour {
        public Unit unit;
        public bool enable = false;

        public float colliderSize {
            get { return GetComponent<CircleCollider2D>().radius; }
        }

        private void OnTriggerStay2D(Collider2D other) {
            if (!enable || !Input.GetMouseButton(0) || !other.CompareTag("UnitCollider")) return;
            Debug.Log("Melee hit");
            var otherUnit = other.GetComponent<UnitCollider>().unit;
            Assert.IsNotNull(otherUnit);
            Assert.IsNotNull(unit);
            if (unit.type != otherUnit.type) {
                Debug.Log("Melee damage");
                otherUnit.damage(unit.weapon.damage);
            }

            enable = false;
        }
    }
}