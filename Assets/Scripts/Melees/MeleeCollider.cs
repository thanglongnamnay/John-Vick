using System.Collections;
using Controller;
using Units;
using UnityEngine;
using UnityEngine.Assertions;

namespace Melees {
    [RequireComponent(typeof(CircleCollider2D))]
    public class MeleeCollider : MonoBehaviour {
        public Unit unit;

        private bool _enable;
        public bool enable {
            get { return _enable; }
            set {
                _enable = value;
                if (value) {
                    StartCoroutine(disable());
                }
            }
        }

        public float colliderSize {
            get { return GetComponent<CircleCollider2D>().radius; }
        }

        private IEnumerator disable() {
            yield return new WaitForSeconds(.25f);
            enable = false;
        }

        private void OnTriggerStay2D(Collider2D other) {
            if (!enable || !other.CompareTag("UnitCollider")) return;
            Debug.Log("Melee hit");
            var otherUnit = other.GetComponent<UnitCollider>().unit;
            Assert.IsNotNull(otherUnit);
            Assert.IsNotNull(unit);
            if (unit.type != otherUnit.type) {
                Debug.Log("Melee damage");
                //todo play hit animation
                otherUnit.damage(unit.weapon.damage);
            }
        }
    }
}