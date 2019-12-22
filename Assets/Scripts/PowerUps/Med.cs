using Units;
using UnityEngine;

namespace PowerUps {
    public class Med : PowerUp {
        private static float amount {
            get {
                var r = Random.Range(0, 100);
                if (r < 5) return 10 * 3;
                if (r < 20) return 10 * 2;
                return 10 * 1;
            }
        }

        protected override void affect(Unit unit) {
            unit.heal(amount);
        }
    }
}