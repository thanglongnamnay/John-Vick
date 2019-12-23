using Units;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controller {
    [RequireComponent(typeof(Collider2D))]
    public class UnitCollider : MonoBehaviour {
        public Unit unit;
        private float _dmgMul = 1;

        public float dmgMul {
            get { return _dmgMul; }
        }

        private void Start() {
            unit = GetComponentInParent<Unit>();
            Assert.IsNotNull(unit);
        }
    }
}