using Guns;
using Units;
using UnityEngine;

namespace PowerUps {
    public class Mag : PowerUp {
        private static int amount {
            get {
                var r = Random.Range(0, 100);
                if (r < 5) return 3;
                if (r < 20) return 2;
                return 1;
            }
        }
        protected override void affect(Unit unit) {
            var gun = unit.weapon as Gun;
            if (gun != null) gun.increaseMag(amount);
        }
    }
}