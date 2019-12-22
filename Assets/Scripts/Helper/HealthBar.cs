using Units;
using UnityEngine;
using UnityEngine.Assertions;

namespace Helper {
    public class HealthBar : MonoBehaviour {
        public Transform bar;
        public Unit unit;

        private void OnEnable() {
            if (!unit) unit = GetComponentInParent<Unit>();
            Assert.IsNotNull(bar);
            
            var scale = new Vector3(1, 1, 1);
            scale.x *= unit.maxHp / 100;
            transform.localScale = scale;
        }

        private void Update() {
            var scale = new Vector3(1, 1, 1);
            scale.x *= unit.hp / unit.maxHp;
            bar.localScale = scale;
        }
    }
}