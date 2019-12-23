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
        private Collider2D[] _hits = new Collider2D[15];
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

        private void Update() {
            if (!enable) return;
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, colliderSize * 1.5f, _hits);
//            Debug.Log("hit " + size + " objs");
            for (var i = 0; i < size; ++i) {
                var hit = _hits[i];
                if (!hit.CompareTag("UnitCollider")) continue;
//                Debug.Log("Melee hit");
                var unitCollider = hit.GetComponent<UnitCollider>();
                var otherUnit = unitCollider.unit;
//                Debug.Log("hit: " + hit.transform.name);
                Assert.IsNotNull(otherUnit);
                Assert.IsNotNull(unit);

                var hitChance = Random.value;
//                Debug.Log(otherUnit.transform.name + ": " + otherUnit.evasion);
                if (unit.type == otherUnit.type || otherUnit.evasion >= hitChance) continue;
//                Debug.Log("Melee damage");
                //todo play hit animation
                otherUnit.damage(unit.weapon.damage * unitCollider.dmgMul);
            }

            enable = false;
        }
    }
}