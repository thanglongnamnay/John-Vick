using Units;
using UnityEngine;

namespace PowerUps {
    public class Weed : PowerUp {
        private const float Amount = 1.3f;

        private static float amount {
            get {
                var r = Random.Range(0, 100);
                if (r < 5) return Amount * Amount * Amount;
                if (r < 20) return Amount * Amount;
                return Amount;
            }
        }
        protected override void affect(Unit unit) {
            unit.increaseMoveSpeed(unit.moveSpeed * amount, 5);
        }
    }
}