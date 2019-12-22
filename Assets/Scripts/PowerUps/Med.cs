using Units;
using UnityEngine;

namespace PowerUps {
    public class Med : PowerUp {
        private const int Amount = 20;

        private static float amount {
            get {
                var r = Random.Range(0, 100);
                if (r < 5) return Amount * 3;
                if (r < 20) return Amount * 2;
                return Amount * 1;
            }
        }

        protected override void affect(Unit unit) {
            unit.heal(amount);
        }
    }
}